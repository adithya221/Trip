using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripExpenses.Model;

namespace TripExpenses
{
    interface ITripRepository
    {
        List<Trip> LoadTrips();
        void SaveTrips(List<Trip> Trips);
    }
}
