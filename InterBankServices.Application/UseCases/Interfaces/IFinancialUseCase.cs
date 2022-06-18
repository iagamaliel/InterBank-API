
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.UseCases.Interfaces
{
    
    public interface IFinancialUseCase
    {
        Task<List<FinancialTypeResponse>> ListFinancialType();
        Task<List<FinancialTypeResponse>> ListFinancialTypeId(int id);
        Task<ObjectResponse<FinancialTypeResponse>> CreateFinancialTypeRequestCommand(FinancialTypeResponse command);
        Task<ObjectResponse<FinancialTypeResponse>> ModifyFinancialTypeRequestCommand(FinancialTypeResponse command);
    }
}
