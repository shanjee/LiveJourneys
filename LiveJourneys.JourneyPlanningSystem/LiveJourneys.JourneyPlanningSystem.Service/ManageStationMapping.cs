using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageStationMapping
    {
        private IUnitOfWork unitOfWork = null;

        public ManageStationMapping(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int CreateStationMapping(StationMapping newStationMapping)
        {
            if (newStationMapping == null)
            {
                throw new ArgumentException("StationMapping should not be null");
            }

            if (newStationMapping.LineId <= 0)
            {
                throw new ArgumentException("Invalid Train Line. Train Id value is missing");
            }

            if (newStationMapping.FromStaionId <= 0)
            {
                throw new ArgumentException("Invalid From station. Station Id value is missing");
            }

            if (newStationMapping.ToStationId <= 0)
            {
                throw new ArgumentException("Invalid To station. Station Id value is missing");
            }

            if (newStationMapping.ToStationId == newStationMapping.FromStaionId)
            {
                throw new ArgumentException("From and To Station not be same.");
            }

            if (newStationMapping.Distance > 50 || newStationMapping.Distance <= 0)
            {
                throw new ArgumentException("Invalid Distance. Distance Should not exceed 50 but greater than 0.");
            }

            if(AnyStationMappingExist(newStationMapping))
            {
                throw new InvalidOperationException("Station Mapping already exists.");
            }

            unitOfWork.StationMappings.Add(newStationMapping);
            return unitOfWork.Complete();
        }

        public bool AnyStationMappingExist(StationMapping stationMapping)
        {
            if(stationMapping == null)
            {
                throw new ArgumentException("StationMapping should not be null");
            }

            bool isAnyStation = false;
            var reuslt = unitOfWork.StationMappings.Get(filter: sM => sM.LineId == stationMapping.LineId 
                                                && sM.ToStationId == stationMapping.ToStationId 
                                                && sM.FromStaionId == stationMapping.FromStaionId);

            if(reuslt.Count() > 0)
            {
                isAnyStation = true;
            }

            return isAnyStation;
        }
    }
}
