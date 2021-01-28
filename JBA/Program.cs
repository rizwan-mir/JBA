using JBA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace JBA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rainfall> rainfalls = new List<Rainfall>();
            Console.WriteLine("ENTER FILE NAME");
            string filename = Console.ReadLine();
            
            string[] lines = System.IO.File.ReadAllLines(filename);
            int xRef = 0; 
            int yRef = 0;
            DateTime rainDate = DateTime.Parse("01/01/1990");
            string getYear = "";

            foreach (string line in lines)
            {
                if (line.Contains("Years="))
                {
                    getYear = line.Substring(line.IndexOf("Years=") + 6, 4);
                    rainDate = DateTime.Parse("01/01/" + getYear);
                }

                if (line.Contains("Grid-ref="))
                {
                    var rainRef = line.Split(',');
                    xRef = int.Parse(rainRef[0].Substring(9));
                    yRef = int.Parse(rainRef[1]);
                    rainDate = DateTime.Parse("01/01/" + getYear);
                }                     

                if (Regex.IsMatch(line, @"^[\d \w \s]+$"))
                {
                    var values = line.Split(' ');
                    foreach (string rainVal in values)
                    {
                        if (rainVal.Length > 0)
                        {
                            Rainfall rainfall = new Rainfall();
                            rainfall.Xref = xRef;
                            rainfall.Yref = yRef;
                            rainfall.Value = int.Parse(rainVal);
                            rainfall.Date = rainDate;
                            using (var db = new DataHelper())
                            {
                                db.RainData.Add(rainfall);
                                db.SaveChanges();
                            }
                            rainfalls.Add(rainfall);
                            rainDate = rainDate.AddMonths(1);
                        }
                    }
                }

            }
                Console.ReadLine();
        }
    }
}
