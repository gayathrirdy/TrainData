using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AddUtterance;
using System.IO;
using Newtonsoft.Json;
using Titlepattern;
namespace Convert
{
    class JsonClass
    {
        public void ConvertToJson(string line)
        {
            string temp = line;
            List<string> list = new List<string> { };
            while (temp.IndexOf(" ") != -1)
            {
                list.Add(temp.Substring(0, temp.IndexOf(" ")));
                temp = temp.Substring(temp.IndexOf(" ")).Trim();
            }
            list.Add(temp);
            IntentPatterns intentPatterns = new IntentPatterns();
            
            List<List<string>> patterns = intentPatterns.getPatterns();
            List<string> ExtraDecorators = intentPatterns.getExtraDecorators();
            List<string> IntentList = intentPatterns.getIntentList();

            Rootobject jsonObject = new Rootobject();
            List<Class1> titles = new List<Class1> { };
            bool isPattern = false;
            int index = 0;

            foreach (List<string> pattern in patterns)
            {
                Class1 singleTitle = new Class1();
                List<Entitylabel> labels = new List<Entitylabel> { };
                if (list.Count() >= pattern.Count())
                {
                    int i = 0;
                    foreach (string item in pattern)
                    {
                        int flag = 0;
                        int position = line.IndexOf(list[i]);
                        switch (item)
                        {
                            case "percentage":
                                if (isPercentage(list[i]))
                                    flag = 1;
                                addEntity("percentage", position, list[i].Count(), labels);
                                break;
                            case "amount":
                                if (isAmount(list[i]))
                                    flag = 1;
                                addEntity("amount", position, list[i].Count(), labels);
                                break;
                            case "minimum_purchase":
                                if (isAmount(list[i]))
                                    flag = 1;
                                addEntity("minimumpurchase", position, list[i].Count(), labels);
                                break;
                            case "maximum_purchase":
                                if (isAmount(list[i]))
                                    flag = 1;
                                addEntity("maximumpurchase", position, list[i].Count(), labels);
                                break;
                            case "category":
                                flag = 1;
                                break;
                            case "extra_decorators":
                                if (ExtraDecorators.Contains(list[i].ToLower()))
                                    flag = 1;
                                break;
                            default:
                                if (list[i].ToLower() == pattern[i])
                                    flag = 1;
                                break;
                        }

                        i++;
                        if (i == pattern.Count() && flag == 1)
                        {
                            singleTitle.text = line;
                            Console.WriteLine(line);
                            singleTitle.intentName = IntentList[index];
                            singleTitle.entityLabels = labels.ToArray();
                            isPattern = true;
                            break;
                        }
                        if (flag == 0)
                            break;
                    }
                }
                if (isPattern)
                {
                    titles.Add(singleTitle);
                    break;
                }
                index++;
            }
            if (isPattern)
            {
                jsonObject.Property1 = titles.ToArray();
                string json = JsonConvert.SerializeObject(jsonObject);
                Console.WriteLine(json);
            }

            else
            {
                using (StreamWriter sw = File.AppendText(@"C:\Users\T-GABOLL\source\repos\TrainDataIntoJson\TrainDataIntoJson\output.txt"))
                {
                    sw.WriteLine(line);
                }
            }
        }

        public static void addEntity(string entityName,int position,int length, List<Entitylabel> labels)
        {
            Entitylabel entity = new Entitylabel();
            entity.entityName = entityName;
            entity.startCharIndex = position;
            entity.endCharIndex = position + length;
            labels.Add(entity);
        }
        public static bool isPercentage(string s)
        {
            string s1 = s.Substring(s.Length - 1);
            //string s2 = s.Substring(0, s.Length - 1);
            if (s1 == "%")
            {
                return true;
            }
            return false;
        }

        public static bool isAmount(string s)
        {
            string s1 = s.Substring(0, 1);
            List<string> currency = new List<string> { "$", "£" };
            //string s2 = s.Substring(0, s.Length - 1);
            if (currency.IndexOf(s1) != -1)
            {
                return true;
            }
            return false;
        }
    }
}