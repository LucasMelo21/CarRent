using System;
using System.Globalization;
using LearningInterfaces.Entities;
using LearningInterfaces.Services;

namespace LearningInterfaces
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter rental data:");
                Console.Write("Car model: ");
                string model = Console.ReadLine();
                Console.Write("Pickup (dd/MM/yyyy HH:ss): ");
                DateTime pickup = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:ss", CultureInfo.InvariantCulture);
                Console.Write("Return (dd/MM/yyyy HH:ss): ");
                DateTime returnal = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:ss", CultureInfo.InvariantCulture);

                Console.Write("Enter price per hour: ");
                double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter price per day: ");
                double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                CarRental carRental = new CarRental(pickup, returnal, new Vehicle(model));
                RentalService rentalService = new RentalService(hour, day);

                rentalService.ProcessInvoice(carRental);
                Console.Write("Invoice: ");
                Console.WriteLine(carRental.Invoice);
            }
            catch (Exception e) 
            {
                Console.WriteLine("An error ocurred!");
                Console.WriteLine(e.Message);

            }
        }
    }
}