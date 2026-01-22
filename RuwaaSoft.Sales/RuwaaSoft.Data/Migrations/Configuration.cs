using System;
using System.Data.Entity.Migrations;
using System.Linq;
using RuwaaSoft.Data.Context;
using RuwaaSoft.Domain.Entities;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SalesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "RuwaaSoft.Data.Context.SalesDbContext";
        }

        protected override void Seed(SalesDbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedUnits(context);
            SeedBranches(context);
            SeedWarehouses(context);
            SeedSettings(context);

            context.SaveChanges();
        }

        private void SeedRoles(SalesDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddOrUpdate(r => r.Name,
                    new Role
                    {
                        Name = "Administrator",
                        NameAr = "مدير النظام",
                        Description = "Full system access",
                        IsActive = true,
                        IsSystemRole = true,
                        CreatedAt = DateTime.Now
                    },
                    new Role
                    {
                        Name = "Manager",
                        NameAr = "مدير",
                        Description = "Branch manager access",
                        IsActive = true,
                        IsSystemRole = false,
                        CreatedAt = DateTime.Now
                    },
                    new Role
                    {
                        Name = "Cashier",
                        NameAr = "كاشير",
                        Description = "Sales and basic operations",
                        IsActive = true,
                        IsSystemRole = false,
                        CreatedAt = DateTime.Now
                    }
                );
            }
        }

        private void SeedUsers(SalesDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Administrator");
                if (adminRole != null)
                {
                    context.Users.AddOrUpdate(u => u.Username,
                        new User
                        {
                            Username = "admin",
                            PasswordHash = "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918",
                            Salt = "SALT123",
                            FullName = "Administrator",
                            Email = "admin@ruwaasoft.com",
                            RoleId = adminRole.Id,
                            Status = UserStatus.Active,
                            CreatedAt = DateTime.Now
                        }
                    );
                }
            }
        }

        private void SeedUnits(SalesDbContext context)
        {
            if (!context.Units.Any())
            {
                context.Units.AddOrUpdate(u => u.Symbol,
                    new Unit { Name = "Piece", NameAr = "قطعة", Symbol = "PCS", UnitType = UnitType.PCS, IsActive = true, CreatedAt = DateTime.Now },
                    new Unit { Name = "Kilogram", NameAr = "كيلو", Symbol = "KG", UnitType = UnitType.KG, IsActive = true, CreatedAt = DateTime.Now },
                    new Unit { Name = "Meter", NameAr = "متر", Symbol = "M", UnitType = UnitType.METER, IsActive = true, CreatedAt = DateTime.Now },
                    new Unit { Name = "Square Meter", NameAr = "متر مربع", Symbol = "M²", UnitType = UnitType.SQUARE_METER, IsActive = true, CreatedAt = DateTime.Now },
                    new Unit { Name = "Liter", NameAr = "لتر", Symbol = "L", UnitType = UnitType.LITER, IsActive = true, CreatedAt = DateTime.Now },
                    new Unit { Name = "Box", NameAr = "صندوق", Symbol = "BOX", UnitType = UnitType.BOX, IsActive = true, CreatedAt = DateTime.Now }
                );
            }
        }

        private void SeedBranches(SalesDbContext context)
        {
            if (!context.Branches.Any())
            {
                context.Branches.AddOrUpdate(b => b.Code,
                    new Branch
                    {
                        Name = "Main Branch",
                        NameAr = "الفرع الرئيسي",
                        Code = "BR001",
                        Phone = "123456789",
                        Address = "Main Street",
                        City = "Riyadh",
                        IsActive = true,
                        IsMainBranch = true,
                        CreatedAt = DateTime.Now
                    }
                );
            }
        }

        private void SeedWarehouses(SalesDbContext context)
        {
            if (!context.Warehouses.Any())
            {
                var mainBranch = context.Branches.FirstOrDefault(b => b.IsMainBranch);
                if (mainBranch != null)
                {
                    context.Warehouses.AddOrUpdate(w => w.Code,
                        new Warehouse
                        {
                            Name = "Main Warehouse",
                            NameAr = "المستودع الرئيسي",
                            Code = "WH001",
                            Address = "Main Street",
                            BranchId = mainBranch.Id,
                            IsActive = true,
                            CreatedAt = DateTime.Now
                        }
                    );
                }
            }
        }

        private void SeedSettings(SalesDbContext context)
        {
            if (!context.Settings.Any())
            {
                context.Settings.AddOrUpdate(s => s.Key,
                    new Setting
                    {
                        Key = "CompanyName",
                        Value = "RuwaaSoft",
                        Description = "Company Name",
                        Category = "General",
                        CreatedAt = DateTime.Now
                    },
                    new Setting
                    {
                        Key = "CompanyNameAr",
                        Value = "رؤى سوفت",
                        Description = "Company Name in Arabic",
                        Category = "General",
                        CreatedAt = DateTime.Now
                    },
                    new Setting
                    {
                        Key = "TaxPercentage",
                        Value = "15",
                        Description = "Default Tax Percentage",
                        Category = "Financial",
                        CreatedAt = DateTime.Now
                    },
                    new Setting
                    {
                        Key = "Currency",
                        Value = "SAR",
                        Description = "Currency Code",
                        Category = "Financial",
                        CreatedAt = DateTime.Now
                    },
                    new Setting
                    {
                        Key = "DatabasePath",
                        Value = "\\\\NETWORK\\Shared\\RuwaaSoft\\Database\\Sales.db",
                        Description = "Network Database Path",
                        Category = "System",
                        CreatedAt = DateTime.Now
                    }
                );
            }
        }
    }
}
