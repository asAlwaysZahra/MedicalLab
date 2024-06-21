namespace Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ContactInfo { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<TestResult> TestResults { get; set; }
}