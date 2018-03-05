using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Service
{
    public class ManageUsers
    {
        private readonly IBasicRepository<User> _repository = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public ManageUsers(IBasicRepository<User> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<int> CreateUser(User newUser)
        {
            newUser.Password = HashPassword(newUser.Password);
            return await _repository.Create(newUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User VerifyUser(string userName, string password)
        {
            var userFromContext = _repository.GetAll().FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(HashPassword(password)));
            return userFromContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
        }
    }
}
