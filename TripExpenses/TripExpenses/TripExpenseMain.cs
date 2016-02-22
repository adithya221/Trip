using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripExpenses.Model;

namespace TripExpenses
{
    class TripExpenseMain
    {
        static void Main(string[] args)
        {
            TripManager tripManager = new TripManager();
            FileTripRepository fileTripRepository = new FileTripRepository();

            Console.Clear();

            Console.WriteLine("TRIP EXPENSES");
            Console.WriteLine();
            do
            {
                Console.WriteLine("1 Add Trip Details\n2 Display Trip Details\n3 Add Expense To Existing Trip\n4 Remove Trip\n5 Remove Expense\n6 List Of Trips\n7 Exit");
                Console.WriteLine("\nSelect Any Option");

                int ch = Convert.ToInt16(Console.ReadLine());
                Console.Clear();

                switch (ch)
                {
                    case 1:
                        tripManager.CreateTrip();
                        break;
                    case 2:
                        tripManager.DisplayTrip();
                        break;
                    case 3:
                        tripManager.AddExpenseToExistingTrip();
                        break;
                    case 4:
                        tripManager.RemoveTrip();
                        break;
                    case 5:
                        tripManager.RemoveExpense();
                        break;
                    case 6:
                        tripManager.ListOfTrips();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Please Select A valid Option");
                        break;
                }

            } while (true);
            
        }
    }
}
