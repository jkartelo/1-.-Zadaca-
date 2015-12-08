using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadaca
{
    interface IIntegerList
    {

        void Add(int item);

        bool Remove(int item);

        bool RemoveAt(int index);

        int GetElement(int index);

        int IndexOf(int item);

        int Count { get; }

        void Clear();

        bool Contains(int item);
    }
    

    class IntegerList : IIntegerList
    {
        private int[] _internalStorage { get; set; }
        private int initialSize{ get; set; }
        private int velicina=0;
        
        public IntegerList()
        {
            initialSize = 4;
            _internalStorage = new int[4];//inicijalizira privatan spremnik na veličinu od 4 elementa.            
        }
        public IntegerList(int initSize)
        {
            initialSize = initSize;
            _internalStorage = new int[initialSize];
        }
        //*********************************************************

        public void Add(int item)
        {
            
            if (velicina >= initialSize)
            {
                //ako je pozicija izvan spremnika onda proširiri
                int[] _intStorage = new int[2 * initialSize];//inicializacija pomocnog polja

                for (int i = 0; i < initialSize; i++)
                {
                    _intStorage[i] = _internalStorage[i];//kopiram sve u pomocno polje
                }
                _internalStorage = new int[2 * initialSize];//stvaram novo duplo vece polje
                for (int i = 0; i < initialSize; i++)
                {
                    _internalStorage[i] = _intStorage[i];//iz pomocnog u prošireno
                }
            }
            _internalStorage[velicina] = item;
            velicina++;//velicina sadrzi broj dodanih elemenata
        }

        public bool Remove(int item)
        {
            int pozicija = 0;
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i] == item)
                {
                    pozicija = i;
                }
            }
            RemoveAt(pozicija);
            return true;
        }


        /// Removes the item at the given index in the collection. /// </summary> 
        public bool RemoveAt(int index)
        {
            if (index > initialSize)
            {
                return false;
            }
            _internalStorage[index] = 0;//uklonjen element na poziciji index
            for (int i = index; i < initialSize; i++)
            {
                _internalStorage[index] = _internalStorage[index + 1];
            }
            return true;
        }

        /// Returns the item at the given index in the collection. /// </summary>             
        public int GetElement(int index)
        {
            if (initialSize > index)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method returns -1. /// </summary> 
        public int IndexOf(int item)
        {
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        /// Readonly property. Gets the number of items contained in the collection. /// </summary>             
        public int Count { get { return velicina; } }

        /// Removes all items from the collection. /// </summary> 
        public void Clear()
        {
            for (int i = 0; i < initialSize; i++)
            {
                _internalStorage[i] = 0;//praznjenje polje
            }
        }

        /// Determines whether the collection contains a specific value.
        public bool Contains(int item)
        {
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i] == item)
                    return true;
            }
            return false;
        }

    }
}