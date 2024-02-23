using Microsoft.EntityFrameworkCore;
using RadiologyPatientsExams.Data;
using RadiologyPatientsExams.Models;

namespace RadiologyPatientsExams.Repositories;

public class PatientRepository : IRadiologyPatientRepository
{
    private readonly RadiologyDb _context;

    public PatientRepository(RadiologyDb context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetAllPatients()
    {
        return await _context.Patients.Where(x => x.NotDeleted == true).ToListAsync();
    }

    public async Task<Patient> GetPatientById(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted == true);
        return patient!;
    }

    public async void DeletePatient(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted == true);
        patient!.NotDeleted = false;

        _context.Patients.Entry(patient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async void InsertPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        _context.SaveChanges();
    }

    public async void UpdatePatient(int id, Patient patient)
    {
        var toUpdate = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted == true);
        toUpdate!.BirthDate = patient.BirthDate;
        toUpdate.Name = patient.Name;
        toUpdate.Phone = patient.Phone;
        toUpdate.Surname = patient.Surname;
        toUpdate.Email = patient.Email;
        toUpdate.NotDeleted = true;
        toUpdate.Examinations = patient.Examinations;

        _context.Update(toUpdate);
        _context.Patients.Entry(toUpdate).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
