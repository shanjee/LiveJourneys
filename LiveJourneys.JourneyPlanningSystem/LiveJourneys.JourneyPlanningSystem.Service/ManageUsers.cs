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
        /// Constructs a new ManageUsers instance.
        /// </summary>
        /// <param name="repository">Repository based on IBasicRepository.</param>
        public ManageUsers(IBasicRepository<User> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="newUser">new user object</param>
        /// <returns>if value is greater than zero then object added success else failed.</returns>
        public async Task<int> CreateUser(User newUser)
        {
            if(newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User should not be null");
            }

            newUser.Password = HashPassword(newUser.Password);
            return await _repository.Create(newUser);
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
                throw new ArgumentNullException(nameof(username), "Username should not be null,empty or white-space");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), "Password should not be null,empty or white-space");
            }

            var userFromContext = _repository.GetAll().FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(HashPassword(password)));
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
                throw new ArgumentNullException(nameof(password), "Password should not be null,empty or white-space");
            }

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(password));
        }
    }
}
