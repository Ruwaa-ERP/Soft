namespace RuwaaSoft.Common.Constants
{
    public static class AppConstants
    {
        public const string AppName = "RuwaaSoft Sales System";
        public const string AppNameAr = "نظام مبيعات رؤى سوفت";
        public const string AppVersion = "1.0.0";
        
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string TimeFormat = "HH:mm:ss";
        
        public const decimal DefaultTaxPercentage = 15m;
        public const string DefaultCurrency = "SAR";
        public const string DefaultCurrencySymbol = "ر.س";

        public const int DefaultPageSize = 50;
        public const int MaxPageSize = 1000;

        public const string NetworkDatabasePath = "\\\\NETWORK\\Shared\\RuwaaSoft\\Database\\Sales.db";
        public const string LocalDatabasePath = "Data\\Sales.db";

        public static class Messages
        {
            public const string LoginSuccess = "تم تسجيل الدخول بنجاح";
            public const string LoginFailed = "فشل تسجيل الدخول";
            public const string InvalidCredentials = "اسم المستخدم أو كلمة المرور غير صحيحة";
            public const string SaveSuccess = "تم الحفظ بنجاح";
            public const string SaveFailed = "فشل الحفظ";
            public const string DeleteSuccess = "تم الحذف بنجاح";
            public const string DeleteFailed = "فشل الحذف";
            public const string UpdateSuccess = "تم التحديث بنجاح";
            public const string UpdateFailed = "فشل التحديث";
        }

        public static class Modules
        {
            public const string Products = "Products";
            public const string Customers = "Customers";
            public const string Suppliers = "Suppliers";
            public const string Invoices = "Invoices";
            public const string Stock = "Stock";
            public const string Reports = "Reports";
            public const string Users = "Users";
            public const string Settings = "Settings";
        }
    }
}
