# دليل البناء والتطوير - RuwaaSoft Sales System

## البيئة المطلوبة

### البرامج الأساسية:
1. **Visual Studio 2019 أو أحدث**
   - Workload: .NET Desktop Development
   - .NET Framework 4.7.2 SDK

2. **SQL Server Management Studio** (اختياري - للإدارة)

3. **Git** (لإدارة الإصدارات)

## خطوات البناء

### 1. استنساخ المشروع
```bash
git clone <repository-url>
cd RuwaaSoft.Sales
```

### 2. استعادة Packages
افتح Solution في Visual Studio:
```
File -> Open -> Solution -> RuwaaSoft.Sales.sln
```

استعادة NuGet Packages:
```
Right-click on Solution -> Restore NuGet Packages
```

أو من Package Manager Console:
```powershell
Update-Package -reinstall
```

### 3. إعداد قاعدة البيانات

#### طريقة 1: تلقائياً (موصى بها)
- قم بتشغيل التطبيق وسيتم إنشاء قاعدة البيانات تلقائياً

#### طريقة 2: Package Manager Console
```powershell
# في Visual Studio -> Tools -> NuGet Package Manager -> Package Manager Console
# اختر RuwaaSoft.Data كـ Default Project

Enable-Migrations
Add-Migration InitialCreate
Update-Database -Verbose
```

### 4. إعداد مسار قاعدة البيانات

#### للاختبار المحلي:
عدّل `App.config` في RuwaaSoft.Desktop:
```xml
<connectionStrings>
  <add name="SalesConnection" 
       connectionString="Data Source=|DataDirectory|\Sales.db;Version=3;" 
       providerName="System.Data.SQLite.EF6" />
</connectionStrings>

<appSettings>
  <add key="UseNetworkDatabase" value="false" />
</appSettings>
```

#### للإنتاج (Network Drive):
```xml
<connectionStrings>
  <add name="SalesConnection" 
       connectionString="Data Source=\\NETWORK\Shared\RuwaaSoft\Database\Sales.db;Version=3;" 
       providerName="System.Data.SQLite.EF6" />
</connectionStrings>

<appSettings>
  <add key="UseNetworkDatabase" value="true" />
  <add key="NetworkDatabasePath" value="\\NETWORK\Shared\RuwaaSoft\Database\Sales.db" />
</appSettings>
```

### 5. البناء
```
Build -> Build Solution (Ctrl+Shift+B)
```

### 6. التشغيل
```
Debug -> Start Debugging (F5)
```

أو:
```
Debug -> Start Without Debugging (Ctrl+F5)
```

## هيكل المشروع

```
RuwaaSoft.Sales/
├── RuwaaSoft.Domain/          # Domain Layer
│   ├── Entities/              # 33+ Entity Classes
│   └── Enums/                 # Enumerations
├── RuwaaSoft.Data/            # Data Access Layer
│   ├── Context/               # DbContext
│   ├── Repositories/          # Repository Pattern
│   ├── UnitOfWork/           # Unit of Work Pattern
│   └── Migrations/           # EF Migrations
├── RuwaaSoft.Business/        # Business Logic Layer
│   ├── Services/             # Business Services
│   └── Validators/           # Validation Logic
├── RuwaaSoft.Common/          # Common Utilities
│   ├── Helpers/              # Helper Classes
│   ├── Constants/            # Application Constants
│   ├── Extensions/           # Extension Methods
│   └── Utilities/            # Utility Classes
└── RuwaaSoft.Desktop/         # Windows Forms App
    ├── Forms/                # Form Classes
    ├── Controls/             # Custom Controls
    └── App.config            # Configuration
```

## NuGet Packages المستخدمة

### جميع المشاريع:
- EntityFramework 6.4.4
- System.Data.SQLite.Core 1.0.118.0
- System.Data.SQLite.EF6 1.0.118.0
- System.Data.SQLite.Linq 1.0.118.0

## التطوير

### إضافة Entity جديد:
1. أنشئ الـ Class في `RuwaaSoft.Domain/Entities/`
2. أضف DbSet في `SalesDbContext.cs`
3. أضف Repository في `UnitOfWork`
4. أنشئ Migration:
   ```powershell
   Add-Migration Add<EntityName>
   Update-Database
   ```

### إضافة Service جديد:
1. أنشئ Class في `RuwaaSoft.Business/Services/`
2. استخدم IUnitOfWork للوصول للبيانات
3. أضف Business Logic المطلوب

### إضافة Form جديد:
1. أنشئ Form في `RuwaaSoft.Desktop/Forms/`
2. أضف Designer File
3. أضف Resx File
4. سجل Form في القائمة الرئيسية

## Debugging

### تفعيل SQL Logging:
في `SalesDbContext.cs`:
```csharp
public SalesDbContext() : base("name=SalesConnection")
{
    Database.Log = sql => Debug.WriteLine(sql);
}
```

### عرض الاستثناءات التفصيلية:
```csharp
try
{
    // code
}
catch (DbEntityValidationException ex)
{
    foreach (var eve in ex.EntityValidationErrors)
    {
        Console.WriteLine($"Entity: {eve.Entry.Entity.GetType().Name}");
        foreach (var ve in eve.ValidationErrors)
        {
            Console.WriteLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
        }
    }
}
```

## Testing

### اختبار الاتصال بقاعدة البيانات:
```csharp
using (var context = new SalesDbContext())
{
    var canConnect = context.Database.Exists();
    Console.WriteLine($"Database exists: {canConnect}");
}
```

### اختبار المستخدم الافتراضي:
- Username: `admin`
- Password: `admin`

## النشر (Deployment)

### 1. إعداد للنشر:
```
Build -> Configuration Manager -> Release
```

### 2. بناء النشر:
```
Build -> Publish RuwaaSoft.Desktop
```

### 3. المتطلبات على الجهاز المستهدف:
- .NET Framework 4.7.2 Runtime
- Visual C++ Redistributable (لـ SQLite)
- صلاحيات الوصول للـ Network Drive

### 4. ملفات النشر:
```
Release/
├── RuwaaSoft.Desktop.exe
├── RuwaaSoft.Domain.dll
├── RuwaaSoft.Data.dll
├── RuwaaSoft.Business.dll
├── RuwaaSoft.Common.dll
├── EntityFramework.dll
├── System.Data.SQLite.dll
└── App.config
```

## استكشاف الأخطاء

### خطأ: "Unable to load DLL 'SQLite.Interop.dll'"
**الحل**: تأكد من وجود المجلدات:
```
bin/Debug/x86/SQLite.Interop.dll
bin/Debug/x64/SQLite.Interop.dll
```

### خطأ: "Network path not found"
**الحل**: 
1. تحقق من صلاحيات الوصول للمجلد المشترك
2. استخدم المسار المحلي للاختبار

### خطأ: "Database is locked"
**الحل**:
1. أغلق جميع الاتصالات المفتوحة
2. تأكد من استخدام `using` statements
3. قلل من وقت المعاملات الطويلة

## الأداء

### نصائح للأداء:
1. استخدم Async/Await للعمليات الطويلة
2. فعّل Connection Pooling في Connection String:
   ```
   Pooling=True;Max Pool Size=100;
   ```
3. استخدم `.AsNoTracking()` للقراءة فقط
4. استخدم Indexes للأعمدة المستخدمة في البحث

## الدعم

للحصول على المساعدة:
1. راجع الـ Logs في مجلد `Logs/`
2. تحقق من Issues في GitHub
3. اتصل بفريق الدعم: support@ruwaasoft.com

---

© 2024 RuwaaSoft
