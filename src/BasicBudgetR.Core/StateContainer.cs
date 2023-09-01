﻿namespace BasicBudgetR.Core;
public class StateContainer
{
    private long? _currentUserId;
    private long? _householdId;
    private string? _processName;
    private long? _btaId;

    public long? CurrentUserId
    {
        get => _currentUserId;
        set
        {
            _currentUserId = value;
            OnChange?.Invoke();
        }
    }

    public long? HouseholdId
    {
        get => _householdId;
        set
        {
            _householdId = value;
            OnChange?.Invoke();
        }
    }

    public string? ProcessName
    {
        get => _processName;
        set
        {
            _processName = value;
            OnChange?.Invoke();
        }
    }

    public long? BtaId
    {
        get => _btaId;
        set
        {
            _btaId = value;
            OnChange?.Invoke();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}