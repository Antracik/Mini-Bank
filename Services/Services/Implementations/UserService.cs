using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Services.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntityModel> _userManager;
        private readonly SignInManager<UserEntityModel> _signInManager;
        private readonly IDateService _dateService;

        public UserService(UnitOfWork unitOfWork,
                            UserManager<UserEntityModel> userManager,
                            SignInManager<UserEntityModel> signInManager,
                            IMapper mapper,
                            IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _dateService = dateService;
        }

        public async Task<IdentityResult> CreateUserAsync(UserEntityModel user, string password = null)
        {
            _dateService.SetDateCreatedNow(ref user);
            IdentityResult res;
            if (password != null)
            {
                res = await _userManager.CreateAsync(user, password);
            }
            else
            {
                res = await _userManager.CreateAsync(user);
            }

            return res;
        }

        public Task<string> GenerateUserEmailConfirmationTokenAsync(UserEntityModel user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public bool DeleteUser(int id)
        {
            _unitOfWork.AddRepository<UserEntityModel>();

            var userRepo = _unitOfWork.GetRepository<UserEntityModel>();

            var userEntity = userRepo.Get(user => user.Id == id, null, "Registrant").FirstOrDefault();

            if (userEntity.Registrant != null)
            {
                return false;
            }

            userRepo.Delete(id);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            _unitOfWork.AddRepository<UserEntityModel>();

            var userEntities = _unitOfWork.GetRepository<UserEntityModel>().Get().ToList();

            var userModels = _mapper.Map<List<UserServiceModel>>(userEntities);

            return userModels;
        }

        public IEnumerable<UserServiceModel> GetAllUsers(string orderBy, string filter)
        {

            var repo = _unitOfWork.AddRepository<UserEntityModel>().GetRepository<UserEntityModel>();

            var userEntities = repo.Get();

            if (!string.IsNullOrEmpty(filter))
            {
                userEntities = userEntities.Where(x => x.Email.ToUpper().Contains(filter.ToUpper())).ToList();
            }

            switch (orderBy)
            {
                case "Id":
                    userEntities = userEntities.OrderBy(x => x.Id).ToList();
                    break;
                case "Id_desc":
                    userEntities = userEntities.OrderByDescending(x => x.Id).ToList();
                    break;
                case "DateCreated":
                    userEntities = userEntities.OrderBy(x => x.DateCreated).ToList();
                    break;
                case "DateCreated_desc":
                    userEntities = userEntities.OrderByDescending(x => x.DateCreated).ToList();
                    break;
                case "EmailConfirmed":
                    userEntities = userEntities.OrderBy(x => x.EmailConfirmed).ToList();
                    break;
                case "EmailConfirmed_desc":
                    userEntities = userEntities.OrderByDescending(x => x.EmailConfirmed).ToList();
                    break;
                case "Email":
                    userEntities = userEntities.OrderBy(x => x.Email).ToList();
                    break;
                case "Email_desc":
                    userEntities = userEntities.OrderByDescending(x => x.Email).ToList();
                    break;
                default:
                    userEntities = userEntities.OrderBy(x => x.Id).ToList();
                    break;
            }

             var userModels = _mapper.Map<List<UserServiceModel>>(userEntities);

            return userModels;
        }

        public UserServiceModel GetUserByEmail(string email)
        {
            _unitOfWork.AddRepository<UserEntityModel>();

            var userEntity = _unitOfWork.GetRepository<UserEntityModel>().Get(user => user.Email == email).FirstOrDefault();

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel;
        }

        public UserServiceModel GetUserById(int id, bool includeRegistrant = false)
        {
            var userEntity = new UserEntityModel();

            _unitOfWork.AddRepository<UserEntityModel>();

            if (includeRegistrant)
            {
                userEntity = _unitOfWork.GetRepository<UserEntityModel>().Get(user => user.Id == id, null, "Registrant").FirstOrDefault();
            }
            else
            {
                userEntity = _unitOfWork.GetRepository<UserEntityModel>().GetById(id);
            }

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel;
        }

        public void UpdateUser(UserServiceModel user)
        {
            _unitOfWork.AddRepository<UserEntityModel>();

            var userEntity = _mapper.Map<UserEntityModel>(user);

            _dateService.SetDateEditedNow(ref userEntity);

            _unitOfWork.GetRepository<UserEntityModel>().Update(userEntity);
            _unitOfWork.Save();

        }

        public bool IsUserSignedInAsAdmin(ClaimsPrincipal User)
        {
            return (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"));
        }

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            var entity = await GetUserByIdAsync(userId.ToString());

            return await _userManager.IsInRoleAsync(entity, roleName);
        }

        public Task<IEnumerable<AuthenticationScheme>> GetExternalLoginAuthenticationSchemesAsync()
        {
            return _signInManager.GetExternalAuthenticationSchemesAsync();
        }

        public Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task<UserEntityModel> GetTwoFactorAuthenticationUserAsync()
        {
            return _signInManager.GetTwoFactorAuthenticationUserAsync();
        }

        public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
        {
            return _signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
        }

        public Task<UserEntityModel> GetUserByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<IdentityResult> ConfirmUserEmailAsync(UserEntityModel user, string code)
        {
            return _userManager.ConfirmEmailAsync(user, code);
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            return _signInManager.GetExternalLoginInfoAsync();
        }

        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
        {
            return _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
        }

        public Task<IdentityResult> AddUserLoginAsync(UserEntityModel user, ExternalLoginInfo info)
        {
            return _userManager.AddLoginAsync(user, info);
        }

        public Task SignInAsync(UserEntityModel user, bool isPersistent)
        {
            return _signInManager.SignInAsync(user, isPersistent);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public Task<UserEntityModel> GetUserByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<bool> IsUserEmailConfirmedAsync(UserEntityModel user)
        {
            return _userManager.IsEmailConfirmedAsync(user);
        }

        public Task<string> GeneratePasswordResetTokenAsync(UserEntityModel user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<IdentityResult> ResetPasswordAsync(UserEntityModel user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public Task<UserEntityModel> GetUserAsync(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            return _userManager.GetUserId(principal);
        }

        public Task<bool> IsUserTwoFactorEnabledAsync(UserEntityModel user)
        {
            return _userManager.GetTwoFactorEnabledAsync(user);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(UserEntityModel user, bool enabled)
        {
            return _userManager.SetTwoFactorEnabledAsync(user, enabled);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(UserEntityModel user, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, token);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(UserEntityModel user, string tokenProvider, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public Task<string> GetUserIdAsync(UserEntityModel user)
        {
            return _userManager.GetUserIdAsync(user);
        }

        public Task<int> CountValidRecoveryCodesAsync(UserEntityModel user)
        {
            return _userManager.CountRecoveryCodesAsync(user);
        }

        public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(UserEntityModel user, int number)
        {
            return _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public Task<string> GetAuthenticatorKeyAsync(UserEntityModel user)
        {
            return _userManager.GetAuthenticatorKeyAsync(user);
        }

        public Task<string> GetUserEmailAsync(UserEntityModel user)
        {
            return _userManager.GetEmailAsync(user);
        }

        public Task<IdentityResult> ResetAuthenticatorKeyAsync(UserEntityModel user)
        {
            return _userManager.ResetAuthenticatorKeyAsync(user);
        }

        public Task<bool> HasPasswordAsync(UserEntityModel user)
        {
            return _userManager.HasPasswordAsync(user);
        }

        public Task<IdentityResult> ChangePasswordAsync(UserEntityModel user, string oldPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public Task RefreshSignInAsync(UserEntityModel user)
        {
            return _signInManager.RefreshSignInAsync(user);
        }

        public Task<string> GetUserPhoneNumberAsync(UserEntityModel user)
        {
            return _userManager.GetPhoneNumberAsync(user);
        }

        public Task<string> GetUserNameAsync(UserEntityModel user)
        {
            return _userManager.GetUserNameAsync(user);
        }

        public Task<IdentityResult> SetUserEmailAsync(UserEntityModel user, string email)
        {
            return _userManager.SetEmailAsync(user, email);
        }

        public Task<IdentityResult> SetUserPhoneNumberAsync(UserEntityModel user, string phoneNumber)
        {
            return _userManager.SetPhoneNumberAsync(user, phoneNumber);
        }

        public Task<IdentityResult> AddPasswordAsync(UserEntityModel user, string password)
        {
            return _userManager.AddPasswordAsync(user, password);
        }

        public Task<bool> IsTwoFactorClientRememberedAsync(UserEntityModel user)
        {
            return _signInManager.IsTwoFactorClientRememberedAsync(user);
        }

        public Task ForgetTwoFactorClientAsync()
        {
            return _signInManager.ForgetTwoFactorClientAsync();
        }

        public string GetUserName(ClaimsPrincipal principal)
        {
            return _userManager.GetUserName(principal);
        }

        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return _signInManager.IsSignedIn(principal);
        }

        public async Task<bool> IsUserEmailConfirmedAsync(ClaimsPrincipal User)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return false;

            return user.EmailConfirmed;
        }
    }
}
