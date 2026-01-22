using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Business.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                return await _unitOfWork.Customers.FindAsync(c => !c.IsDeleted && c.IsActive);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error getting customers", ex);
                return new List<Customer>();
            }
        }

        public async Task<bool> SaveCustomerAsync(Customer customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    customer.CreatedAt = DateTime.Now;
                    _unitOfWork.Customers.Add(customer);
                }
                else
                {
                    customer.UpdatedAt = DateTime.Now;
                    _unitOfWork.Customers.Update(customer);
                }

                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error saving customer", ex);
                return false;
            }
        }
    }
}
