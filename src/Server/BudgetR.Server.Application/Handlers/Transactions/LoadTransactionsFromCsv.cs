using BudgetR.Core.Enums;
using BudgetR.Server.BusinessRules.Transactions;
using BudgetR.Server.BusinessRules.Transactions.Helpers;
using BudgetR.Server.Domain.Dtos;
using BudgetR.Server.Domain.Entities.Transactions;
using Microsoft.Extensions.Configuration;

namespace BudgetR.Server.Application.Handlers.Transactions;
internal class LoadTransactionsFromCsv
{
    public record Request() : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        private string path = string.Empty;
        protected TransactionProcessorDto Transactions;
        protected List<TransactionStep> steps = new();


        public Handler(BudgetRDbContext dbContext, ServerContainer stateContainer, IConfiguration configuration) : base(dbContext, stateContainer)
        {
            path = configuration.GetSection("CsvFilePath").Value!;
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            DateTime startedAt = DateTime.Now;

            var files = GetFiles();

            List<LoadedTransactionDto> transactions = new();
            if (files.IsPopulated())
            {
                transactions = new LoadFromCsv().GetTransactions(files);
            }

            if (transactions.IsNotPopulated())
            {
                return new Result<NoValue>();
            }

            //RUN ALL STEPS 
            RunSteps();

            //Save all to database
            TransactionBatch transactionBatch = new TransactionBatch
            {
                StartedAt = startedAt,
                CompletedAt = DateTime.Now,
                RecordCount = transactions.Count,
                Source = BatchSource.CSV,
                BusinessTransactionActivity = new BusinessTransactionActivity
                {
                    ProcessName = "Transaction Batch Process Console",
                    CreatedAt = DateTime.Now,
                    UserId = 1//System User
                },
                Transactions = this.Transactions.TransactionEntities,
                ProcessedFiles = GetFilesList(files),
                HouseholdId = (long)_stateContainer.HouseholdId
            };
            _context.TransactionBatches.Add(transactionBatch);
            _context.SaveChanges();

            return Result.Success();
        }

        private List<ProcessedFile> GetFilesList(List<FileDto> files)
        {
            if (files.IsPopulated())
            {
                return files.Select(f => new ProcessedFile
                {
                    RunOn = DateTime.Now,
                    FileName = f.Filename
                })
                            .ToList();
            }
            return null;
        }

        private List<FileDto> GetFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<FileDto> allFiles = dir.GetFiles("*.csv")
                .Select(f => new FileDto
                {
                    Folderpath = f.DirectoryName,
                    Filename = Path.GetFileNameWithoutExtension(f.FullName)
                })
                .ToList();

            List<string>? processedFiles = _context.ProcessedFiles
                .Where(s => s.TransactionBatch.Source == BatchSource.CSV)
                .Select(s => s.FileName)
                .ToList();

            if (processedFiles != null
                && processedFiles.Count > 0
                && allFiles != null
                && allFiles.Count > 0)
            {
                foreach (var item in allFiles)
                {
                    if (processedFiles.Contains(item.Filename))
                    {
                        item.AlreadyProcessed = true;
                    }
                }
            }

            return allFiles.Where(f => !f.AlreadyProcessed).ToList();
        }

        public void RunSteps()
        {
            foreach (var item in this.steps.OrderBy(s => s.StepOrder))
            {
                var step = item.Step.Compile().Invoke();
                this.Transactions = step.Execute(this.Transactions);
            }
        }

        public void PopulateSteps()
        {
            this.steps = new List<TransactionStep>
            {
                new TransactionStep { Step = () => new AssignAccounts(_context, _stateContainer), StepOrder = 1 }
            };
        }
    }
}
