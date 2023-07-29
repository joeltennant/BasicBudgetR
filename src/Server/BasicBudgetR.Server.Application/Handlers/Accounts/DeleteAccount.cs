public static class DeleteAccount
{
    public record Request : IRequest<Result<Response>>
    {
        public long AccountId { get; set; }
    }

    public record Response();

    public class Handler : BaseHandler, IRequestHandler<Request, Result<Response>>
    {
        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            Account accountToDelete = await _context.Accounts.FindAsync(request.AccountId);

            if (accountToDelete == null)
            {
                return Result<Response>.NotFound();
            }

            accountToDelete.BusinessTransactionActivityId = await CreateBta();

            _context.Accounts.Remove(accountToDelete);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
