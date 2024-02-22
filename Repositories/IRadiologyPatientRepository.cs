using RadiologyPatientsExams.Models;

namespace RadiologyPatientsExams.Repositories
{
    public interface IRadiologyPatientRepository
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        void DeletePatient(int id);
        void InsertPatient(Patient patient);
        void UpdatePatient(int id,Patient patient);
    }
}
