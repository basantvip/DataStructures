using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class TimeSpentInMethods
    {
        public class MethodLog
        {
            string _MethodName;
            string _Mode; //enter/exit
            int _Timestamp;


            public string MethodName { get => _MethodName; set => _MethodName = value; }
            public string Mode { get => _Mode; set => _Mode = value; }

            public int Timestamp { get => _Timestamp; set => _Timestamp = value; }

            public MethodLog(string log)
            {
                var logfields = log.Split(',').Select(t => t.Trim()).ToArray();
                if (logfields.Length != 3)
                    throw new Exception("Incorrect number of items in last log");

                MethodName = logfields[0];
                if (logfields[1].ToLower() != "enter" && logfields[1].ToLower() != "exit")
                    throw new Exception("Method Mode can be only enter or exit");                

                Mode = logfields[1];
                Timestamp = int.Parse(logfields[2]) ;

                if (!int.TryParse(logfields[2], out int ts))
                    throw new Exception("Timestamp must be an integer");

                Timestamp = ts;
                

            }

        }
        public static void Demo()
        {            
            //var stack = new Stack<string>();
            var methodLogList = new List<MethodLog>();

            Console.Write("\nEnter Method Log: methodName, (enter or exit), timestamp. 0 to stop.\n");

            while (true)
            {
                
                var CurrentLogLine = Console.ReadLine() ?? "0";

                if (CurrentLogLine.Trim() == "0" || CurrentLogLine.Trim() == "")
                    break;

                methodLogList.Add(new MethodLog(CurrentLogLine));                
            }

            foreach (var item in methodLogList)
            {
                Console.WriteLine($"{item.MethodName},{item.Mode},{item.Timestamp.ToString()}");
            }
        }
    }
}
