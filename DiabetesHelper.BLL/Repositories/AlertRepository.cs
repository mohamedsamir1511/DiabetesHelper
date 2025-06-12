using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.DAL;
using DiabetesHelper.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Repositories
{
    public class AlertRepository:GenericRepository<Alert>,IAlertInterface
    {
        private readonly AppDbContext _appDbContext;
        public  AlertRepository(AppDbContext appDbContext):base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Alert>> GetByUserIdAsync(int userId)
        {
            return await _appDbContext.Alerts
            .Where(a=>a.UserId==userId)
            .ToListAsync();
        }
    }
}
