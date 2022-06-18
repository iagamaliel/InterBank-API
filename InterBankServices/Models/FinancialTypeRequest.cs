using System.ComponentModel.DataAnnotations;

namespace InterBankServices.WebApi.Models
{
    public class FinancialTypeRequest
    {

        [Required(ErrorMessage = "description is required")]
        public string description { get; set; }

        public int id { get; set; }
    }
}
