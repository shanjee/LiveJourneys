using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageUserTypes
    {
        private readonly IUnitOfWork unitOfWork = null;

        public ManageUserTypes(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserType> GetAllTypes()
        {
            return unitOfWork.UserTypes.Get(orderBy:(u => u.OrderBy(o=> o.Type)));
        }
    }
}
