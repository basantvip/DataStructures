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
                Console.Write("\nEnter Postfix String (0 or Enter to exit): ");
                var postfixString = Console.ReadLine()??"0";
                if  (postfixString.Trim() == "0")
                    return;
                var postfixList = postfixString.Split(' ');

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
                            throw new Exception("Invalid Token");
                    }
                }
                Console.WriteLine($"Result: {stack.Pop()}");
            }
        }

        public static string GetTokenType(string token)
        {
            int tokenvalue;
            if (int.TryParse(token, out tokenvalue))
                return "Operand";
            else if (token == "+" || token == "-" || token == "*" || token == "/")
                return "Operator";
            else return "Invalid Token";
        }

        public static string Apply(string operand1, string operand2, string Operator)
        {
            int op1, op2;
            int.TryParse(operand1, out op1);
            int.TryParse(operand2, out op2);
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

