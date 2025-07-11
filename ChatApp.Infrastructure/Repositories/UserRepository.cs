using ChatApp.Application.Contract.Persistence;
using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Repositories
{
    public class UserRepository : GenericIdentityRepository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(ApplicationDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;

        }

        public async Task<string> CreateUser(User user, string Password)
        {
            await _userManager.CreateAsync(user, Password);
            return user.Id;
        }

        public async Task<bool> EmailIsExist(string email)
        {
            return _dbContext.Users.Where(x => x.Email == email).Any();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
