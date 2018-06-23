using System;
using System.Text;
using System.IO;
using Convert;
namespace TrainDataIntoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader(@"C:\Users\T-GABOLL\source\repos\TrainDataIntoJson\TrainDataIntoJson\file.txt", Encoding.GetEncoding("iso-8859-1"));
            //string line;
            //JsonClass jsonTitles = new JsonClass();
            //while ((line = sr.ReadLine()) != null)
            //{
            //    jsonTitles.ConvertToJson(line);
            //}
            string line;
            JsonClass jsonTitles = new JsonClass();
            line = Console.ReadLine();
            jsonTitles.ConvertToJson(line);
            Console.ReadKey();
        }
        
    }
}
