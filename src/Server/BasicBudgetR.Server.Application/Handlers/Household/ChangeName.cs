using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Household;

public class ChangeName
{
    public record Request : IRequest<Result<Response>>
    {
        public long HouseholdId { get; set; }
        public string Name { get; set; }
    }

    public record Response();

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.HouseholdId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
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

            await _context.Households
                .Where(h => h.HouseholdId == request.HouseholdId)
                .ExecuteUpdateAsync(a => a
                            .SetProperty(p => p.BusinessTransactionActivityId, bta_id)
                            .SetProperty(p => p.Name, request.Name));

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
