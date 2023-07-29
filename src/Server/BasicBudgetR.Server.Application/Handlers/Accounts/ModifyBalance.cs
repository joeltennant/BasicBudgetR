using Ardalis.Result.FluentValidation;
using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class ModifyBalance
{
    public record Request : IRequest<Result<Response>>
    {
        public long AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public record Response();

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

            long bta_id = await CreateBta();

            await _context.Accounts.ExecuteUpdateAsync(a => a
                            .SetProperty(p => p.BusinessTransactionActivityId, bta_id)
                            .SetProperty(p => p.Balance, request.Amount));

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
