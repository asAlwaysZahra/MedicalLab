namespace Domain.Entities;

public class Billing
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public decimal Amount { get; set; }
    public DateTime BillingDate { get; set; }
    public string Status { get; set; } // paid, unpaid, pending
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}