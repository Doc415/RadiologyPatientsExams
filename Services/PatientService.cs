using RadiologyPatientsExams.Repositories;

namespace RadiologyPatientsExams.Services
{
    public class PatientService
    {
        private readonly IRadiologyPatientRepository _repository;
        
        public PatientService(IRadiologyPatientRepository repository)
        {
            _repository = repository;
        }
    }
}
