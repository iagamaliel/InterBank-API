using InterBankServices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.Interfaces.Commands
{
    public interface IFinancialCommand
    {
        Task<bool> CreateFinancialTypeRequestCommand(FinancialTypeEntity command);
        Task<bool> ModifyFinancialTypeRequestCommand(FinancialTypeEntity command);
    }
}
