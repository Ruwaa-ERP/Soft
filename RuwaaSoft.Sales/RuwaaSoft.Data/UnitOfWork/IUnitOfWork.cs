using System;
using System.Threading.Tasks;
using RuwaaSoft.Data.Repositories;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<ProductDimension> ProductDimensions { get; }
        IRepository<ProductVariant> ProductVariants { get; }
        IRepository<Category> Categories { get; }
        IRepository<Unit> Units { get; }
        IRepository<Warehouse> Warehouses { get; }
        IRepository<Stock> Stocks { get; }
        IRepository<StockMovement> StockMovements { get; }
        IRepository<Customer> Customers { get; }
        IRepository<CustomerAccount> CustomerAccounts { get; }
        IRepository<CustomerLoyalty> CustomerLoyalties { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<InvoiceDetail> InvoiceDetails { get; }
        IRepository<Installment> Installments { get; }
        IRepository<Return> Returns { get; }
        IRepository<ReturnDetail> ReturnDetails { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<SupplierAccount> SupplierAccounts { get; }
        IRepository<PurchaseOrder> PurchaseOrders { get; }
        IRepository<PurchaseOrderDetail> PurchaseOrderDetails { get; }
        IRepository<Check> Checks { get; }
        IRepository<Bank> Banks { get; }
        IRepository<PaymentVoucher> PaymentVouchers { get; }
        IRepository<ExpenseVoucher> ExpenseVouchers { get; }
        IRepository<Expense> Expenses { get; }
        IRepository<Receipt> Receipts { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<RolePermission> RolePermissions { get; }
        IRepository<AuditLog> AuditLogs { get; }
        IRepository<Setting> Settings { get; }
        IRepository<DiscountPolicy> DiscountPolicies { get; }
        IRepository<PrintTemplate> PrintTemplates { get; }
        IRepository<Branch> Branches { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
