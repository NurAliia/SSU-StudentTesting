using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sgu.StudentTesting.DAL
{
    public class QuestionDao : IQuestionDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentTestingDB"].ConnectionString;

        SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void AddQuestion(Question question)
        {
            string sqlExpression = "sp_InsertQuestion";
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                SqlParameter idSubject = new SqlParameter
                {
                    ParameterName = "@IDSubject",
                    Value = question.IdSubject
                };
                command.Parameters.Add(idSubject);
                             

                SqlParameter authorQuestion = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = question.Author
                };
                command.Parameters.Add(authorQuestion);

                SqlParameter textQuestion = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = question.Text
                };
                command.Parameters.Add(textQuestion);

                SqlParameter VariantsOfAnswersQuestion = new SqlParameter
                {
                    ParameterName = "@VariantsOfAnswers",
                    Value = question.VariantsOfAnswer
                };
                command.Parameters.Add(VariantsOfAnswersQuestion);

                SqlParameter themeQuestion = new SqlParameter
                {
                    ParameterName = "@Theme",
                    Value = question.Theme
                };
                command.Parameters.Add(themeQuestion);

                SqlParameter complexityQuestion = new SqlParameter
                {
                    ParameterName = "@Complexity",
                    Value = question.Complexity
                };
                command.Parameters.Add(complexityQuestion);

                SqlParameter scoreQuestion = new SqlParameter
                {
                    ParameterName = "@Score",
                    Value = question.Score
                };
                command.Parameters.Add(scoreQuestion);

                SqlParameter correctAnswerQuestion = new SqlParameter
                {
                    ParameterName = "@CorrectAnswer",
                    Value = question.CorrectAnswer
                };
                command.Parameters.Add(correctAnswerQuestion);

                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<Question> GetQuestionsByAuthor(int author)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sqlExpression = "sp_GetQuestionsByAuthor";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Author", author);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = (int)reader["IdQuestion"],
                        IdSubject = (int)reader["IdSubject"],
                        Text = (string)reader["Text"],
                        VariantsOfAnswer = (string)reader["VariantsOfAnswers"],
                        Theme = (int)reader["Theme"],
                        Complexity = (int)reader["Complexity"],
                        Score = (int)reader["Score"],
                        CorrectAnswer = (string)reader["CorrectAnswer"],
                        Accepted = (bool)reader["Accepted"]
                    };
                }
            }
        }

        public IEnumerable<Question> GetQuestionsByTheme(int idsubject, int theme)
        {
            using (SqlConnection connection = GetConnection())
            {
                string sqlExpression = "sp_GetQuestionByTheme";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDSubject", idsubject);
                command.Parameters.AddWithValue("@Theme", theme);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = (int)reader["Id"],
                        IdSubject = (int)reader["IdSubject"],
                        Author = (string)reader["Name"],
                        Date = (DateTime)reader["Date"],
                        Text = (string)reader["Text"],
                        VariantsOfAnswer = (string)reader["VariantsOfAnswers"],
                        Complexity = (int)reader["Complexity"],
                        Score = (int)reader["Score"],
                        CorrectAnswer = (string)reader["CorrectAnswer"],
                        Accepted = (bool)reader["Accepted"]
                    };
                }
            }
        }

        public Question GetQuestionById(int questionId)
        {
            string sqlExpression = "sp_GetQuestionById";
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDQuestion", questionId);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return new Question()
                        {
                            Id = (int)reader["IdQuestion"],
                            IdSubject = (int)reader["IdSubject"],
                            Text = (string)reader["Text"],
                            VariantsOfAnswer = (string)reader["VariantsOfAnswers"],
                            Theme = (int)reader["Theme"],
                            Complexity = (int)reader["Complexity"],
                            Score = (int)reader["Score"],
                            CorrectAnswer = (string)reader["CorrectAnswer"]
                        };
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception($"Question changing was failed | Arguments: userId='{questionId}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
        public IEnumerable<Question> ListNewQuestion()
        {
            string sqlExpression = "sp_GetNotAcceptedQuestions";
            using (var connectionString = GetConnection())
            {
                connectionString.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connectionString);
                command.CommandType = CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Question()
                    {
                        Id = (int)reader["IdQuestion"],
                        IdSubject = (int)reader["IdSubject"],
                        Author = (string)reader["Name"],
                        Date = (DateTime)reader["Date"],
                        Text = (string)reader["Text"],
                        VariantsOfAnswer = (string)reader["VariantsOfAnswers"],
                        Theme = (int)reader["Theme"],
                        Complexity = (int)reader["Complexity"],
                        Score = (int)reader["Score"],
                        CorrectAnswer = (string)reader["CorrectAnswer"]
                    };
                }
            }

        }
        public void Update(Question question)
        {
            string sqlExpression = "sp_UpdateQuestion";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDQuestion", question.Id);
                command.Parameters.AddWithValue("@IDSubject", question.IdSubject);
                command.Parameters.AddWithValue("@Author", question.Author);
                command.Parameters.AddWithValue("@Text", question.Text);
                command.Parameters.AddWithValue("@VariantsOfAnswers", question.VariantsOfAnswer);
                command.Parameters.AddWithValue("@Theme", question.Theme);
                command.Parameters.AddWithValue("@Complexity", question.Complexity);
                command.Parameters.AddWithValue("@Score", question.Score);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception($"Question changing was failed | Arguments: userId='{question.Id}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
      

        public void Accepted(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("[sp_AcceptedQuestion]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDQuestion", id);
                connection.Open();
                command.ExecuteNonQuery();             
            }
        }

        public void DeleteById(int idQuestion)
        {
            string sqlExpression = "sp_DeleteQuestion";
            using (var connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idStudent = new SqlParameter
                {
                    ParameterName = "@IDQuestion",
                    Value = idQuestion
                };
                command.Parameters.Add(idStudent);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception($"Question deleting was failed | Arguments: questionId='{idQuestion}' | Source place: {this.ToString()} | Source method: {e.TargetSite}");
                }
            }
        }
    }
}
