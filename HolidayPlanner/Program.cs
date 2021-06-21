using System;

namespace HolidayPlanner
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Holiday Planner\r");
            Console.WriteLine("**************************\n");

            HolidayCalculator calculator = new HolidayCalculator();
            Validators validator = new Validators();

            DateTime startDate;
            DateTime endDate;


            while (!endApp)
            {
                string dateInput = "";

                Console.Write("Enter the start date of your holiday: ");

                while (!validator.ValidateStartDate(dateInput = Console.ReadLine(), out startDate, out string error))
                {
                    Console.Write(error);
                }

                Console.Write("Enter the end date of your holiday: ");

                while (!validator.ValidateEndDate(dateInput = Console.ReadLine(), startDate, out endDate, out string error))
                {
                    Console.Write(error);
                }

                try
                {
                    var result = calculator.CalculateUsedDays(startDate, endDate);
                    Console.WriteLine("Holidays spent during this time span: " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ocurred.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
