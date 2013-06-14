namespace Iterator
{
    using System;

    /*
     * Please note that this IS an ITERATOR pattern, even if we haven't learned it like that in academy!!!
     * If any doubts exists - google some more ;)
     * 
     */

    public class Program 
    {
        public static void Main(String[] args) 
        {
            Sequence<int> sequence = new Sequence<int>(10);
            for(int i = 0; i < 10; i++)
            {
                sequence.Add(i);
            }

            ISelector selector = sequence.Selector();

            while(!selector.End()) 
            {
                Console.WriteLine(selector.Current());
                selector.Next();
            }
        }
    }
}
