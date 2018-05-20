using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL
{
    public class TestDao : ITestDao
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["StudentTestingDB"].ConnectionString;

       
        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public void AddTest(Test test)
        {
            string sqlExpression = "sp_InsertTest";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idSubject = new SqlParameter
                {
                    ParameterName = "@IDSubject",
                    Value = test.IdStubject
                };
                command.Parameters.Add(idSubject);
                SqlParameter idStudent = new SqlParameter
                {
                    ParameterName = "@IDStudent",
                    Value = test.IdSudent
                };
                command.Parameters.Add(idStudent);
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = test.Date
                };
                command.Parameters.Add(date);
                SqlParameter result = new SqlParameter
                {
                    ParameterName = "@Result",
                    Value = test.Result
                };
                command.Parameters.Add(result);
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<Test> GetStudentsBySubjectTest(int subjectId)
        {
            string sqlExpression = "sp_GetStudentsBySubjectTest";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDSubject", subjectId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Test()
                    {
                        IdTest = (int)reader["IdTest"],
                        Name = reader["Name"] as string,
                        SurName = reader["Surname"] as string,
                        Patronymic = reader["Patronymic"] as string,
                        Date = (DateTime)reader["Date"],
                        Result = (int)reader["Result"]
                    };
                }
            }
        }
        public IEnumerable<QuestionInTest> GetQuestionInTestBySubject(int IdTest)
        {
            string sqlExpression = "sp_GetQuestionInTestBySubject";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTest", IdTest);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new QuestionInTest()
                    {
                        Text = reader["Text"] as string,
                        VariantsOfAnswers = reader["VariantsOfAnswers"] as string,
                        Answer = (int)reader["Answer"]
                    };
                }
            }
        }

        public IEnumerable<Test> GetTestsStudent(int studentId)
        {
            string sqlExpression = "sp_GetTestByStudent";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDStudent", studentId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Test()
                    {
                        IdTest = (int)reader["IdTest"], 
                        NameSubject = (string)reader["NameSubject"],
                        Date = (DateTime)reader["Date"],
                        Result = (int)reader["Result"]                       
                    };
                }
            }
        }
           

        public IEnumerable<int> GetTestsSubject(int subjectId)
        {
            using (var connection = GetConnection())
            {
                string sqlExpression = "sp_GetTestBySubject";
                using (var connectionString = GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDSubject", subjectId);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        yield return (int)reader["IDTheme"];                        
                    }
                }
            }
        }
    }
}
