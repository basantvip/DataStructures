using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class ExclusiveTimeOfFunctions
    {

        //636. Exclusive Time of Functions: https://leetcode.com/problems/exclusive-time-of-functions/description/

        public class MethodLog
        {
            string _MethodName;
            string _Mode; //start/end
            int _Timestamp;


            public string MethodName
            {
                get { return _MethodName; }
                set { _MethodName = value; }
            }

            public string Mode
            {
                get { return _Mode; }
                set { _Mode = value; }
            }

            public int Timestamp {
                get { return _Timestamp; }
                set { _Timestamp = value; }
            }

            public MethodLog(string log)
            {
                var logfields = log.Split(':').Select(t => t.Trim()).ToArray();
                if (logfields.Length != 3)
                    throw new Exception("Incorrect number of items in last log");

                MethodName = logfields[0];
                if (logfields[1].ToLower() != "start" && logfields[1].ToLower() != "end")
                    throw new Exception("Method Mode can be only start or end");                

                Mode = logfields[1];
                Timestamp = int.Parse(logfields[2]) ;

                int ts = 0;
                if (!int.TryParse(logfields[2], out ts))
                    throw new Exception("Timestamp must be an integer");

                Timestamp = ts;
                

            }

        }

        public class MethodTimeSpent
        {
            string _MethodName;            
            int _Timespent;


            public string MethodName
            {
                get { return _MethodName; }
                set { _MethodName = value; }
            }
            
            public int Timespent
            {
                get { return _Timespent; }
                set { _Timespent = value; }
            }

            public MethodTimeSpent(string methodName, int timespent)
            {
                this.MethodName = methodName;
                this.Timespent = timespent;
            }

        }

        public static void Demo()
        {            
            //var stack = new Stack<string>();
            var methodLogList = new List<MethodLog>();

            //Console.Write("\nMethod Log: methodName, (start or end), timestamp. 0 to stop.\n");

            var logs = new string[]
            {
                //"Main,start,0",
                //"Print,start,10",
                //"Print,end,19",
                //"Malloc,start,23",
                //"Print,start,25",
                //"Print,end,27",
                //"Malloc,end,30",
                //"Main,end,32"
                "0:start: 0",
                "1:start:2",
                "1:end:5",
                "0:end:6"

            };

            var lastTimestamp = int.MinValue;
            var result = new Dictionary<string,int>();
            var stack = new Stack<string>();

            foreach (var item in logs)
            {   
                var CurrentLogLine = item ?? "0";

                if (CurrentLogLine.Trim() == "0" || CurrentLogLine.Trim() == "")
                    break;

                var log = new MethodLog(CurrentLogLine);
                if (log.Timestamp < lastTimestamp)
                    throw new Exception("Timestamp must be in ascending order");               

             

                if (log.Mode == "start")
                {
                    if (stack.Count() > 0) //need to add time to the parent caller
                    {                        
                        if (result.ContainsKey(stack.Peek()))
                            result[stack.Peek()]+= log.Timestamp - lastTimestamp;
                        
                    }

                    stack.Push(log.MethodName); //create a new entry for the started method
                    if (!result.ContainsKey(log.MethodName))
                        result.Add(log.MethodName, 0);
                }
                else //end
                {
                    var s = stack.Pop();
                    if (s != log.MethodName) //there should be a start for every end
                        throw new Exception("Incorrect start end sequence");

                    result[s]+= log.Timestamp - lastTimestamp;

                }

                methodLogList.Add(log);
                lastTimestamp = log.Timestamp;
            }

            Console.WriteLine("\ninput:");
            methodLogList.ForEach(t => Console.WriteLine($"{t.MethodName},{t.Mode},{t.Timestamp.ToString()}"));
            Console.WriteLine("\noutput:");
            result.Select(t => t).ToList().ForEach(t => Console.WriteLine($"{t.Key}:{t.Value.ToString()}"));
            Console.ReadLine();

        }
    }
}
