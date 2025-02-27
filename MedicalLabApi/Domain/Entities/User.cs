﻿namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // admin, technician, doctor, patient
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}