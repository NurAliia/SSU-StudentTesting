using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL
{
    public class SubjectDao : ISubjectDao
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["StudentTestingDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public void AddSubject(Subject subject)
        {

            string sqlExpression = "sp_InsertSubject";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                SqlParameter nameSubject = new SqlParameter
                {
                    ParameterName = "@NameSubject",
                    Value = subject.NameSubject
                };
                command.Parameters.Add(nameSubject);

                SqlParameter idDirection = new SqlParameter
                {
                    ParameterName = "@IdDirection",
                    Value = subject.IdDirection
                };
                command.Parameters.Add(idDirection);

                SqlParameter duration = new SqlParameter
                {
                    ParameterName = "@Duration",
                    Value = subject.Duration
                };
                command.Parameters.Add(duration);
                command.ExecuteNonQuery();
            }
        }
        public Subject GetSubjectById(int id)
        {
            string sqlExpression = "sp_GetSubjectById";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDSubject", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Subject()
                    {
                        IdSubject = (int)reader["IDSubject"],
                        NameSubject = (string)reader["NameSubject"],
                        IdDirection = (int)reader["IDDirection"],
                        Duration = (int)reader["Duration"]
                    };
                }
                return null;
            }
        }

        public IEnumerable<Question> GetQuestionBySubject(int idSubject)
        {
            string sqlExpression = "sp_GetQuestionBySubject";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDSubject", idSubject);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = (int)reader["IdQuestion"],
                        IdSubject = (int)reader["IdSubject"],
                        Text = (string)reader["Text"],
                        VariantsOfAnswer = (string)reader["VariantsOfAnswers"],
                        Complexity = (int)reader["Complexity"],
                        Score = (int)reader["Score"],
                        CorrectAnswer = (string)reader["CorrectAnswer"]
                    };
                }
            }
        }
        public IEnumerable<Subject> GetSubjectsStudent(int idUser)
        {
           string sqlExpression = "sp_GetSubjectByStudent";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
           
                command.Parameters.AddWithValue("@IDUser", idUser);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Subject()
                    {
                        IdSubject = (int)reader["IdSubject"],
                        NameSubject = (string)reader["NameSubject"],
                        Duration = (int)reader["Duration"]
                    };
                }
            }
        }
        public IEnumerable<string> GetListTheme(int idsubject)
        {
            string sqlExpression = "sp_GetTestBySubject";

            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDSubject", idsubject);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return (string)reader["IDSubject"];
                }
            }
        }
    }
}
