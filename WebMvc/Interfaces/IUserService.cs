using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace WebMvc.Interfaces
{
    public interface IUserService
    {
        bool Login(string email, string password);
    }
}
