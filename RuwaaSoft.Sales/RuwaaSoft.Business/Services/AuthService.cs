using System;
using System.Linq;
using System.Threading.Tasks;
using RuwaaSoft.Common.Helpers;
using RuwaaSoft.Data.UnitOfWork;
using RuwaaSoft.Domain.Entities;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Business.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Username == username && !u.IsDeleted);

                if (user == null)
                {
                    Logger.LogWarning($"Login attempt failed - User not found: {username}");
                    return null;
                }

                if (user.Status != UserStatus.Active)
                {
                    Logger.LogWarning($"Login attempt failed - User inactive: {username}");
                    return null;
                }

                var passwordHash = SecurityHelper.HashPassword(password, user.Salt);
                
                if (passwordHash != user.PasswordHash)
                {
                    Logger.LogWarning($"Login attempt failed - Invalid password: {username}");
                    return null;
                }

                user.LastLoginAt = DateTime.Now;
                _unitOfWork.Users.Update(user);
                await _unitOfWork.CompleteAsync();

                await LogAuditAsync(user.Id, AuditAction.Login, "Users", user.Id);

                Logger.LogInfo($"User logged in successfully: {username}");
                return user;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error during authentication for user: {username}", ex);
                return null;
            }
        }

        public User Authenticate(string username, string password)
        {
            try
            {
                var user = _unitOfWork.Users.SingleOrDefault(u => u.Username == username && !u.IsDeleted);

                if (user == null || user.Status != UserStatus.Active)
                {
                    return null;
                }

                var passwordHash = SecurityHelper.HashPassword(password, user.Salt);
                
                if (passwordHash != user.PasswordHash)
                {
                    return null;
                }

                user.LastLoginAt = DateTime.Now;
                _unitOfWork.Users.Update(user);
                _unitOfWork.Complete();

                LogAudit(user.Id, AuditAction.Login, "Users", user.Id);

                Logger.LogInfo($"User logged in successfully: {username}");
                return user;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error during authentication for user: {username}", ex);
                return null;
            }
        }

        private async Task LogAuditAsync(int userId, AuditAction action, string tableName, int? recordId = null)
        {
            try
            {
                var auditLog = new AuditLog
                {
                    UserId = userId,
                    Action = action,
                    TableName = tableName,
                    RecordId = recordId,
                    ActionDate = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                _unitOfWork.AuditLogs.Add(auditLog);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Error logging audit", ex);
            }
        }

        private void LogAudit(int userId, AuditAction action, string tableName, int? recordId = null)
        {
            try
            {
                var auditLog = new AuditLog
                {
                    UserId = userId,
                    Action = action,
                    TableName = tableName,
                    RecordId = recordId,
                    ActionDate = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                _unitOfWork.AuditLogs.Add(auditLog);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                Logger.LogError("Error logging audit", ex);
            }
        }
    }
}
