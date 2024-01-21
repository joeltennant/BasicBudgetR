namespace BudgetR.Server.Domain.Dtos;
public class FileDto
{
    public string? Folderpath { get; set; }
    public string? Filename { get; set; }
    public bool AlreadyProcessed { get; set; }
}