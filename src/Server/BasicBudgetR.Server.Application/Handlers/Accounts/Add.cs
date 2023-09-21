﻿using FluentValidation;

namespace BasicBudgetR.Server.Application.Handlers.Accounts;
public class Add
{
    public class Request : IRequest<Result<NoValue>>
    {
        public string? AccountName { get; set; }
        public decimal? Balance { get; set; }
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
                .NotNull();
            RuleFor(x => x.AccountTypeId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new();

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

            Account account = new()
            {
                Name = request.AccountName,
                Balance = request.Balance.Value,
                BalanceType = request.BalanceType,
                AccountTypeId = request.AccountTypeId,
                HouseholdId = _stateContainer.HouseholdId.Value,
                BusinessTransactionActivity = new BusinessTransactionActivity
                {
                    ProcessName = "Accounts.Add",
                    UserId = _stateContainer.CurrentUserId.Value,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
