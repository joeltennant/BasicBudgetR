using Ardalis.Result.FluentValidation;
using BasicBudgetR.Core.Enums;
using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class AddAccount
{
    public record Request : IRequest<Result<Response>>
    {
        public string? AccountName { get; set; }
        public decimal Balance { get; set; }
        public BalanceType BalanceType { get; set; }
        public long AccountTypeId { get; set; }
    }

    public record Response();

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

    public class Handler : BaseHandler, IRequestHandler<Request, Result<Response>>
    {
        private readonly Validator _validator = new Validator();

        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result<Response>.Invalid(validation.AsErrors());
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
