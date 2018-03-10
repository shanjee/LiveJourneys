using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageUserTypes
    {
        private readonly IBasicRepository<UserType> _repository = null;

        public ManageUserTypes(IBasicRepository<UserType> repository)
        {
            this._repository = repository;
        }

        public IQueryable<UserType> GetAllTypes()
        {
            return _repository.GetAll();
        }
    }
}
