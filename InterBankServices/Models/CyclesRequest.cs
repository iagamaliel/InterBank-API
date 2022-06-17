using System.ComponentModel.DataAnnotations;

namespace InterBankServices.WebApi.Models
{
    public class CyclesRequest
    {

        [Required(ErrorMessage = "asfi_code is required")]
        public string asfi_code { get; set; }

        [Required(ErrorMessage = "serial_cycle is required")]
        public string serial_cycle { get; set; }

        [Required(ErrorMessage = "name_cycle is required")]
        public string name_cycle { get; set; }

        [Required(ErrorMessage = "created_date is required")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "end_date is required")]
        public DateTime end_date { get; set; }

        [Required(ErrorMessage = "Inactivate is required")]
        public byte Inactivate { get; set; }
    }
}
