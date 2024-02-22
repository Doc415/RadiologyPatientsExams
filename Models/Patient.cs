using System.ComponentModel.DataAnnotations;
using RadiologyPatientsExams.Validations;

namespace RadiologyPatientsExams.Models;

public class Patient
{
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string Surname { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [Required]
        [BirthDateValidation(ErrorMessage = "Birthdate can not be in the future.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public int Email { get; set; }

        [Display(Name = "Pnone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int Phone { get; set; }

        public bool NotDeleted { get; set; } = true;

        public ICollection<Exam> Examinations { get; set; }
    
}
