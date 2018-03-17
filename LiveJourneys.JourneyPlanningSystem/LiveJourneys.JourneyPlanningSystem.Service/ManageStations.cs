using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Business
{
    public class ManageStations
    {
        private readonly IUnitOfWork unitOfWork = null;

        public ManageStations(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Station> GetAllStations()
        {
            return unitOfWork.Stations.Get();
        }

        public int CreateStation(Station newStation)
        {
            if (newStation == null)
            {
                throw new ArgumentNullException(nameof(newStation), "Station should not be null");
            }

            if (AnyStationExist(newStation.Name))
            {
                throw new InvalidOperationException("Station already exists.");
            }

            unitOfWork.Stations.Add(newStation);
            return unitOfWork.Complete();
        }

        public int Update(Station station)
        {
            if (station == null)
            {
                throw new ArgumentNullException(nameof(station), "Station should not be null");
            }

            if (station.Id <= 0)
            {
                throw new InvalidOperationException("Invalid station. Station Id value is missing");
            }

            if (AnyStationExist(station.Name))
            {
                throw new InvalidOperationException("Station already exists.");
            }

            unitOfWork.Stations.Update(station);
            return unitOfWork.Complete();
        }

        public int Delete(Station station)
        {
            if (station == null)
            {
                throw new ArgumentNullException(nameof(station), "Station should not be null");
            }

            if (station.Id <= 0)
            {
                throw new InvalidOperationException("Invalid station. Station Id value is missing");
            }

            unitOfWork.StationLines.DeleteRange(station.StationLines);
            unitOfWork.StationMappings.DeleteRange(station.FromStationMappings);
            unitOfWork.StationMappings.DeleteRange(station.ToStationMappings);
            unitOfWork.Stations.Delete(station);
            return unitOfWork.Complete();
        }

        public Station GetStationByName(string stationName)
        {
            if (string.IsNullOrWhiteSpace(stationName))
            {
                throw new ArgumentException("Station name should not be null or empty");
            }

            var station = unitOfWork.Stations.Get(filter: s => s.Name.Equals(stationName)).FirstOrDefault();
            return station;
        }

        public bool AnyStationExist(string stationName)
        {
            if (string.IsNullOrWhiteSpace(stationName))
            {
                throw new ArgumentException("Station name should not be null or empty");
            }

            bool isAnyStation = false;

            if (GetStationByName(stationName) != null)
            {
                isAnyStation = true;
            }

            return isAnyStation;
        }

        public ICollection<Station> GetStationsByLineId(int lineId)
        {
            return unitOfWork.StationLines.Get(filter: s => s.LineId == lineId,includeProperties: "Station")
                        .Select(s=> s.Station).ToList();
        }
    }
}
