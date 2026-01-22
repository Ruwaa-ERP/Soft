using System;
using System.Windows.Forms;
using RuwaaSoft.Business.Services;
using RuwaaSoft.Business.Validators;
using RuwaaSoft.Common.Constants;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.Context;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;

namespace RuwaaSoft.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private AuthService _authService;
        private User _currentUser;

        public LoginForm()
        {
            InitializeComponent();
            InitializeServices();
            SetupForm();
        }

        private void InitializeServices()
        {
            try
            {
                var context = new SalesDbContext();
                var unitOfWork = new UnitOfWork(context);
                _authService = new AuthService(unitOfWork);
                
                Logger.LogInfo("Services initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.LogError("Error initializing services", ex);
                MessageBox.Show(
                    "فشل في تهيئة الخدمات. يرجى التحقق من الاتصال بقاعدة البيانات.",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetupForm()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = AppConstants.AppNameAr;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            lblTitle.Text = "تسجيل الدخول";
            lblUsername.Text = "اسم المستخدم:";
            lblPassword.Text = "كلمة المرور:";
            btnLogin.Text = "دخول";
            btnCancel.Text = "إلغاء";
            
            txtUsername.Text = "admin";
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text;

                var validation = LoginValidator.Validate(username, password);
                if (!validation.isValid)
                {
                    MessageBox.Show(
                        validation.errorMessage,
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                btnLogin.Enabled = false;
                btnLogin.Text = "جاري تسجيل الدخول...";
                Application.DoEvents();

                _currentUser = _authService.Authenticate(username, password);

                if (_currentUser != null)
                {
                    Logger.LogInfo($"User logged in: {username}");
                    
                    MessageBox.Show(
                        AppConstants.Messages.LoginSuccess,
                        "نجح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Hide();
                    var mainForm = new MainForm(_currentUser);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        AppConstants.Messages.InvalidCredentials,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    
                    btnLogin.Enabled = true;
                    btnLogin.Text = "دخول";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Login error", ex);
                MessageBox.Show(
                    $"حدث خطأ أثناء تسجيل الدخول:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                
                btnLogin.Enabled = true;
                btnLogin.Text = "دخول";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_currentUser == null)
            {
                Application.Exit();
            }
        }
    }
}
