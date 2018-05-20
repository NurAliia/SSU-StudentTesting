using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace Sgu.StudentTesting.DAL
{
    public class UserDao : IUserDao
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["StudentTestingDB"].ConnectionString;
        
        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
              

        public int AddUser(User user, List<byte> password)
        {
            string sqlExpression = "sp_InsertUser";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                                
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };                
                command.Parameters.Add(nameParam);

                SqlParameter surNameParam = new SqlParameter
                {
                    ParameterName = "@SurName",
                    Value = user.SurName
                };
                command.Parameters.Add(surNameParam);

                SqlParameter patronymicParam = new SqlParameter
                {
                    ParameterName = "@Patronymic",
                    Value = user.Patronymic
                };
                command.Parameters.Add(patronymicParam);

                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@EMail",
                    Value = user.EMail
                };
                command.Parameters.Add(mailParam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = password.ToArray()
                };
                command.Parameters.Add(passwordParam);

                SqlParameter cityParam = new SqlParameter
                {
                    ParameterName = "@IDCity",
                    Value = user.City
                };
                command.Parameters.Add(cityParam);

                SqlParameter universityParam = new SqlParameter
                {
                    ParameterName = "@IDUniversity",
                    Value = user.University
                };
                command.Parameters.Add(universityParam);

                SqlParameter facultyParam = new SqlParameter
                {
                    ParameterName = "@IDFaculty",
                    Value = user.Faculty
                };
                command.Parameters.Add(facultyParam);

                SqlParameter directionParam = new SqlParameter
                {
                    ParameterName = "@IDDirection",
                    Value = user.Direction
                };
                command.Parameters.Add(directionParam);
                
                var reader = command.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader["@IdUser"];
                }
                return id;                
            }
        }
             

        public IEnumerable<User> GetStudents(int id)
        {
            string sqlExpression = "sp_GetStudents";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter universityParam = new SqlParameter
                {
                    ParameterName = "@IDTeacher",
                    Value = id
                };
                command.Parameters.Add(universityParam);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    { 
                        Id = (int)reader["IdUser"],
                        Name = (string)reader["Name"],
                        SurName = (string)reader["SurName"],
                        Patronymic = (string)reader["Patronymic"],
                        City = (string)reader["NameCity"],
                        University = (string)reader["NameUniversity"],
                        Faculty = (string)reader["NameFaculty"],
                        Direction = (int)reader["IdDirection"],
                        EMail = (string)reader["EMail"]
                    };                        
                }                   
            }
        }
        public User GetUserByEMail(string email)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetUserByEMail", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EMail", email);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = (int)reader["IdUser"],
                            Name = (string)reader["Name"],
                            SurName = (string)reader["SurName"],
                            Patronymic = (string)reader["Patronymic"],
                            EMail = (string)reader["EMail"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Required student wasn't found | Arguments: email='{email}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }


        public User GetUserByIdFull(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetUserByIdFull", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDUser", id);
                //try
                //{
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = id,
                            Name = reader["Name"] as string,
                            SurName = (string)reader["SurName"],
                            Patronymic = (string)reader["Patronymic"],
                            EMail = (string)reader["EMail"],
                            City = (string)reader["NameCity"],
                            University = (string)reader["NameUniversity"],
                            Faculty = (string)reader["NameFaculty"],
                            Direction = (int)reader["IdDirection"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                //}
                //catch (Exception e)
                //{
                //    throw new Exception($"Required user wasn't found | Arguments: userId='{id}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                //}
            }
        }
        public User GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDUser", id);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User()
                        {
                            Id = id,
                            Name = reader["Name"] as string,
                            SurName = reader["SurName"] as string,
                            Patronymic = reader["Patronymic"] as string,
                            EMail = reader["EMail"] as string
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Required student wasn't found | Arguments: userId='{id}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public void RequestRights(int idUser)
        {
            string sqlExpression = "sp_AddReaffirmationRight";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<User> ListRequestRights()
        {
            string sqlExpression = "sp_GetReaffirmationRight";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        Id = (int)reader["IdUser"],
                        Name = (string)reader["Name"],
                        SurName = (string)reader["SurName"],
                        Patronymic = (string)reader["Patronymic"],
                        City = (string)reader["NameCity"],
                        University = (string)reader["NameUniversity"],
                        Faculty = (string)reader["NameFaculty"],
                        Direction = (int)reader["IdDirection"],
                        EMail = (string)reader["EMail"]
                    };
                }
            }
        }
        public void DeleteRequestRights(int idUser)
        {
            string sqlExpression = "sp_DeleteReaffirmationRight";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }
        public int GetRoleUser(int idUser)
        {
            string sqlExpression = "sp_GetUserRole";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idUserParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (int)reader["IdRole"];
                }
                return 0;
            }
        }
        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("[sp_UpdateUser]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@SurName", user.SurName);
                command.Parameters.AddWithValue("@MiddleName", user.Patronymic);
                command.Parameters.AddWithValue("@Mail", user.EMail);
                command.Parameters.AddWithValue("@Password", user.Password);               
            }
        }
        public void Delete(int id)
        {
            string sqlExpression = "sp_DeleteUser";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idStudent = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = id
                };
                command.Parameters.Add(idStudent);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteLinkUniver(int idUser, int idDirection)
        {
            string sqlExpression = "sp_DeleteUniver";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@IDUser",
                    Value = idUser
                };
                command.Parameters.Add(idUserParam);

                SqlParameter idDirectionParam = new SqlParameter
                {
                    ParameterName = "@IDDirection",
                    Value = idDirection
                };
                command.Parameters.Add(idDirectionParam);

                command.ExecuteNonQuery();
            }
        }
        public User CheckLoginUser(string login, List<byte> password)
        {
            string sqlExpression = "sp_LoginUser";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter loginUserParam = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login
                };
                command.Parameters.Add(loginUserParam);

                SqlParameter passwordUserParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = password.ToArray()
                };
                command.Parameters.Add(passwordUserParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User()
                    {
                        Id = (int)reader["IdUser"]
                    };
                }
                else
                    return null;
            }
        }        
    }
}
