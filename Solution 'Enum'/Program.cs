using System;
using Solution__Enum_.Entities.Enums;
using System.Globalization;
using Solution__Enum_.Entities;

namespace Solution__Enum_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Depatament's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Worker's Informations");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior, MidLevel, Senior: )");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts for this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i<=n; i++)
            {
                Console.Write($" Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hour): ");
                int hour = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hour);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string mouthAndYear = Console.ReadLine();
            int mouth = int.Parse(mouthAndYear.Substring(0, 2));
            int year = int.Parse(mouthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.departament.Name);
            Console.WriteLine("Income For: " + mouthAndYear + ": " + worker.Income(year, mouth).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}