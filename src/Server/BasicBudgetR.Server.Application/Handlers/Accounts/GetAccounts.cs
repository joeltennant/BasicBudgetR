

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class GetAccounts
{
    public class Query : IRequest<Result<List<AccountModel>>>
    {
    }

    public class Handler : BaseHandler, IRequestHandler<Query, Result<List<AccountModel>>>
    {
        public Handler(BudgetRDbContext dbContext, CurrentProcess currentProcess) : base(dbContext, currentProcess)
        {
        }

        public async Task<Result<List<AccountModel>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var accounts = await _context.Accounts
                .Where(x => x.UserDetailId == _currentProcess.CurrentUserDetailId)
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

            return Result<List<AccountModel>>.Success(accounts.Select(x => new AccountModel
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
