using System;
using System.Collections;

namespace _01_Complete
{
    public interface IIoyaltyCardHolder
    {
        int TotalPoints { get; }
        int AddPoints(decimal transactionValue);
        void ResetPoints();
    }
    public class CustomerRS : IIoyaltyCardHolder
    {
        private int totalPoints;
        public int TotalPoints { get { return totalPoints; } }
        // Todo: Error 4-13
        public int AddPoints(decimal transactionValue)
        {
            int points = Decimal.ToInt32(transactionValue);
            totalPoints += points;
            return points;
        }

        public void ResetPoints()
        {
            totalPoints = 0;
        }
    }
    public interface IBeverage
    {
        int GetServingTemperature(bool includesMilk);
        bool IsFairTrafe { get; set; }
    }
    public class CoffeI : IBeverage, IComparable, IComparer
    {
        public bool IsFairTrafe { get; set; }
        //bool IBeverage.IsFairTrafe { get; set; }
        public int servingTempWithoutMilk { get; set; }
        public int servingTempWithMilk { get; set; }
        public string Variety { get; set; }
        public double AverageRating { get; set; }

        public int Compare(object x, object y)
        {
            CoffeI coffe1 = x as CoffeI;
            CoffeI coffe2 = y as CoffeI;
            double rating1 = coffe1.AverageRating;
            double rating2 = coffe2.AverageRating;
            return rating1.CompareTo(rating2);
        }

        public int CompareTo(object obj)
        {
            CoffeI coffe2 = obj as CoffeI;
            return string.Compare(this.Variety, coffe2.Variety);
        }

        public int GetServingTemperature(bool includesMilk)
        {
            if (includesMilk)
            {
                return servingTempWithMilk;
            }
            else
            {
                return servingTempWithoutMilk;
            }
        }

        int IBeverage.GetServingTemperature(bool includesMilk)
        {
            if (includesMilk)
            {
                return servingTempWithMilk;
            }
            else
            {
                return servingTempWithoutMilk;

            }
        }
    }
    public class StructExample
    {
        public static void Main()
        {
            // error en 4-20 coffe1.Rating debe ser coffe1.AverageRating;
            CoffeI coffee1 = new CoffeI();
            coffee1.AverageRating = 4.5;
            //IBeverage coffe2 = new CoffeI();
            CoffeI coffe2 = new CoffeI();
            coffe2.AverageRating = 8.1;
            IBeverage beverage = coffee1;
            CoffeI coffe3 = beverage as CoffeI;
            // Esto siguiente es equivalente
            //coffe3 = (CoffeI)beverage;
            coffe3.AverageRating = 7.1;
            CoffeI coffe4 = new CoffeI();
            coffe4.AverageRating = 3.89;
            ArrayList coffelist = new ArrayList();
            coffelist.Add(coffee1);
            coffelist.Add(coffe2);
            coffelist.Add(coffe3);
            coffelist.Add(coffe4);
            foreach (CoffeI cof in coffelist)
            {
                Console.WriteLine(cof.AverageRating);
            }
            Console.WriteLine("=== Afert sort: ===");
            coffelist.Sort(new CoffeI());
            foreach (CoffeI cof in coffelist)
            {
                Console.WriteLine(cof.AverageRating);
            }
            Console.ReadLine();
        }
    }
}
