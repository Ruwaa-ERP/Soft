using System;

namespace RuwaaSoft.Business.Validators
{
    public static class LoginValidator
    {
        public static (bool isValid, string errorMessage) Validate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return (false, "اسم المستخدم مطلوب");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "كلمة المرور مطلوبة");
            }

            if (username.Length < 3)
            {
                return (false, "اسم المستخدم يجب أن يكون 3 أحرف على الأقل");
            }

            if (password.Length < 4)
            {
                return (false, "كلمة المرور يجب أن تكون 4 أحرف على الأقل");
            }

            return (true, string.Empty);
        }
    }
}
