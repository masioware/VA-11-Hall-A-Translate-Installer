using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA_11_Hall_A_Translate_Installer
{
    public class Messenger
    {
        private ListBox.ObjectCollection collection;

        public Messenger(ListBox.ObjectCollection collection)
        {
            this.collection = collection;
        }

        public void Add(string message)
        {
            if (this.collection.Count > 10)
            {
                this.collection.RemoveAt(0);
            }

            this.collection.Add(message);
        }

        public void Clear()
        {
            this.collection.Clear();
        }
    }
}
