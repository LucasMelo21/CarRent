using System;
using LearningInterfaces.Entities;

namespace LearningInterfaces.Services {
    internal class RentalService {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }
        private BrazilTaxService BrazilTaxService = new BrazilTaxService();

        public RentalService() { }

        public RentalService(double pricePerHour, double pricePerDay) {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }
        public void ProcessInvoice(CarRental carRental) {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;
            if (duration.TotalHours <= 12){
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalDays);
            }

            double tax = BrazilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
