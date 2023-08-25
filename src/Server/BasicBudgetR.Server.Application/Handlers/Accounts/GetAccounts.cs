namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class GetAccounts
{
    public class Request : IRequest<Result<List<AccountModel>>>
    {
    }

    public class Handler : BaseHandler<List<AccountModel>>, IRequestHandler<Request, Result<List<AccountModel>>>
    {
        public Handler(BudgetRDbContext dbContext, StateContainer stateContainer) : base(dbContext, stateContainer)
        {
        }

        public async Task<Result<List<AccountModel>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts
                .Where(x => x.HouseholdId == _stateContainer.HouseholdId)
                .Select(x => new Account
                {
                    AccountId = x.AccountId,
                    Name = x.Name,
                    Balance = x.Balance,
                    BalanceType = x.BalanceType,
                    AccountTypeId = x.AccountTypeId,
                    AccountType = new AccountType { Name = x.AccountType.Name }
                })
                .OrderBy(x => x.BalanceType)
                .ThenBy(x => x.AccountType.Name)
                .ToListAsync();

            return Result.Success(accounts.Select(x => new AccountModel
            {
                AccountId = x.AccountId,
                Name = x.Name,
                Balance = x.Balance,
                BalanceType = x.BalanceType,
                AccountTypeId = x.AccountTypeId,
                AccountType = x.AccountType.Name
            }).ToList());
        }
    }
}
