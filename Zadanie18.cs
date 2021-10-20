using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Дана строка, содержащая скобки трёх видов(круглые, квадратные и фигурные) и любые другие символы.
             * Проверить, корректно ли в ней расставлены скобки. Например, в строке([]{ })[] скобки расставлены корректно,
             * а в строке([]] — нет.Указание: задача решается однократным проходом по символам заданной строки слева направо;
             * для каждой открывающей скобки в строке в стек помещается соответствующая закрывающая,
             * каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека
             * (при этом скобка с вершины стека снимается); в конце прохода стек должен быть пуст.
             */
            Console.WriteLine("Введите строку со скобочками");

            var s = Convert.ToString(Console.ReadLine());
            var ck = new BTC();

            foreach (var ch in s)
                ck.Put(ch);

            if (ck.Balanced == true)
            { Console.WriteLine("Корректно"); }
            else { Console.WriteLine("Некорректно"); }

            
            Console.ReadKey();
        }

        class BTC
        {
            private readonly string _opening = "([{";
            private readonly string _closing = ")]}";

            private bool _cantBeBalanced;

            private Stack<int> _opened = new Stack<int>();

            public bool Balanced => !_cantBeBalanced && !_opened.Any();

            public void Put(char ch)
            {
                if (_cantBeBalanced) return;

                int index = _opening.IndexOf(ch);

                if (index != -1)
                {
                    _opened.Push(index);
                    return;
                }

                index = _closing.IndexOf(ch);

                if (index != -1)
                {
                    if (!_opened.Any() || _opened.Peek() != index)
                    {
                        _cantBeBalanced = true;
                        _opened.Clear();
                        _opened.TrimExcess();
                        return;
                    }

                    _opened.Pop();
                    return;
                }
            }
        }
    }
}
    
