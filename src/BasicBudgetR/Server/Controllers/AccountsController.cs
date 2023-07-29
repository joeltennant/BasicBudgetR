using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BasicBudgetR.Core.Models;
using BasicBudgetR.Server.Application.Handlers.Accounts;
using BasicBudgetR.Server.Domain.Entities.ReferenceEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicBudgetR.Controllers;

public class AccountsController : BaseController
{
    public AccountsController(IMediator mediator) : base(mediator)
    {
    }

    [TranslateResultToActionResult]
    [HttpGet]
    public async Task<Result<List<AccountModel>>> GetAllAccounts()
    {
        return await _mediatr.Send(new GetAccounts.Query());
    }

    [TranslateResultToActionResult]
    [HttpGet("AccountTypes")]
    public async Task<Result<IList<AccountType>>> Get()
    {
        return await _mediatr.Send(new GetAccountTypes.Query());
    }

    [TranslateResultToActionResult]
    [HttpGet("AddAccount")]
    public async Task<Result<AddAccount.Response>> AddAccount(AddAccount.Request request)
    {
        return await _mediatr.Send(request);
    }

    [TranslateResultToActionResult]
    [HttpGet("ModifyBalance")]
    public async Task<Result<ModifyBalance.Response>> ModifyBalance(ModifyBalance.Request request)
    {
        return await _mediatr.Send(request);
    }
}
