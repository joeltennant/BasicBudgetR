using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Households;

public class ChangeName
{
    public record Request : IRequest<Result<NoValue>>
    {
        public long HouseholdId { get; set; }
        public string Name { get; set; }
    }

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

            long bta_id = await CreateBta(true, "Household.ChangeName");

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
