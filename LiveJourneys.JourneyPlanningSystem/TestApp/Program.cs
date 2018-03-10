using LiveJourneys.JourneyPlanningSystem.Data;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            JourneyPlanningSystemDbContext context = new JourneyPlanningSystemDbContext();
            BasicEFRepository<StationMapping> basicEFRepository = new BasicEFRepository<StationMapping>(context);
            var dataList =  basicEFRepository.GetAll();

            foreach (var item in dataList)
            {
                Console.WriteLine($"{item.FromStaionId} - {item.Distance.ToString()}");
            }

            Console.ReadKey();

        }
    }
}
