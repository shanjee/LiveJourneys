using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageLines
    {
        private readonly IUnitOfWork unitOfWork = null;

        public ManageLines(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Line> GetAllLines()
        {
            return unitOfWork.TrainLines.Get();
        }

        public int CreateLine(Line newLine)
        {
            unitOfWork.TrainLines.Add(newLine);
            return unitOfWork.Complete();
        }

        public int Update(Line line)
        {
            unitOfWork.TrainLines.Update(line);
            return unitOfWork.Complete();
        }

        public int Delete(Line line)
        {
            unitOfWork.TrainLines.Delete(line);
            return unitOfWork.Complete();
        }
    }
}
