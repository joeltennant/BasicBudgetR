using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BasicBudgetR.Server.Application.Handlers.Households;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicBudgetR.Controllers;

public class HouseholdController : BaseController
{
    public HouseholdController(IMediator mediator) : base(mediator)
    {
    }

    [TranslateResultToActionResult]
    [HttpGet("AccountTypes")]
    public async Task<Result<ChangeName.Response>> GetHousehold()
    {
        return await _mediatr.Send(new ChangeName.Request());
    }
}
