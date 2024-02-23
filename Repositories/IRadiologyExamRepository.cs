using RadiologyPatientsExams.Models;

namespace RadiologyPatientsExams.Repositories;

public interface IRadiologyExamRepository
{
    Task<List<Exam>> GetAllExams();
    Task<Exam> GetExamById(int id);
    void DeleteExam(int id);
    void InsertExam(Exam exam);
    void UpdateExam(int id,Exam exam);
    Task<List<Exam>> GetPatientsExams(int PatientRefId);
}
