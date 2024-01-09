using Microsoft.AspNetCore.Identity;
using SchoolWebsite.Models;
using SchoolWebsite.ViewModels;

namespace SchoolWebsite.Repository
{
    public interface IUserRepository
    {
        Task<Status> Login(Login model);
        Task<Status> Register(Login model);
        Task<Status> ChangePassword(ChangePassword model);
    }
}
