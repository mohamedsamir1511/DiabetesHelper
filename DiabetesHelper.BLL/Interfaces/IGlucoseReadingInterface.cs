using DiabetesHelper.BLL.Repositories;
using DiabetesHelper.DAL;
using DiabetesHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Interfaces
{
   public interface IGlucoseReadingInterface:IGenericInterface<GlucoseReading>
    {
            Task<IEnumerable<GlucoseReading>> GetByUserIdAsync(int userId);

    }
}
