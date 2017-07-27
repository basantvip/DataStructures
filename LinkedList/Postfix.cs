using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
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

