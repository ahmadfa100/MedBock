using System.ComponentModel.DataAnnotations;

namespace MedBock.Areas.Patient.Models
{
    public class PatientRegisterViewModel
    {

        public string FirstName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required.") ]
        public string LastName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required.")]
        public string Mobile { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required.")]
        public string Gender { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required.")]
        public string Email { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required.")]
        public string Password { get; set; } = string.Empty;
        public bool HasHealthInsurance { get; set; } = false;

    }
}
