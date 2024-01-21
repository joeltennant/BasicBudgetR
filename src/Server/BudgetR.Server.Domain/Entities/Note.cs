namespace BudgetR.Server.Domain.Entities;
public class Note : BaseEntity
{
    [Key]
    [Column(Order = 1)]
    public long? NoteId { get; set; }

    [Column(Order = 2)]
    public string NoteText { get; set; }
}
