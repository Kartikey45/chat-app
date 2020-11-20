using CommonLayer.UserModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        //Configuration initialized
        private readonly IConfiguration Configuration;

        //constructor 
        public UserRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public UserDetails Login(UserLogin user)
        {
            UserDetails details = new UserDetails();
            try
            {
                //Connection string declared
                string connect = Configuration.GetConnectionString("MyConnection");

                //Password encrypted
                string Password = EncryptedPassword.EncodePasswordToBase64(user.Password);

                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("UserLogin", Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);

                    //connection open 
                    Connection.Open();

                    //read data form the database
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    //While Loop For Reading status result from SqlDataReader.
                    while (reader.Read())
                    {
                        details.UserId = Convert.ToInt32(reader["id"].ToString());
                        details.FirstName = reader["FirstName"].ToString();
                        details.LastName = reader["LastName"].ToString();
                        details.Email = reader["Email"].ToString();
                        details.PhoneNumber = reader["PhoneNumber"].ToString();
                    }

                    //connection close 
                    Connection.Close();

                }
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Method to register user in the dataabase
        public UserDetails Registration(UserRegistration user)
        {
            UserDetails details = new UserDetails();
            try
            {
                //Connection string declared
                string connect = Configuration.GetConnectionString("MyConnection");

                //password encrypted
                string Password = EncryptedPassword.EncodePasswordToBase64(user.Password);
                DateTime createdDate;
                createdDate = DateTime.Now;

                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("UserRegistration", Connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                    //connection open 
                    Connection.Open();

                    // Read data form database
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //While Loop For Reading status result from SqlDataReader.
                    while (reader.Read())
                    {
                        details.UserId = Convert.ToInt32(reader["id"].ToString());
                        details.FirstName = reader["FirstName"].ToString();
                        details.LastName = reader["LastName"].ToString();
                        details.Email = reader["Email"].ToString();
                        details.PhoneNumber = reader["PhoneNumber"].ToString();
                    }

                    //connection close
                    Connection.Close();
                }
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
