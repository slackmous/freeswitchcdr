using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace cdr_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting script");
            Console.WriteLine("Hit enter to begin");
            Console.ReadLine();

            List<string> csv = new List<string>(); // or, List<YourClass>
            List<object> myObj = new List<object>();

            var lines = System.IO.File.ReadAllLines(@"/Users/ctrower/Projects/tcw_ispscripts/sonar_scripts/cdr_logger/Master.csv");
            foreach (string line in lines)
            {
                csv.Add(line.Replace("\"", ""));
            }

            Console.WriteLine("Finished removing quotes. Hit enter to continue");
            Console.ReadLine();

            foreach (string value in csv)
            {
                var origination = value.Split(',')[1];
                var destination = value.Split(',')[2];
                var callStart = value.Split(',')[4];
                var duration =value.Split(',')[7];

                myObj.Add(new { origination = "\"" + origination + "\"", destination = "\"" + destination + "\"", call_start = "\"" + callStart + "\"", duration = int.Parse(duration)});
                Console.WriteLine(value);
            }

            Console.WriteLine("Loving json no parse");
            Console.ReadLine();
            foreach (object value in myObj)
            {
                Console.WriteLine(value);
            }
        }
    }
}
