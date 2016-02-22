using System;
using System.Collections.Generic;
using System.Threading;

namespace TripExpenses.Model
{
    public class Trip
    {
        public Trip()
        {
            Id = Interlocked.Increment(ref localid);

            Expenses = new List<Expense>();
        }
        static int localid = 0;
        public int Id { get; set; }
        public string TripName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Expense> Expenses { get; set; }
        public double TotalExpence { get; set; }
    }    
}
