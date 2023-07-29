using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates.Assignments
{
    public delegate double OptionalServiceDelegate(Dictionary<string, int> optionalService);
    public class User
    {
        private static int nextUserId = 7000;

        public int UserId { get; private set; }

        public User()
        {
            UserId = nextUserId++;
        }

        public void AvailExtraService(Ticket ticket, int cabKms, int noOfPersons, int extraBaggage)
        {
            OptionalServiceDelegate optionalServiceDelegate = null;

            if (cabKms > 0)
            {
                ticket.OptionalServices["CabKms"] = cabKms;
                optionalServiceDelegate += OptionalService.CabService;
            }

            if (noOfPersons > 0 && noOfPersons <= ticket.NoOfPassengers)
            {
                ticket.OptionalServices["Insurance"] = noOfPersons;
                optionalServiceDelegate += OptionalService.TravelInsurance;
            }

            if (extraBaggage > 0)
            {
                ticket.OptionalServices["ExtraBaggage"] = extraBaggage;
                optionalServiceDelegate += OptionalService.AdditionalBaggage;
            }

            if (optionalServiceDelegate != null)
            {
                optionalServiceDelegate += (optionalService) =>
                {
                    double processingFee = 0;

                    foreach (var kvp in optionalService)
                    {
                        if (kvp.Value > 0)
                        {
                            processingFee += 20;
                        }
                    }

                    return processingFee;
                };

                ticket.UpdateTotalFare(optionalServiceDelegate);
            }
        }
    }

    public static class OptionalService
    {
        public static double CabService(Dictionary<string, int> optionalService)
        {
            int cabKms = optionalService["CabKms"];
            double amount = Math.Max(100, cabKms * 20);
            return amount;
        }

        public static double TravelInsurance(Dictionary<string, int> optionalService)
        {
            int noOfPersons = optionalService["Insurance"];
            double amount = noOfPersons * 170;
            return amount;
        }

        public static double AdditionalBaggage(Dictionary<string, int> optionalService)
        {
            int extraBaggage = optionalService["ExtraBaggage"];
            int numberOfPieces = (int)Math.Ceiling(extraBaggage / 25.0);
            double amount = numberOfPieces * 4000;
            return amount;
        }
    }

    public class Ticket
    {
        private static int nextTicketNumber = 10000;

        public Ticket(string from, string to, int noOfPassengers, double fare)
        {
            From = from;
            To = to;
            NoOfPassengers = noOfPassengers;
            TicketNumber = nextTicketNumber++;
            TotalFare = fare;
            OptionalServices = new Dictionary<string, int>
            {
                { "CabKms", 0 },
                { "Insurance", 0 },
                { "ExtraBaggage", 0 }
            };
        }

        public string From { get; }
        public string To { get; }
        public int NoOfPassengers { get; }
        public long TicketNumber { get; }
        public double TotalFare { get; private set; }
        public Dictionary<string, int> OptionalServices { get; set; }

        public void UpdateTotalFare(OptionalServiceDelegate optionalServiceDelegate)
        {
            if (optionalServiceDelegate != null)
            {
                TotalFare += optionalServiceDelegate(OptionalServices);
            }
        }

    }

    public class DelAssignment4
    {
        public static void Main()
        {
            Ticket ticket = new Ticket("New York", "Los Angeles", 3, 1500);
            User user = new User();
            user.AvailExtraService(ticket, cabKms: 25, noOfPersons: 2, extraBaggage: 55);

            Console.WriteLine("Ticket Number: " + ticket.TicketNumber);
            Console.WriteLine("Total Fare: $" + ticket.TotalFare);
        }
    }
}
