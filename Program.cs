using System;
using System.Collections.Generic;


namespace SharpWasher
{
    public static class MyExtension
    {
        public static void Perfom<T>(this IEnumerable<T> myCollection, Action<T> predicator)
        {
            foreach (var item in myCollection)
                predicator(item);
        }
    }
    public class Car
    {
        public Car(string brand)
        {
            Brand = brand;
            Garage.carsInGarageList.Add(this);
        }
        public readonly string Brand;
        public override string ToString() => Brand;
    }
    public static class Garage
    {
        public static List<Car> carsInGarageList { get; } = new List<Car>();

    }

    public static class Washer
    {
        public static void Wash(Car car)
        {
            Console.WriteLine($"Машина {car} помыта!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("Mercedes-benz w124");
            var car2 = new Car("BMW X5");
            var car3 = new Car("Toyta Camry");
            Garage.carsInGarageList.Perfom(Washer.Wash);
        }
    }
}