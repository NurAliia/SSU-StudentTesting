using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Sgu.StudentTesting.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddUser(User user)
        {

            byte[] data = user.Password.Select(x => (byte)x).ToArray();
            byte[] result;
            using (SHA512 shaM = SHA512.Create())
            {
                result = shaM.ComputeHash(data);
            }

            return _userDao.AddUser(user, result.ToList());
        }        
            
        public IEnumerable<User> GetStudents(int id)
        {
            //try
            //{
                if (_userDao.GetStudents(id).ToList().Count < 1)
                {
                    throw new Exception($"AAHHAHAHAHHAH list of users wasn't found ");
                }
                else
                {
                    return _userDao.GetStudents(id).ToList();
                }
            //}
            //catch (Exception e)
            //{
            //    throw new Exception($"Required list of users wasn't found | Arguments: null | Source place: {this.ToString()} | Source method: {e.TargetSite}");
            //}
                     
        }
        public User GetUserByEMail(string email)
        {
            return _userDao.GetUserByEMail(email);
        }
        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }
        public User GetUserByIdFull(int id)
        {
            return _userDao.GetUserByIdFull(id);            
        }

        public void RequestRights(int idUser)
        {
            _userDao.RequestRights(idUser);
        }
        public IEnumerable<User> ListRequestRights()
        {
            return _userDao.ListRequestRights();
        }
        public void DeleteRequestRights(int idUser)
        {
            _userDao.DeleteRequestRights(idUser);
        }
        public int GetRoleUser(int idUser)
        {
            return _userDao.GetRoleUser(idUser);
        }


        public void Update(User user)
        {
            _userDao.Update(user);
        }
        public void Delete(int idUser)
        {
            _userDao.Delete(idUser);
        }
        public void DeleteLinkUniver(int idUser, int idDirection)
        {
            _userDao.DeleteLinkUniver(idUser, idDirection);
        }
        public User CheckLoginUser(string login, string password)
        {
            byte[] data = password.Select(x => (byte)x).ToArray();
            byte[] result;
            using (SHA512 shaM = SHA512.Create())
            {
                result = shaM.ComputeHash(data);
            }
            return _userDao.CheckLoginUser(login, result.ToList());
        }
    }
}