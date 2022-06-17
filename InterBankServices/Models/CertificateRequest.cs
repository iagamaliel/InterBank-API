using System.ComponentModel.DataAnnotations;

namespace InterBankServices.Models
{
    public class CertificateRequest
    {

        [Required(ErrorMessage = "asfi_code is required")]
        public string asfi_code { get; set; }

        [Required(ErrorMessage = "serial_number is required")]
        public string serial_number { get; set; }

        [Required(ErrorMessage = "created_date is required")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "validity_date is required")]
        public DateTime validity_date { get; set; }

        [Required(ErrorMessage = "owner is required")]
        public string owner { get; set; }

        [Required(ErrorMessage = "certificate is required")]
        public byte certificate { get; set; }

    }
}
