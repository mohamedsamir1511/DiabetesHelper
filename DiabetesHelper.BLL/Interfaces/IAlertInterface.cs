using DiabetesHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Interfaces
{
    public interface IAlertInterface:IGenericInterface<Alert>
    {
    
            Task<IEnumerable<Alert>> GetByUserIdAsync(int userId);
    }
}
