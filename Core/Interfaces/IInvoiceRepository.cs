using Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<string> CreateInvoice(int cusId);
        Task<InvoiceRecieptDTO> GetInvoiceRecipt(int cusId , int invId);

    }
}
