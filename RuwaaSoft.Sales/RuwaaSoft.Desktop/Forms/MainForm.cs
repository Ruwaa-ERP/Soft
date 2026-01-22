using System;
using System.Windows.Forms;
using RuwaaSoft.Common.Constants;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Desktop.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            SetupForm();
            LoadUserInfo();
        }

        private void SetupForm()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = AppConstants.AppNameAr;
            this.WindowState = FormWindowState.Maximized;
            
            CreateMenu();
        }

        private void CreateMenu()
        {
            var menuStrip = new MenuStrip();
            menuStrip.RightToLeft = RightToLeft.Yes;
            
            var fileMenu = new ToolStripMenuItem("ملف");
            fileMenu.DropDownItems.Add("تسجيل الخروج", null, OnLogout);
            fileMenu.DropDownItems.Add("-");
            fileMenu.DropDownItems.Add("خروج", null, OnExit);
            
            var productsMenu = new ToolStripMenuItem("المنتجات");
            productsMenu.DropDownItems.Add("إدارة المنتجات", null, (s, e) => ShowModule("Products"));
            productsMenu.DropDownItems.Add("الفئات", null, (s, e) => ShowModule("Categories"));
            productsMenu.DropDownItems.Add("الوحدات", null, (s, e) => ShowModule("Units"));
            
            var salesMenu = new ToolStripMenuItem("المبيعات");
            salesMenu.DropDownItems.Add("فاتورة مبيعات جديدة", null, (s, e) => ShowModule("NewInvoice"));
            salesMenu.DropDownItems.Add("الفواتير", null, (s, e) => ShowModule("Invoices"));
            salesMenu.DropDownItems.Add("العملاء", null, (s, e) => ShowModule("Customers"));
            
            var stockMenu = new ToolStripMenuItem("المخزون");
            stockMenu.DropDownItems.Add("إدارة المخزون", null, (s, e) => ShowModule("Stock"));
            stockMenu.DropDownItems.Add("حركات المخزون", null, (s, e) => ShowModule("StockMovements"));
            stockMenu.DropDownItems.Add("المخازن", null, (s, e) => ShowModule("Warehouses"));
            
            var reportsMenu = new ToolStripMenuItem("التقارير");
            reportsMenu.DropDownItems.Add("تقرير المبيعات", null, (s, e) => ShowModule("SalesReport"));
            reportsMenu.DropDownItems.Add("تقرير المخزون", null, (s, e) => ShowModule("StockReport"));
            reportsMenu.DropDownItems.Add("تقرير العملاء", null, (s, e) => ShowModule("CustomersReport"));
            
            var settingsMenu = new ToolStripMenuItem("الإعدادات");
            settingsMenu.DropDownItems.Add("المستخدمون", null, (s, e) => ShowModule("Users"));
            settingsMenu.DropDownItems.Add("الصلاحيات", null, (s, e) => ShowModule("Permissions"));
            settingsMenu.DropDownItems.Add("إعدادات النظام", null, (s, e) => ShowModule("Settings"));
            
            var helpMenu = new ToolStripMenuItem("مساعدة");
            helpMenu.DropDownItems.Add("حول البرنامج", null, OnAbout);
            
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(productsMenu);
            menuStrip.Items.Add(salesMenu);
            menuStrip.Items.Add(stockMenu);
            menuStrip.Items.Add(reportsMenu);
            menuStrip.Items.Add(settingsMenu);
            menuStrip.Items.Add(helpMenu);
            
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void LoadUserInfo()
        {
            lblWelcome.Text = $"مرحباً، {_currentUser.FullName}";
            lblRole.Text = $"الصلاحية: {_currentUser.Role?.NameAr ?? "غير محدد"}";
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            
            Logger.LogInfo($"Main form loaded for user: {_currentUser.Username}");
        }

        private void ShowModule(string moduleName)
        {
            MessageBox.Show(
                $"جاري فتح وحدة: {moduleName}\n\nهذه الوحدة قيد التطوير",
                "معلومات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            
            Logger.LogInfo($"Module accessed: {moduleName} by user: {_currentUser.Username}");
        }

        private void OnLogout(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "هل أنت متأكد من تسجيل الخروج؟",
                "تأكيد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Logger.LogInfo($"User logged out: {_currentUser.Username}");
                this.Close();
                Application.Restart();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "هل أنت متأكد من الخروج من البرنامج؟",
                "تأكيد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Logger.LogInfo($"Application closed by user: {_currentUser.Username}");
                Application.Exit();
            }
        }

        private void OnAbout(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"{AppConstants.AppNameAr}\n" +
                $"الإصدار: {AppConstants.AppVersion}\n\n" +
                $"نظام إدارة المبيعات الاحترافي\n" +
                $"© 2024 RuwaaSoft\n\n" +
                $"تم التطوير بواسطة رؤى سوفت",
                "حول البرنامج",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
