using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm_for_Expression_Eval
{
    class ExpressionEvaluation
    {
        static void Main(string[] args)
        {
            Stack<String> ops = new Stack<String>();
            Stack<Double> vals = new Stack<Double>();

            string input = "(1+((2+3)*(4*5)))";

            foreach (var item in input)
            { 
                // Read token, push if operator.
                String s = item.ToString();
                if (s.Equals("("))
                {
                    // do nothing intentionaly
                }
                else if (s.Equals("+")) ops.Push(s);
                else if (s.Equals("-")) ops.Push(s);
                else if (s.Equals("*")) ops.Push(s);
                else if (s.Equals("/")) ops.Push(s);
                else if (s.Equals("sqrt")) ops.Push(s);
                else if (s.Equals(")"))
                {
                    // Pop, evaluate, and push result if token is ")".
                    String op = ops.Pop();
                    double v = vals.Pop();
                    if (op.Equals("+")) v = vals.Pop() + v;
                    else if (op.Equals("-")) v = vals.Pop() - v;
                    else if (op.Equals("*")) v = vals.Pop() * v;
                    else if (op.Equals("/")) v = vals.Pop() / v;
                    else if (op.Equals("sqrt")) v = Math.Sqrt(v);
                    vals.Push(v);
                }
                else
                {
                    // Token not operator or paren: push double value.
                    vals.Push(Double.Parse(s));
                }
            }

            Console.WriteLine(vals.Pop());
        }
    }
}
