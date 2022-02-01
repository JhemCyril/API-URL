using Project.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Project.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpUser signUpUser);
        Task<string> LoginAsync(SignUpUser signUpUser);
    }
}