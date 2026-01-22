using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Business.Services
{
    public class InvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            try
            {
                return await _unitOfWork.Invoices.FindAsync(i => !i.IsDeleted);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error getting invoices", ex);
                return new List<Invoice>();
            }
        }

        public async Task<bool> SaveInvoiceAsync(Invoice invoice)
        {
            try
            {
                if (invoice.Id == 0)
                {
                    invoice.CreatedAt = DateTime.Now;
                    _unitOfWork.Invoices.Add(invoice);
                }
                else
                {
                    invoice.UpdatedAt = DateTime.Now;
                    _unitOfWork.Invoices.Update(invoice);
                }

                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error saving invoice", ex);
                return false;
            }
        }
    }
}
