using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.DAL;
using DiabetesHelper.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserInterface
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<User?> GetByEmail(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(e => e.Email==email);
        }
    }
}
