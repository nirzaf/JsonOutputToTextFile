using System;

namespace JsonOutput
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                object ob = new object();
                ob = Console.ReadLine();
                Convert.ToInt32(ob);
                Console.WriteLine("Hello!");
                Console.WriteLine("Hello!");
                Console.WriteLine("Hello!");
                ob = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ExportJSON ej = new ExportJSON();
                ej.Add(ex);
            }
        }
    }
}