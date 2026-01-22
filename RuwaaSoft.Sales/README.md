# نظام مبيعات رؤى سوفت - RuwaaSoft Sales System

## نظرة عامة
نظام إدارة مبيعات احترافي متكامل مبني على .NET Framework 4.7.2 مع Entity Framework 6 و SQLite.

## البنية المعمارية

### 1. RuwaaSoft.Domain
طبقة النطاق - تحتوي على:
- **Entities**: 33+ كيان (Product, Customer, Invoice, Stock, إلخ.)
- **Enums**: التعدادات (UnitType, PaymentMethod, CheckStatus, إلخ.)

### 2. RuwaaSoft.Data
طبقة الوصول للبيانات - تحتوي على:
- **DbContext**: SalesDbContext مع جميع DbSets
- **Repository Pattern**: Repository<T> للعمليات العامة
- **Unit of Work**: إدارة المعاملات
- **Migrations**: إعداد قاعدة البيانات والبيانات الأولية

### 3. RuwaaSoft.Business
طبقة الأعمال - تحتوي على:
- **Services**: AuthService, ProductService, InvoiceService, إلخ.
- **Validators**: التحقق من صحة البيانات
- **Business Logic**: قواعد العمل

### 4. RuwaaSoft.Common
مكتبة مشتركة - تحتوي على:
- **Helpers**: SecurityHelper, Logger
- **Constants**: ثوابت التطبيق
- **Extensions**: ملحقات مساعدة
- **Utilities**: أدوات مساعدة

### 5. RuwaaSoft.Desktop
تطبيق سطح المكتب (Windows Forms):
- **LoginForm**: نموذج تسجيل الدخول
- **MainForm**: النموذج الرئيسي مع القوائم

## قاعدة البيانات

### الجداول الرئيسية (33+ جدول):

#### إدارة المخزون:
- Products
- ProductDimensions (أبعاد المنتجات)
- ProductVariants (أصناف المنتجات)
- Categories
- Units
- Warehouses
- Stock
- StockMovements

#### المبيعات والعملاء:
- Customers
- CustomerAccounts
- CustomerLoyalty
- Invoices
- InvoiceDetails
- Installments (الأقساط)
- Returns (المرتجعات)
- ReturnDetails

#### الموردون:
- Suppliers
- SupplierAccounts
- PurchaseOrders
- PurchaseOrderDetails

#### المالية:
- Checks (الشيكات)
- Banks
- PaymentVouchers (سندات القبض)
- ExpenseVouchers (سندات الصرف)
- Expenses
- Receipts

#### المستخدمون والأمان:
- Users
- Roles
- RolePermissions
- AuditLog (سجل المراجعة)

#### الإعدادات:
- Settings
- DiscountPolicies
- PrintTemplates
- Branches

## استراتيجية التزامن

### Network Drive SQLite Database
```
ConnectionString: Data Source=\\NETWORK\Shared\RuwaaSoft\Database\Sales.db
```

### المزايا:
- ملف SQLite واحد مشترك على الشبكة
- دعم Multi-User مع Lock Mechanism
- نسخ احتياطي سهل (ملف واحد)
- لا حاجة لخادم قاعدة بيانات منفصل

### الإعدادات:
```xml
<appSettings>
  <add key="UseNetworkDatabase" value="true" />
  <add key="NetworkDatabasePath" value="\\NETWORK\Shared\RuwaaSoft\Database\Sales.db" />
  <add key="LocalDatabasePath" value="Data\Sales.db" />
</appSettings>
```

## البيانات الأولية (Seed Data)

### المستخدم الافتراضي:
- **Username**: admin
- **Password**: admin (يجب تغييرها بعد أول تسجيل دخول)
- **Role**: Administrator

### الأدوار:
- Administrator (مدير النظام)
- Manager (مدير)
- Cashier (كاشير)

### الوحدات:
- PCS (قطعة)
- KG (كيلو)
- METER (متر)
- M² (متر مربع)
- LITER (لتر)
- BOX (صندوق)

## التشغيل

### المتطلبات:
- .NET Framework 4.7.2 أو أحدث
- Windows 7/8/10/11
- صلاحيات الوصول إلى Network Drive

### خطوات التشغيل:
1. بناء الـ Solution في Visual Studio
2. التأكد من توفر مسار قاعدة البيانات على الشبكة
3. تشغيل RuwaaSoft.Desktop.exe
4. تسجيل الدخول بحساب admin

## الميزات الرئيسية

### ✅ الأمان:
- تشفير كلمات المرور (SHA256 + Salt)
- إدارة الصلاحيات
- سجل المراجعة (Audit Log)

### ✅ إدارة المنتجات:
- دعم الأبعاد والمساحات
- أصناف متعددة لكل منتج
- فئات هرمية
- وحدات قياس مختلفة

### ✅ المبيعات:
- فواتير مبيعات
- دعم الأقساط
- المرتجعات
- الخصومات والضرائب

### ✅ المخزون:
- تتبع المخزون الفوري
- حركات المخزون
- مخازن متعددة
- تنبيهات الحد الأدنى

### ✅ التقارير:
- تقارير المبيعات
- تقارير المخزون
- تقارير العملاء
- تقارير مالية

## Logging

يتم حفظ السجلات في:
```
Application Directory\Logs\Log_YYYY-MM-DD.txt
```

أنواع السجلات:
- INFO: معلومات عامة
- WARNING: تحذيرات
- ERROR: أخطاء

## الدعم والتواصل

للدعم الفني والاستفسارات:
- **البريد الإلكتروني**: support@ruwaasoft.com
- **الموقع**: www.ruwaasoft.com

---

© 2024 RuwaaSoft - جميع الحقوق محفوظة
