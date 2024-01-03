using BudgetR.Core.Models;

namespace BudgetR.Core;
public class ClientContext
{
    public ClientContext()
    {
            
    }

    private MonthSelection? _monthSelection;
    public MonthSelection? MonthSelection
    {
        get => _monthSelection;
        set
        {
            _monthSelection = value;
            NotifyStateChanged();
        }
    }
    public event Action? OnChange;

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
