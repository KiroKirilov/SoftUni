using System;
using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Sales = new List<Sale>();
            this.PartsCars = new List<PartCar>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<PartCar> PartsCars { get; set; }
    }
}
