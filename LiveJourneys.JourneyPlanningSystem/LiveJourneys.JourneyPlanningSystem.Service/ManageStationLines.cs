using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageStationLines
    {
        private readonly IUnitOfWork unitOfWork = null;

        public ManageStationLines(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<StationLine> GetAllStationLines()
        {
            return unitOfWork.StationLines.Get();
        }

        public int CreateStationLine(StationLine newStationLine)
        {
            if (newStationLine == null)
            {
                throw new ArgumentNullException(nameof(newStationLine), "Station should not be null");
            }

            if (AnyStationExist(newStationLine.LineId,newStationLine.StationId))
            {
                throw new InvalidOperationException("Station Line mapping already exists.");
            }

            unitOfWork.StationLines.Add(newStationLine);
            return unitOfWork.Complete();
        }

        public int Update(StationLine stationLine)
        {
            if (stationLine == null)
            {
                throw new ArgumentNullException(nameof(stationLine), "StationLine should not be null");
            }

            if (stationLine.LineId <= 0)
            {
                throw new InvalidOperationException("Invalid train line. Line Id value is missing");
            }

            if (stationLine.StationId <= 0)
            {
                throw new InvalidOperationException("Invalid station. Station Id value is missing");
            }

            if (AnyStationExist(stationLine.LineId,stationLine.StationId))
            {
                throw new InvalidOperationException("Station Line mapping already exists.");
            }

            unitOfWork.StationLines.Update(stationLine);
            return unitOfWork.Complete();
        }

        public int Delete(StationLine stationLine)
        {
            if (stationLine == null)
            {
                throw new ArgumentNullException(nameof(stationLine), "StationLine should not be null");
            }

            if (stationLine.LineId <= 0)
            {
                throw new InvalidOperationException("Invalid train line. Line Id value is missing");
            }

            if (stationLine.StationId <= 0)
            {
                throw new InvalidOperationException("Invalid station. Station Id value is missing");
            }

            unitOfWork.StationLines.Delete(stationLine);
            return unitOfWork.Complete();
        }

        public StationLine GetStationLineByIds(int lineId, int stationId)
        {
            var stationLine = unitOfWork.StationLines.Get(filter: sL => sL.LineId == lineId && sL.StationId == stationId).FirstOrDefault();
            return stationLine;
        }

        public bool AnyStationExist(int lineId, int stationId)
        {
            bool isAnyStation = false;

            if (GetStationLineByIds(lineId,stationId) != null)
            {
                isAnyStation = true;
            }

            return isAnyStation;
        }
    }
}
