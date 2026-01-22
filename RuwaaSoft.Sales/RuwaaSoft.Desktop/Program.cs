using System;
using System.Windows.Forms;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Desktop.Forms;

namespace RuwaaSoft.Desktop
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                Logger.LogInfo("Application started");
                
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                Logger.LogError("Fatal application error", ex);
                MessageBox.Show(
                    $"حدث خطأ فادح في التطبيق:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
