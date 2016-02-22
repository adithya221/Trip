using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TripExpenses.Model;


namespace TripExpenses
{
    class TripManager : ITripManager
    {
        FileTripRepository fileTripRepository = new FileTripRepository();

        private readonly List<Trip> trips;

        public TripManager()
        {
            trips = fileTripRepository.LoadTrips();
        }
    


    private DateTime CaptureDate(string title)
        {
            DateTime capDate;
        datecap:
            try
            {
                Console.WriteLine(title);
                capDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date entered");
                goto datecap;
            }

            return capDate;
        }

        /*--------Create Trip---------*/
        public void CreateTrip()
        {
            Trip trip = new Trip();
            Console.WriteLine("With what Name you want to call your Trip?");
            trip.TripName = Console.ReadLine();
            Console.WriteLine("Lets Describe About your Trip.");
            trip.Description = Console.ReadLine();
            trip.StartDate = CaptureDate("On which date started your Trip (dd-MM-yyyy)");
            trip.EndDate = CaptureDate("Your Trip End Date");

            /*-------------Expense details------------*/
            Console.WriteLine("Do you want to Add Expenses? (y/n)");
            while (Console.ReadLine().ToLower() == "y")
            {
                AddExpense(trip);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                Console.WriteLine("Do you want to add another Expense? (y/n)");
            }
            trips.Add(trip);

            Console.WriteLine("Trip Added Successfully, Your Trip id is: " + trip.Id);           
            DoYouWantToSave();
        }

        /*----------Display Trip----------*/
        public void DisplayTrip()
        {
            Console.WriteLine("Enter Trip Id you want to Display");
            int TripId = Convert.ToInt16(Console.ReadLine());
            foreach (var trip in trips)
            {
                if (TripId == trip.Id)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Trip Id: \t" + trip.Id);
                    Console.ResetColor();
                    Console.WriteLine("Name: \t" + trip.TripName);
                    Console.WriteLine("Desc: \t" + trip.Description);
                    Console.WriteLine("Start Date: \t" + trip.StartDate.ToString("dd-MM-yyyy"));
                    Console.WriteLine("End Date: \t" + trip.EndDate.ToString("dd-MM-yyyy"));
                    Console.WriteLine("=======================");
                    Console.WriteLine("Expenses");
                    Console.WriteLine("=======================");

                    foreach (var expense in trip.Expenses)
                    {
                        Console.WriteLine("Expense Name: \t" + expense.ExpenseName);
                        Console.WriteLine("Expense Type: \t" + expense.ExpenseType);
                        Console.WriteLine("Expense Amount: \t" + expense.Amount);
                    }
                    Console.WriteLine("Total Expenditure");
                    int y = Convert.ToInt32(trip.Expenses.Sum(x => x.Amount));
                    Console.Write("\t" + y);
                }
            }
            Console.ReadLine();


        }

        /*------New Expense-------*/
        public void AddExpense(Trip trip)
        {

            Console.Clear();
            Expense expense = new Expense();

            Console.WriteLine("enter expense Name");

            expense.ExpenseName = Console.ReadLine();

            Console.WriteLine("enter expense type");
            int i = 1;
            foreach (var item in Enum.GetNames(typeof(ExpenseType)))
            {
                Console.WriteLine(i + item);
                i++;
            }
            var option = Convert.ToInt16(Console.ReadLine());
            expense.ExpenseType = (ExpenseType)option;
            Console.WriteLine("Enter The Amount you Spend:");
            expense.Amount = Convert.ToDouble(Console.ReadLine());
            trip.Expenses.Add(expense);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Expense Added Your Expense id is: " + expense.Id);
            Console.ResetColor();
        }

        /*------------Add Expense to Existing Trip-----------*/
        public void AddExpenseToExistingTrip()
        {
            Console.WriteLine("Please input your Trip Id");
            int i = Convert.ToInt16(Console.ReadLine());
            foreach (var trip in trips)
            {
                if (i == trip.Id)
                {
                    AddExpense(trip);
                }
            }
            DoYouWantToSave();
        }

        /*------------Remmove Trip------------*/
        public void RemoveTrip()
        {
            Console.WriteLine("Please input your Trip Id");
            int i = Convert.ToInt16(Console.ReadLine());
            Trip tripToDelete = null;
            foreach (var trip in trips)
            {
                if (i == trip.Id)
                {
                    tripToDelete = trip;
                }

            }
            trips.Remove(tripToDelete);
            DoYouWantToSave();
        }

        /*------------Remmove Expense------------*/
        public void RemoveExpense()
        {
            Console.WriteLine("Please input your Trip Id");
            int tripId = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please input your Expense Id");
            int expId = Convert.ToInt16(Console.ReadLine());
            Expense expToDelete = null;
            foreach (var trip in trips)
            {
                if (tripId == trip.Id)
                {
                    foreach (var exp in trip.Expenses)
                    {
                        if (expId == exp.Id)
                        {
                            expToDelete = exp;
                        }
                    }
                    trip.Expenses.Remove(expToDelete);
                    DoYouWantToSave();
                }
            }
        }

        /*--------List Of Trips---------*/
        public void ListOfTrips()
        {
            foreach(var trip in trips)
            {
                Console.WriteLine("Trip Id: \t" + trip.Id);                
                Console.WriteLine("Name: \t" + trip.TripName);
            }
            
        }
        public void DoYouWantToSave()
        {
            Console.WriteLine("Do you Want to Save your Trip? (y/n)");
            string choice = Console.ReadLine();
            if(choice.ToLower()=="y")
            {
                fileTripRepository.SaveTrips(trips);
                Console.WriteLine("Saved Successfully");
            }
        }

        public void AddExpense()
        {
            throw new NotImplementedException();
        }

        
    }
}