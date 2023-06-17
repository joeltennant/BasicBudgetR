﻿namespace BasicBudgetR.Server.Application.Common;
public abstract class BaseHandler
{
    protected readonly BbrDbContext _context;
    protected readonly CurrentProcess _currentProcess;

    protected BaseHandler(BbrDbContext dbContext, CurrentProcess currentProcess)
    {
        _context = dbContext;
        _currentProcess = currentProcess;
    }
}