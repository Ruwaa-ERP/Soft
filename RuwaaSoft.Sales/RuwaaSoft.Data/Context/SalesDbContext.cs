using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Data.Context
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext() : base("name=SalesConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SalesDbContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDimension> ProductDimensions { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerLoyalty> CustomerLoyalties { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnDetail> ReturnDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAccount> SupplierAccounts { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public DbSet<ExpenseVoucher> ExpenseVouchers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<DiscountPolicy> DiscountPolicies { get; set; }
        public DbSet<PrintTemplate> PrintTemplates { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
