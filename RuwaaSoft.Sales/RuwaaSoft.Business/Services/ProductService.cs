using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Business.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _unitOfWork.Products.FindAsync(p => !p.IsDeleted && p.IsActive);
            }
            catch (Exception ex)
            {
                Logger.LogError("Error getting products", ex);
                return new List<Product>();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _unitOfWork.Products.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error getting product {id}", ex);
                return null;
            }
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    product.CreatedAt = DateTime.Now;
                    _unitOfWork.Products.Add(product);
                }
                else
                {
                    product.UpdatedAt = DateTime.Now;
                    _unitOfWork.Products.Update(product);
                }

                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error saving product", ex);
                return false;
            }
        }
    }
}
