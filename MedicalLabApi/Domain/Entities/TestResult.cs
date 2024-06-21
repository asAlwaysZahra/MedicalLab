namespace Domain.Entities;

public class TestResult
{
    public int Id { get; set; }
    public int LabTestId { get; set; }
    public LabTest LabTest { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public string ResultData { get; set; }
    public DateTime ResultDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}