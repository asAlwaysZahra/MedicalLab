namespace Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } // scheduled, completed, cancelled
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}