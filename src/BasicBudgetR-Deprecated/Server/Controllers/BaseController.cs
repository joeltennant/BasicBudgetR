using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicBudgetR.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediatr;

    public BaseController(IMediator mediator)
    {
        _mediatr = mediator;
    }
}
