using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpense
{
    public class Program
    {
        private static string w,x,y,z;
        static void Main(string[] args)
        {


            do {
                
                   restart: Console.WriteLine("Trip Expenses");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("1. Add a Trip");
                    Console.WriteLine("2. Display your Trip");
                    Console.WriteLine("3. Add an expence to your Trip");
                    Console.WriteLine("4. Exit");
                    int a = Convert.ToInt32(Console.ReadLine());
                    if (a == 1)
                    {
                        Console.WriteLine("Add a Trip");
                        Console.WriteLine("Where did you Go?");
                        w = Console.ReadLine();
                        Console.WriteLine("Describe your Trip.");
                        x = Console.ReadLine();
                        Console.WriteLine("When did your Trip Start");
                        y = Console.ReadLine();
                        Console.WriteLine("When did your Trip End");
                        z = Console.ReadLine();
                    Console.WriteLine("Do you want to add Expense now? Yes/No");
                   string Option = Console.ReadLine();
                    if(Option.Equals("Yes"))
                    {
                        Console.WriteLine("What's your Expense Name?");
                        string ExpenceName = Console.ReadLine();
                        Console.WriteLine("What's your Expense Type");
                        string ExpenceType = Console.ReadLine();
                      Console.WriteLine("1. Fuel\n 2. Food\n3. Accomodation\n4. Travel");
                        int ch=0,Food=0,Fuel=0,Accomodation=0,Travel=0;
                        switch (ch)
                        {
                            case 1:
                                Console.WriteLine("Fuel Expence\n Enter the amount you Spend for Fuel: ");
                                Fuel = Console.Read();
                                break;
                            case 2:
                                Console.WriteLine("Food Expence\n Enter the amount you Spend for Food: ");
                                Food = Console.Read();
                                break;
                            case 3:
                                Console.WriteLine("Accomodation Expence\n Enter the amount you Spend for Accomodation: ");
                                Accomodation = Console.Read();
                                break;
                            case 4:
                                Console.WriteLine("Travel Expence\n Enter the amount you Spend for Traveling: ");
                                Travel = Console.Read();
                                break;
                            //default: Console.WriteLine("Invalid Input");
                            //    goto abc;
                        }
                        int Total = Food + Accomodation + Travel + Fuel;
                        Console.WriteLine("You had spend" + Total + "amount of money");

                    }
                    else if(Option.Equals("No"))
                    {
                        goto restart;
                    }
                    
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine(w);
                        Console.WriteLine(x);
                        Console.WriteLine(y);
                        Console.WriteLine(z);
                    }
                    else if (a == 3)
                    {

                    }
                    else
                    {
                    break;
                    }
                } while (true) ;
            }
    }
}
