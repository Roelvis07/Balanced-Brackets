using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balanced_Brackets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string entrance = ""; //no

            //string entrance = "{[()]}"; //yes
            //string entrance = "{[(])}"; //no
            //string entrance = "{{[[(())]]}}"; //yes

            //string entrance = "{(([])[])[]}";

            //string entrance = "{(([])[])[]]}"; //no
            string entrance = "{(([])[])[]}[]"; //yes

            //string entrance = "{{([])}}"; //yes
            //string entrance = "{{)[](}}"; //no

            Console.WriteLine(isBalanced2(entrance));
        }
        /*
         * Complete the 'isBalanced' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string isBalanced(string s)
        {
            if (s == "" || s.Length % 2 != 0) 
                return "NO";
            else
            {
                Stack<char> nextToClose = new Stack<char>();

                foreach (var bracket in s)
                {
                    switch (bracket)
                    {
                        case '{':
                        case '(':
                        case '[':
                            nextToClose.Push(bracket);
                            break;
                        case '}':
                            if (nextToClose.Count == 0 || (nextToClose.Peek() != '{'))
                                return "NO";
                            nextToClose.Pop();
                            break;
                        case ')':
                            if (nextToClose.Count == 0 || (nextToClose.Peek() != '('))
                                return "NO";
                            nextToClose.Pop();
                            break;
                        case ']':
                            if (nextToClose.Count == 0 || (nextToClose.Peek() != '['))
                                return "NO";
                            nextToClose.Pop();
                            break;
                    }
                }

                return (nextToClose.Count == 0) ? "YES" : "NO";
            }
        }
        public static string isBalanced2(string s)
        {
            if (s == "" || s.Length % 2 != 0)
                return "NO";
            else
            {
                Stack<char> nextToClose = new Stack<char>();

                foreach (var bracket in s)
                {
                    if (bracket == '{')
                        nextToClose.Push('}');
                    else if (bracket == '[')
                        nextToClose.Push(']');
                    else if (bracket == '(')
                        nextToClose.Push(')');

                    if (bracket == '}' || bracket == ']' || bracket == ')')
                    {
                        if (nextToClose.Count == 0 || bracket != nextToClose.Peek())
                            return "NO";
                        nextToClose.Pop();
                    }
                }

                return (nextToClose.Count == 0) ? "YES" : "NO";
            }
        }

    }
}