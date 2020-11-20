using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        //Method to register user details
        UserDetails Registration(UserRegistration user);

        //Method for user login
        UserDetails Login(UserLogin user);
    }
}
