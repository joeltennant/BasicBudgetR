namespace BudgetR.Server.Domain.Dtos;
public class TransactionDto
{
    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? AccountName { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? TransactionDate { get; set; }
    public string? Status { get; set; }
}
