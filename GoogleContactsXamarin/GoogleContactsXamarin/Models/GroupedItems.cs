using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GoogleContactsXamarin.Models
{
    class GroupedItems<K,T> : ObservableCollection<T>
    {
        public K Key { get; }

        public GroupedItems(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach(var item in items)
            {
                Items.Add(item);
            }
        }

    }
}
