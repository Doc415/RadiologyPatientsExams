using RadiologyPatientsExams.Repositories;

namespace RadiologyPatientsExams.Services;

public class ExamService
{
    private readonly IRadiologyExamRepository _repository;

    public ExamService(IRadiologyExamRepository repository)
    {
        _repository = repository;
    }
}
