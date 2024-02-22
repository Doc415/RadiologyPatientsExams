using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RadiologyPatientsExams.Models;

public class Exam
{
        public int Id { get; set; }
        [Required]
        [ForeignKey("Examination")]
        public int RefPatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required]
        public string Type { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        [Required]
        public string Doctor { get; set; }

        public string? Comments { get; set; }

        public bool NotDeleted { get; set; } = true; 
}

