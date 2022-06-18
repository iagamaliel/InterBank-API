using InterBankServices.Models;

namespace InterBankServices.WebApi.Models.Base
{
    public class ListResponse<T> : GenericResponse
    {
        public ICollection<T> Items { get; set; }
    }
}
