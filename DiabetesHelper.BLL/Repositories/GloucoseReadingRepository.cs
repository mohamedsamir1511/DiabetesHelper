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
    public class GloucoseReadingRepository : GenericRepository<GlucoseReading>, IGlucoseReadingInterface
    {
        private readonly AppDbContext _appDbContext;
        public GloucoseReadingRepository(AppDbContext appDbContext):base(appDbContext) 
        {
            _appDbContext = appDbContext;   
        }
        public async Task<IEnumerable<GlucoseReading>> GetByUserIdAsync(int userId)
        {
            return await _appDbContext.GlucoseReadings.Where(g=> g.UserId == userId).ToListAsync();

          
        }
    }
}
