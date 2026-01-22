using System.Threading.Tasks;
using RuwaaSoft.Data.Context;
using RuwaaSoft.Data.Repositories;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesDbContext _context;

        public UnitOfWork(SalesDbContext context)
        {
            _context = context;
            
            Products = new Repository<Product>(_context);
            ProductDimensions = new Repository<ProductDimension>(_context);
            ProductVariants = new Repository<ProductVariant>(_context);
            Categories = new Repository<Category>(_context);
            Units = new Repository<Unit>(_context);
            Warehouses = new Repository<Warehouse>(_context);
            Stocks = new Repository<Stock>(_context);
            StockMovements = new Repository<StockMovement>(_context);
            Customers = new Repository<Customer>(_context);
            CustomerAccounts = new Repository<CustomerAccount>(_context);
            CustomerLoyalties = new Repository<CustomerLoyalty>(_context);
            Invoices = new Repository<Invoice>(_context);
            InvoiceDetails = new Repository<InvoiceDetail>(_context);
            Installments = new Repository<Installment>(_context);
            Returns = new Repository<Return>(_context);
            ReturnDetails = new Repository<ReturnDetail>(_context);
            Suppliers = new Repository<Supplier>(_context);
            SupplierAccounts = new Repository<SupplierAccount>(_context);
            PurchaseOrders = new Repository<PurchaseOrder>(_context);
            PurchaseOrderDetails = new Repository<PurchaseOrderDetail>(_context);
            Checks = new Repository<Check>(_context);
            Banks = new Repository<Bank>(_context);
            PaymentVouchers = new Repository<PaymentVoucher>(_context);
            ExpenseVouchers = new Repository<ExpenseVoucher>(_context);
            Expenses = new Repository<Expense>(_context);
            Receipts = new Repository<Receipt>(_context);
            Users = new Repository<User>(_context);
            Roles = new Repository<Role>(_context);
            RolePermissions = new Repository<RolePermission>(_context);
            AuditLogs = new Repository<AuditLog>(_context);
            Settings = new Repository<Setting>(_context);
            DiscountPolicies = new Repository<DiscountPolicy>(_context);
            PrintTemplates = new Repository<PrintTemplate>(_context);
            Branches = new Repository<Branch>(_context);
        }

        public IRepository<Product> Products { get; private set; }
        public IRepository<ProductDimension> ProductDimensions { get; private set; }
        public IRepository<ProductVariant> ProductVariants { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Unit> Units { get; private set; }
        public IRepository<Warehouse> Warehouses { get; private set; }
        public IRepository<Stock> Stocks { get; private set; }
        public IRepository<StockMovement> StockMovements { get; private set; }
        public IRepository<Customer> Customers { get; private set; }
        public IRepository<CustomerAccount> CustomerAccounts { get; private set; }
        public IRepository<CustomerLoyalty> CustomerLoyalties { get; private set; }
        public IRepository<Invoice> Invoices { get; private set; }
        public IRepository<InvoiceDetail> InvoiceDetails { get; private set; }
        public IRepository<Installment> Installments { get; private set; }
        public IRepository<Return> Returns { get; private set; }
        public IRepository<ReturnDetail> ReturnDetails { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
        public IRepository<SupplierAccount> SupplierAccounts { get; private set; }
        public IRepository<PurchaseOrder> PurchaseOrders { get; private set; }
        public IRepository<PurchaseOrderDetail> PurchaseOrderDetails { get; private set; }
        public IRepository<Check> Checks { get; private set; }
        public IRepository<Bank> Banks { get; private set; }
        public IRepository<PaymentVoucher> PaymentVouchers { get; private set; }
        public IRepository<ExpenseVoucher> ExpenseVouchers { get; private set; }
        public IRepository<Expense> Expenses { get; private set; }
        public IRepository<Receipt> Receipts { get; private set; }
        public IRepository<User> Users { get; private set; }
        public IRepository<Role> Roles { get; private set; }
        public IRepository<RolePermission> RolePermissions { get; private set; }
        public IRepository<AuditLog> AuditLogs { get; private set; }
        public IRepository<Setting> Settings { get; private set; }
        public IRepository<DiscountPolicy> DiscountPolicies { get; private set; }
        public IRepository<PrintTemplate> PrintTemplates { get; private set; }
        public IRepository<Branch> Branches { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
