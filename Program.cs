using System;
using System.IO;
using System.Linq;
using System.Globalization;
using ExercicioUdemy2.Entities;
using System.Collections.Generic;


namespace ExercicioUdemy2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> emp = new List<Employee>();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

        try{
            using (StreamReader sr = File.OpenText(path)){
                
                while(!sr.EndOfStream){
                string[] vet = sr.ReadLine().Split(',');
                string name = vet[0];
                string email = vet[1];
                double sal = double.Parse(vet[2],CultureInfo.InvariantCulture);

                emp.Add(new Employee(name,email,sal));
                }
                
            }
            Console.WriteLine("Email of people whose salary is more than 2000.00: ");
            
            var emaill = emp.Where(e => e.Salary > salary).OrderBy(e => e.Email).Select(e => e.Email);

            foreach(string emails in emaill){
                Console.WriteLine(emails);
            }
            
            var soma = emp.Where(s => s.Name[0] =='M').Sum(s => s.Salary);

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + soma.ToString("F2",CultureInfo.InvariantCulture));

            }
            catch(IOException e){
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
