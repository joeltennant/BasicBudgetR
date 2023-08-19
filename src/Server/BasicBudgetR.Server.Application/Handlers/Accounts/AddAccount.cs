using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class AddAccount
{
    public record Request : IRequest<Result<NoValue>>
    {
        public string? AccountName { get; set; }
        public decimal Balance { get; set; }
        public BalanceType BalanceType { get; set; }
        public long AccountTypeId { get; set; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.AccountName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.Balance)
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.BalanceType)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.AccountTypeId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new Validator();

        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Error(validation.Errors);
            }

            Account account = new Account
            {
                Name = request.AccountName,
                Balance = request.Balance,
                BalanceType = request.BalanceType,
                AccountTypeId = request.AccountTypeId,
                UserDetailId = _currentProcess.CurrentUserDetailId,
                BusinessTransactionActivity = new BusinessTransactionActivity
                {
                    ProcessName = _currentProcess.ProcessName,
                    UserDetailId = _currentProcess.CurrentUserDetailId,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
