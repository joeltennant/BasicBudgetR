public static class DeleteAccount
{
    public record Request : IRequest<Result<NoValue>>
    {
        public long AccountId { get; set; }
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            Account accountToDelete = await _context.Accounts.FindAsync(request.AccountId);

            if (accountToDelete == null)
            {
                return Result.NotFound();
            }

            accountToDelete.BusinessTransactionActivityId = await CreateBta();

            _context.Accounts.Remove(accountToDelete);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
