using Microsoft.AspNetCore.Identity;
using SchoolWebsite.Models;
using SchoolWebsite.ViewModels;

namespace SchoolWebsite.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly SignInManager<IdentityUser> _signIn;
        private readonly RoleManager<IdentityRole> _role;

        public UserRepository(UserManager<IdentityUser> user,
            SignInManager<IdentityUser> signIn,
            RoleManager<IdentityRole> role)
        {
            _user=user;
            _signIn=signIn;
            _role=role;
        }

        public async Task<Status> ChangePassword(ChangePassword model)
        {
            var status = new Status();
            var user = await _user.FindByEmailAsync(model.Email);
            if (user == null)
            {
                status.Code=0;status.Description="User Not Found";
                return status;
            }
            var res = await _user.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if(!res.Succeeded)
            {
                status.Code = 0; status.Description = "Error in Change Password";
                foreach (var error in res.Errors)
                {
                    status.Description += "\n" + error.Description;
                }
                return status;
            }

            status.Code = 1;
            status.Description = "Password Change Success!";
            return status;
        }

        public async Task<Status> Login(Login model)
        {
            var status = new Status();
            var user = await _user.FindByNameAsync(model.Email);
            if(user == null)
            {
                status.Code = 0;
                status.Description = "Invalid User Name!";
                return status;
            }
            if(!await _user.CheckPasswordAsync(user, model.Password))
            {
                status.Code = 0;
                status.Description = "Invalid Password!";
                return status;
            }
            var res = await _signIn.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if(!res.Succeeded)
            {
                status.Code = 0;
                status.Description = "Error in Login!";
                return status;
            }

            status.Code = 1;
            status.Description = "Log in Success!";
            return status;
        }

        public async Task<Status> Register(Login model)
        {
            var status = new Status();
            var user = await _user.FindByNameAsync(model.Email);
            if(user != null)
            {
                status.Code = 0;
                status.Description = "User Already Exist!";
                return status;
            }
            user = new IdentityUser(model.Email);
            var res = await _user.CreateAsync(user, model.Password);
            if(!res.Succeeded)
            {
                status.Code = 0;status.Description = "Error in Register";
                foreach (var error in res.Errors)
                {
                    status.Description += "\n" + error.Description;
                }
                return status;
            }
            if (!await _role.RoleExistsAsync("TechSupport"))
                await _role.CreateAsync(new IdentityRole("TechSupport"));
            res = await _user.AddToRoleAsync(user, "TechSupport");
            if(!res.Succeeded)
            {
                status.Code = 0; status.Description = "Error in Assign Role";
                foreach (var error in res.Errors)
                {
                    status.Description += "\n" + error.Description;
                }
                return status;
            }

            status.Code = 1;
            status.Description = "Register Success!";
            return status;
        }
    }
}
