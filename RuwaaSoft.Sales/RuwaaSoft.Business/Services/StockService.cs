using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Business.Services
{
    public class StockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Stock>> GetStockByWarehouseAsync(int warehouseId)
        {
            try
            {
                return await _unitOfWork.Stocks.FindAsync(s => s.WarehouseId == warehouseId && !s.IsDeleted);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error getting stock for warehouse {warehouseId}", ex);
                return new List<Stock>();
            }
        }

        public async Task<bool> UpdateStockAsync(Stock stock)
        {
            try
            {
                stock.UpdatedAt = DateTime.Now;
                stock.AvailableQuantity = stock.Quantity - stock.ReservedQuantity;
                _unitOfWork.Stocks.Update(stock);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error updating stock", ex);
                return false;
            }
        }
    }
}
