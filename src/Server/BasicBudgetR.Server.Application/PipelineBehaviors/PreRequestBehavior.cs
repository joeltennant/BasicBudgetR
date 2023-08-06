using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasicBudgetR.Server.Application.PipelineBehaviors;

public class PreRequestBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private CurrentProcess _currentProcess;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly BudgetRDbContext _context;
    private readonly IdentityDbContext _identityDbContext;

    public PreRequestBehavior(CurrentProcess currentProcess
        , IHttpContextAccessor httpContextAccessor
        , IdentityDbContext identityDbContext
        , BudgetRDbContext context)
    {
        _currentProcess = currentProcess;
        _httpContextAccessor = httpContextAccessor;
        _identityDbContext = identityDbContext;

        _context = context;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _currentProcess.ProcessName = GetHandlerName();
        _currentProcess.CurrentUserId = GetUserId();
        GetUserDetailId();

        return Task.CompletedTask;
    }
    protected string GetHandlerName()
    {
        string handlerName = typeof(TRequest).DeclaringType.Name;
        string folderName = typeof(TRequest).Namespace.Split(".").Last();

        return folderName + "." + handlerName;
    }

    private string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    private void GetUserDetailId()
    {
        if (!string.IsNullOrWhiteSpace(_currentProcess.CurrentUserId))
        {
            var userDetail = _context.UserDetails
                .Where(x => x.UserId == _currentProcess.CurrentUserId)
                .Select(x => new UserDetail
                {
                    UserDetailId = x.UserDetailId,
                    HouseholdId = x.HouseholdId
                })
                .FirstOrDefault();

            if (userDetail == null)
            {
                userDetail = CreateUserDetail(_currentProcess.CurrentUserId);
            }

            _currentProcess.CurrentUserDetailId = userDetail.UserDetailId;
            _currentProcess.HouseholdId = userDetail.HouseholdId;
        }
        else
        {
            _currentProcess.CurrentUserDetailId = 0;
        }
    }

    private UserDetail? CreateUserDetail(string currentUserId)
    {
        string? email = _identityDbContext.Users
            .Where(x => x.Id == currentUserId)
            .Select(x => x.Email)
            .FirstOrDefault();

        long bta_id = CreateBta();

        var houseHold = new Household
        {
            Name = email,
            UserDetails = new List<UserDetail>
            {
                new UserDetail
                {
                    UserId = currentUserId,
                    BusinessTransactionActivityId = bta_id,
                }
            }
        };

        _context.Add(houseHold);
        _context.SaveChanges();
        return houseHold;
    }

    private long CreateBta()
    {
        var bta = new BusinessTransactionActivity
        {
            ProcessName = _currentProcess.ProcessName,
            UserDetailId = _currentProcess.CurrentUserDetailId,
            CreatedAt = DateTime.UtcNow
        };

        _context.BusinessTransactionActivities.Add(bta);
        _context.SaveChanges();

        return bta.BusinessTransactionActivityId;
    }
}
