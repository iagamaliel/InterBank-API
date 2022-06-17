using System.ComponentModel.DataAnnotations;

namespace InterBankServices.WebApi.Models
{
    public class ChannelsRequest
    {

        [Required(ErrorMessage = "asfi_code is required")]
        public string asfi_code { get; set; }

        [Required(ErrorMessage = "serial_Channel is required")]
        public string serial_Channel { get; set; }

        [Required(ErrorMessage = "Name_Channel is required")]
        public string Name_Channel { get; set; }

        [Required(ErrorMessage = "created_date is required")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "Inactivate is required")]
        public byte Inactivate { get; set; }
    }
}
