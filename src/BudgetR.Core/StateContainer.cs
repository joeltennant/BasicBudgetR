
namespace BudgetR.Core;
public class StateContainer
{
    private long? _currentUserId;
    private UserType? _userType;
    private long? _householdId;
    private string? _processName;
    private long? _btaId;
    private bool _isActive;
    private string firstName;

    public string? FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            OnChange?.Invoke();
        }
    }

    public string? ApplicationUserId { get; set; }

    public long? UserId
    {
        get => _currentUserId;
        set
        {
            _currentUserId = value;
            OnChange?.Invoke();
        }
    }

    public bool IsActive
    {
        get => _isActive; set
        {
            _isActive = value;
            OnChange?.Invoke();
        }
    }

    public UserType? UserType
    {
        get => _userType;
        set
        {
            _userType = value;
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

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
