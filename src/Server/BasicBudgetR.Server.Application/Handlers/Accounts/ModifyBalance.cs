using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class ModifyBalance
{
    public record Request : IRequest<Result<NoValue>>
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.AccountId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Amount)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new Validator();

        public Handler(BudgetRDbContext context, StateContainer stateContainer)
            : base(context, stateContainer)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Error(validation.Errors);
            }

            long bta_id = await CreateBta();

            await _context.Accounts
                .Where(a => a.AccountId == request.AccountId)
                .ExecuteUpdateAsync(a => a
                            .SetProperty(p => p.BusinessTransactionActivityId, bta_id)
                            .SetProperty(p => p.Balance, request.Amount));

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
