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
            if(newLine == null)
            {
                throw new ArgumentNullException(nameof(newLine), "Train line should not be null");
            }

            if(AnyLineExist(newLine.Name))
            {
                throw new InvalidOperationException("Train Line already exists.");
            }

            unitOfWork.TrainLines.Add(newLine);
            return unitOfWork.Complete();
        }

        public int Update(Line line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line), "Train line should not be null");
            }

            if (line.Id <= 0)
            {
                throw new InvalidOperationException("Invalid train line. Find correct train line.");
            }

            if (AnyLineExist(line.Name))
            {
                throw new InvalidOperationException("Train Line already exists.");
            }

            unitOfWork.TrainLines.Update(line);
            return unitOfWork.Complete();
        }

        public int Delete(Line line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line), "Train line should not be null");
            }

            unitOfWork.TrainLines.Delete(line);
            return unitOfWork.Complete();
        }

        public Line GetLineByName(string lineName)
        {
            if (string.IsNullOrWhiteSpace(lineName))
            {
                throw new ArgumentException("Train line name should not be null or empty");
            }

            var line = unitOfWork.TrainLines.Get(filter:l => l.Name.Equals(lineName)).FirstOrDefault();
            return line;
        }

        public bool AnyLineExist(string lineName)
        {
            if (string.IsNullOrWhiteSpace(lineName))
            {
                throw new ArgumentException("Train line name should not be null or empty");
            }

            bool isAnyLine = false;

            if(GetLineByName(lineName) != null)
            {
                isAnyLine = true;
            }

            return isAnyLine;
        }
    }
}
