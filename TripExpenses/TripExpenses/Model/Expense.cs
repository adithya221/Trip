using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenses.Model
{
    public class Expense
    {
        public Expense()
        {
            Id = System.Threading.Interlocked.Increment(ref localId);       
        }
        static int localId = 0;
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public double Amount { get; set; }
    }
}
