using TripExpenses.Model;

namespace TripExpenses
{
    public interface ITripManager
    {
        void CreateTrip();
        void DisplayTrip();
        void AddExpense();
        void AddExpenseToExistingTrip();
        void RemoveTrip();
        void RemoveExpense();
        void ListOfTrips();
    }
}
