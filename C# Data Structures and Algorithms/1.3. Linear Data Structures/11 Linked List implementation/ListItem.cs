using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Linked_List_implementation
{
    internal class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }

        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }
    }
}
