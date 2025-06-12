using DiabetesHelper.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesHelper.BLL.Interfaces
{
   public interface IUserInterface:IGenericInterface<User>    
    {
        Task<User?>GetByEmail(string email);    

    }
}
