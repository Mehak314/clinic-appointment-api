using ClinicAppointmentSystem.Data;
using ClinicAppointmentSystem.DTOs;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repositories;
using Microsoft.EntityFrameworkCore;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsDoctorAvailable(int doctorId, DateTime start, DateTime end)
    {
        return !await _context.Appointments.AnyAsync(a =>
            a.DoctorId == doctorId &&
            a.Status != "Cancelled" &&
            a.StartTime < end &&
            a.EndTime > start
        );
    }
}