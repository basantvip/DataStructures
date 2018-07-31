using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Postfix
    {
        public static void Demo()
        {
            var stack = new StackLinkList<string>();

            while (true)
            {
                Console.Write("\nEnter Space Separated Postfix String (0 or Enter to exit): ");
                var postfixString = Console.ReadLine()??"0";
                if  (postfixString.Trim() == "0" || postfixString.Trim() == "")
                    return;
                var postfixList = postfixString.Split(' ');

                var validString = true;

                foreach (var token in postfixList)
                {
                    switch (GetTokenType(token))
                    {
                        case "Operand":
                            stack.Push(token);
                            break;
                        case "Operator":
                            var op2 = stack.Pop();
                            var op1 = stack.Pop();
                            stack.Push(Apply(op1, op2, token).ToString());
                            break;
                        case "Invalid Token":
                            Console.WriteLine("Invalid character in postfix string");
                            validString = false;
                            break;
                    }
                }
                if (validString)
                Console.WriteLine($"Result: {stack.Pop()}");
            }
        }

        public static void InfixToPostfix()
        {            
            while (true)
            {
                var stack = new Stack<char>();
                var queue = new Queue<char>();
                var validString = true;
                Console.Write("\nEnter InFix string:");
                var inFixString = Console.ReadLine() ?? "0";
                if (inFixString.Trim() == "0" || inFixString.Trim() == "")
                    return;
                foreach (var token in inFixString)
                {
                    switch (GetTokenType(token))
                    {
                        case "Operand":
                            queue.Enqueue(token);
                            break;
                        case "Operator":
                            var weight = OperatorWeight(token);

                            while (stack.Count > 0)
                            {
                                var s1 = stack.Peek();

                                if (GetTokenType(s1) != "Operator" || OperatorWeight(s1) < weight)
                                    break;

                                queue.Enqueue(stack.Pop());

                            }
                            stack.Push(token);
                            break;                            
                        case "Paranthesis Start":
                            stack.Push(token);
                            break;
                        case "Paranthesis End":
                            var s = GetStartParanthesis(token);
                            while (stack.Count > 0)
                            {
                                var a = stack.Pop();                                
                                if (a == s)
                                    break;
                                queue.Enqueue(a);
                            }
                            break;
                        case "Invalid Token":
                            Console.WriteLine("Invalid character in input string");
                            validString = false;
                            break;
                    }
                }
                while (stack.Count > 0)
                    queue.Enqueue(stack.Pop());

                if (validString)
                {

                    string s = new string(queue.ToArray());
                    Console.WriteLine($"Result: {s}");
                }
            }
        }

        public static string GetTokenType(char s)
        {
            if ((s >= 'a' && s <= 'z') || (s >= 'A' && s <= 'Z') || (s >= '0' && s <= '9'))
                return "Operand";
            else if (s == '+' || s == '-' || s == '*' || s == '/')
                return "Operator";
            else if (s == '(' || s == '{' || s == '[')
                return "Paranthesis Start";
            else if (s == ')' || s == '}' || s == ']')
                return "Paranthesis End";
            else return
                    "Invalid token";
        }

        public static int OperatorWeight(char s)
        {
            if (s == '+' || s == '-')
                return 1;
            else if (s == '*' || s == '/')
                return 2;
            else return 0;
        }

        public static char GetStartParanthesis(char s)
        {
            if (s == ')')
                return '(';
            else if (s == '}')
                return '{';
            else if (s == ']')
                return '[';

            else return ' ';

        }



        public static string GetTokenType(string token)
        {
            double tokenvalue;
            if (double.TryParse(token, out tokenvalue))
                return "Operand";
            else if (token == "+" || token == "-" || token == "*" || token == "/")
                return "Operator";
            else return "Invalid Token";
        }

        public static string Apply(string operand1, string operand2, string Operator)
        {
            double op1, op2;
            double.TryParse(operand1, out op1);
            double.TryParse(operand2, out op2);
            switch (Operator)
            {
                case "+":
                    return (op1 + op2).ToString();
                case "-":
                    return (op1 - op2).ToString();
                case "*":
                    return (op1 * op2).ToString();
                case "/":
                    return (op1 / op2).ToString();
            }
            return null;
        }
    }
}

