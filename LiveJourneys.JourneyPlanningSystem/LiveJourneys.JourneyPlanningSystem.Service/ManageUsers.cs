using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageUsers
    {
        private readonly IUnitOfWork unitOfWork = null;

        /// <summary>
        /// Constructs a new ManageUsers instance.
        /// </summary>
        /// <param name="repository">Repository based on IBasicRepository.</param>
        public ManageUsers(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="newUser">new user object</param>
        /// <returns>if value is greater than zero then object added success else failed.</returns>
        public int CreateUser(User newUser)
        {
            if(newUser == null)
            {
                throw new ArgumentException("User should not be null");
            }

            if (string.IsNullOrWhiteSpace(newUser.UserName))
            {
                throw new ArgumentException("Username should not be null,empty or white-space");
            }

            if (string.IsNullOrWhiteSpace(newUser.Password))
            {
                throw new ArgumentException("Password should not be null,empty or white-space");
            }

            var result = unitOfWork.Users.Get(u=> u.UserName.Equals(newUser.UserName));

            if(result.Count() > 0)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            newUser.Password = HashPassword(newUser.Password);
            unitOfWork.Users.Add(newUser);
            return unitOfWork.Complete();
        }

        /// <summary>
        /// Verify the User credenticials.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>if value is greater than zero then object added success else failed.</returns>
        public User VerifyUser(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username should not be null,empty or white-space");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password should not be null,empty or white-space");
            }

            password = HashPassword(password);
            var userFromContext = unitOfWork.Users.Get( filter:u => u.UserName.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
            return userFromContext;
        }

        /// <summary>
        /// Hash the password. it is simple solution but not stong way to hash the password.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>The string representation, in base 64.</returns>
        private string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password should not be null,empty or white-space");
            }

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
        }
    }
}
