using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Code created by: Anders Sundin olsu2201@student.miun.se HT-23.
namespace tipCalculator
{
    internal class CalculateTip
    {
        // Declare private variables
        private double bill;
        private int splitBy;
        private int percent;

        // Create a constructor to set values
        public CalculateTip(double bill, int persons, int percent)
        {
            this.bill = bill;
            this.splitBy = persons;
            this.percent = percent;
        }

        // Make methods to create calculations
        public double calcNoteSplit ()
        {
            double noteSplit = (this.bill / this.splitBy);
            return noteSplit;
        }
        public double calcPercentage()
        {
            double noteSplit = (this.bill / this.splitBy);
            double percentageAmount = ((double)this.percent / 100) * noteSplit;
            return percentageAmount;
        }

    }
}
