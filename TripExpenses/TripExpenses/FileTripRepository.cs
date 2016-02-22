using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TripExpenses.Model;
using System.Xml.Serialization;

namespace TripExpenses
{
    class FileTripRepository:ITripRepository
    {
        string path = @"H:\Visual Studio Projects\Trip\TripExpenses\TripExpenses\SavedTrips.txt";

        /*--------Save Trip--------*/
        public void SaveTrips(List<Trip> trips)
        {
            var serializer = new XmlSerializer(typeof(List<Trip>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, trips);
            }
        }

        public List<Trip>  LoadTrips()
        {
            var trips = new List<Trip>();
            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(List<Trip>));
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    trips = (List<Trip>)serializer.Deserialize(stream);
                }                
            }
            return trips;
        }
    }
}
