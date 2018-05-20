using Common;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Configuration;


namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface IUserDao
    {
        int AddUser(User student, List<byte> password);
        IEnumerable<User> GetStudents(int id);
        User GetUserByEMail(string email);
        User GetUserById(int id);
        User GetUserByIdFull(int id);
        void RequestRights(int idUser);
        IEnumerable<User> ListRequestRights();
        void DeleteRequestRights(int idUser);
        int GetRoleUser(int idUser);
        void Update(User student);
        void Delete(int idUser);
        void DeleteLinkUniver(int idUser, int idDirection);
        User CheckLoginUser(string login, List<byte> password);
    }
}
