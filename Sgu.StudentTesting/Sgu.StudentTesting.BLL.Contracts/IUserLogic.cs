using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL.Contracts
{
    public interface IUserLogic
    {
        int AddUser(User student);
        IEnumerable<User> GetStudents(int id);
        User GetUserByEMail(string email);
        User GetUserById(int id);
        User GetUserByIdFull(int id);
        void RequestRights(int idUser);
        IEnumerable<User> ListRequestRights();
        int GetRoleUser(int idUser);
        void DeleteRequestRights(int idUser);
        void Update(User student);
        void Delete(int idUser);
        void DeleteLinkUniver(int idUser, int idDirection);
        User CheckLoginUser(string login, string password);
    }
}
