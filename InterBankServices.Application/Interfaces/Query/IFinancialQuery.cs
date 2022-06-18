using InterBankServices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.Interfaces.Query
{
    public interface IFinancialQuery
    {
        Task<List<FinancialTypeEntity>> ListFinancialType();
        Task<List<FinancialTypeEntity>> ListFinancialTypeId(int id);
    }
}
