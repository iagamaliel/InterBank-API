using System.ComponentModel.DataAnnotations;

namespace InterBankServices.WebApi.Models
{
    public class ValidateCertificateRequest
    {

        [Required(ErrorMessage = "asfi_code is required")]
        public string asfi_code { get; set; }

        [Required(ErrorMessage = "serial_number is required")]
        public string serial_number { get; set; }
    }
}
