using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        //Method to register user details
        UserDetails Registration(UserRegistration user);
    }
}
