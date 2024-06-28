namespace Domain.Entities;

public class LabTest
{
    public int Id { get; set; }
    public string TestName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}