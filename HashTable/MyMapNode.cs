using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    //declared generic class MyMapNode having place holders K and V
    internal class MyMapNode<K, V>
    {
        internal int size;

        //declarin an array of LinkedList of KeyValue pair containing K, V as key and value of name items
        internal LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;

            //size of array of LinkedList is passed while creating objects in main program
            items = new LinkedList<KeyValue<K, V>>[size];
        }

        //to get the position of the key in the array by formula given
        public int ArrayPosition(K key)
        {
            //to resolve conflicts in array , we use formula to calculate position
            //position = (hash code of the key) % (size of the array)
            int position = key.GetHashCode() % size;

            //returning the positive value of position
            return Math.Abs(position);
        }

        public V Get(K key)
        {
            int position = ArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);

            //checking for each KeyValue pair in our linked list
            foreach (KeyValue<K, V> item in linkedlist)
            {
                //if our Key in item is matching with the key or not
                if (item.Key.Equals(key))
                {
                    //return the value present in item , i.e. value situated at the position
                    return item.Value;
                }
            }
            return default(V);
        }

        //For adding items in our LinkedList
        public void Add(K key, V value)
        {
            //get position of our item using key
            int position = ArrayPosition(key);

            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };

            //add that item at the last position/ at the end of the linkedlist
            linkedlist.AddLast(item);
        }

        //creatig GetLinkedList method having return type as LinkedList
        //each value in LinkedList is containing KeyValue structure
        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            //passing the position of the item to the LinkedList named linkedlist
            LinkedList<KeyValue<K, V>> linkedlist = items[position];

            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }

        //Creatin a structure(struct) of type KeyValue
        //struct is used to group many related variables into one place
        //i.e. collection of many different datatypes
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
    }
}
