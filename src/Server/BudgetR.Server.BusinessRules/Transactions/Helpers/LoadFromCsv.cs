using BudgetR.Server.Domain.Dtos;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BudgetR.Server.BusinessRules.Transactions.Helpers;
public class LoadFromCsv
{
    public List<LoadedTransactionDto> GetTransactions(List<FileDto> files)
    {
        List<LoadedTransactionDto> transactionDtos = new();
        if (files != null && files.Count > 0)
        {
            DateTime startedAt = DateTime.Now;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Replace(" ", ""),
            };
            foreach (var item in files)
            {
                using var reader = new StreamReader(@$"{item.Folderpath}/{item.Filename}.csv");
                using var csv = new CsvReader(reader, config);
                var records = csv.GetRecords<TransactionDto>();

                foreach (var record in records)
                {
                    transactionDtos.Add(new LoadedTransactionDto
                    {
                        Description = record.Description,
                        Category = record.Category,
                        AccountName = record.AccountName,
                        Amount = record.Amount,
                        TransactionDate = record.TransactionDate,
                        Status = record.Status,
                        Sign = record.Amount > 0 ? Sign.Positive : Sign.Negative,
                        TransactionType = TransactionType.None
                    });
                }
            }
        }

        return transactionDtos;
    }
}
