using PayDisability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        public static void add()
        {
            Console.WriteLine();
            Employes emp = new Employes();
            Console.Write("Имя:");
            emp.name = Console.ReadLine();
            Console.Write("Средняя ЗП:");
            emp.salary = float.Parse(Console.ReadLine());
            Console.Write("Стаж:");
            emp.experience = int.Parse(Console.ReadLine());
            sqlQuery sql = new sqlQuery();
            sql.addUser(emp);
        }

        public static void delete()
        {
            sqlQuery sql = new sqlQuery();
            List<Employes> empList = sql.getEmployes();
            foreach (var item in empList)
            {
                Console.WriteLine();
                Console.WriteLine("Имя:" + item.name);
                Console.WriteLine("Средняя зп:" + item.salary);
                Console.WriteLine("Стаж:" + item.experience);
            }
            Console.WriteLine();
            Console.Write("Введите имя работника для удаления:");
            sql.deleteUser(Console.ReadLine());
        }
        
        public static void open()
        {
            sqlQuery sql = new sqlQuery();
            List<Employes> empList = sql.getEmployes();
            Console.WriteLine("Список работников:");
            foreach (var item in empList)
            {
                Console.WriteLine();
                Console.WriteLine("Имя:" + item.name);
                Console.WriteLine("Средняя зп:" + item.salary);
                Console.WriteLine("Стаж:" + item.experience);
            }
        }

        public static void benefit()
        {
            sqlQuery sql = new sqlQuery();
            List<Employes> empList = new List<Employes>();
            Console.WriteLine("Список работников:");
            empList = sql.getEmployes();
            foreach (var item in empList)
            {
                Console.WriteLine();
                Console.WriteLine("Имя:" + item.name);
            }
            Console.WriteLine();
            Console.WriteLine("Введите имя работника:");
            string name = Console.ReadLine();
            int experience = 0;
            double salary = 0;
            foreach (var item in empList)
            {
                if (item.name == name)
                {
                    Console.WriteLine("Имя:" + item.name);
                    Console.WriteLine("Средняя зп:" + item.salary);
                    salary = item.salary;
                    Console.WriteLine("Стаж:" + item.experience);
                    experience = item.experience;
                }
            }
            Console.WriteLine();
            Console.Write("Введите кол-во дней отпуска:");
            int SumDay = int.Parse(Console.ReadLine());
            average(SumDay, salary, experience);
        }

        public static void helper()
        {
            Console.Clear();
            Console.WriteLine("add — добавить работника");
            Console.WriteLine("delete — удалить работника");
            Console.WriteLine("open — показать список работников");
            Console.WriteLine("benefit — вычислить пособие");
            Console.WriteLine("clear — очистить кансоль");
        }

        static void Main(string[] args)
        {
            try
            {
                helper();
                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Введите команду:");
                    string command = Console.ReadLine();
                    if (command == "add")
                    {
                        add();
                    }
                    else
                    if (command == "delete")
                    {
                        delete();
                    }
                    else
                    if (command == "open")
                    {
                        open();
                    }
                    else
                    if (command == "benefit")
                    {
                        benefit();
                    }
                    else
                    if (command == "clear")
                    {
                        helper();
                    }
                    else
                    {
                        Console.WriteLine("Моя программа не достаточно умна что бы понять этот бред;)");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        public static void average(int SumDay, double salary, int experience)
        {
            try
            {
                double mrotBy = 239.42;
                double proc = 0;
                double sd = mrotBy * 24 / 730;
                double sp = 0;
                if (experience == 0)
                    sp = sd * proc * SumDay;
                else
                {
                    if (experience >= 1 && experience < 5)
                        proc = 0.6;
                    else
                    if (experience >= 5 && experience < 8)
                        proc = 0.8;
                    else
                    if (experience > 8)
                        proc = 1;
                    sd = salary * 24 / 730;
                    sp = sd * proc * SumDay;
                }
                Console.WriteLine(Math.Round(sd, 2).ToString());
                Console.WriteLine(Math.Round((sp + (30 - SumDay) * salary / 30), 2).ToString());
                Console.WriteLine(Math.Round(sp, 2).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
