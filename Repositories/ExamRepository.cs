using Microsoft.EntityFrameworkCore;
using RadiologyPatientsExams.Data;
using RadiologyPatientsExams.Models;

namespace RadiologyPatientsExams.Repositories
{
    public class ExamRepository:IRadiologyExamRepository
    {
        private readonly RadiologyDb _context;
        public ExamRepository(RadiologyDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllExams()
        {
            return await _context.Exams.Where(x=> x.NotDeleted==true).ToListAsync();
        }

        public async Task<Exam> GetExamById(int id)
        {
            var exam=await _context.Exams.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted==true);
            return exam;
        }

        public async void DeleteExam(int id)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted==true);
            exam.NotDeleted = false;

            _context.Exams.Entry(exam).State=EntityState.Modified;
            _context.SaveChanges();
        }

        public async void InsertExam(Exam exam)
        {
            _context.AddAsync(exam);
            _context.SaveChanges();
        }

        public async void UpdateExam(int id,Exam exam)
        {
            var toUpdate = await _context.Exams.FirstOrDefaultAsync(x => x.Id == id && x.NotDeleted == true);
            toUpdate.Doctor = exam.Doctor;
            toUpdate.NotDeleted = true;
            toUpdate.RefPatientId = exam.RefPatientId;
            toUpdate.Date = exam.Date;
            toUpdate.Diagnosis = exam.Diagnosis;
            toUpdate.Comments=exam.Comments;
            toUpdate.Type = exam.Type;
            toUpdate.Patient = exam.Patient;

            _context.Update(toUpdate);
            _context.Exams.Entry(toUpdate).State=EntityState.Modified;
            _context.SaveChanges();
        }

        public Task<List<Exam>> GetPatientsExams(int PatientRefId)
        {  
            var patientExams=_context.Exams.Where(x=> x.RefPatientId == PatientRefId && x.NotDeleted==true).ToListAsync();
            return patientExams;
        }
    }
}
