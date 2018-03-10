using LiveJourneys.JourneyPlanningSystem.Data.Repository;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageLines
    {
        private IBasicRepository<Line> _repository = null;

        public ManageLines(IBasicRepository<Line> repository)
        {
            _repository = repository;
        }

        public IQueryable<Line> GetAllLines()
        {
            return _repository.GetAll();
        }

        public async Task<Line> CreateLine(Line newLine)
        {
            return await _repository.Create(newLine);
        }
    }
}
