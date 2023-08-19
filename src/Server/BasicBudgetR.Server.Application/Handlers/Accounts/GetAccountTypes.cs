namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class GetAccountTypes
{
    public record Query : IRequest<Result<IList<AccountType>>>;
    public class Handler
        : BaseHandler<IList<AccountType>>, IRequestHandler<Query, Result<IList<AccountType>>>
    {
        public Handler(BudgetRDbContext dbContext, CurrentProcess currentProcess) : base(dbContext, currentProcess)
        {
        }

        public async Task<Result<IList<AccountType>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var accountTypes = await _context.AccountTypes
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Result.Success(accountTypes);
        }
    }
}
