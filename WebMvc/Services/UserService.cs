using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core;
using WebMvc.Interceptors;
using WebMvc.Interfaces;

namespace WebMvc.Services
{
   
    public class UserService: IUserService
    {
        public bool Login(string email, string password)
        {
            return true;
        }
    }
}