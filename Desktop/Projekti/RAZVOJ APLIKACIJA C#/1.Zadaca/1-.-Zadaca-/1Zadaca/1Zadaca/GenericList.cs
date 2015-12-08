using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _1Zadaca
{
    public interface IGenericList<X> : IEnumerable<X>
    {

        void Add(X item);

        bool Remove(X item);

        bool RemoveAt(int index);

        X GetElement(int index);

        int IndexOf(X item);

        int Count { get; }

        void Clear();

        bool Contains(X item);
    }
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage { get; set; }
        private int initialSize{ get; set; }
        private int velicina=0;
        
        public GenericList()
        {
            initialSize = 4;
            _internalStorage = new X[4];//inicijalizira privatan spremnik na veličinu od 4 elementa.            
        }
        public GenericList(int initSize)
        {
            initialSize = initSize;
            _internalStorage = new X[initialSize];
        }
        //*********************************************************

        public void Add(X item)
        {
            
            if (velicina >= initialSize)
            {
                //ako je pozicija izvan spremnika onda proširiri
                X[] _intStorage = new X[2 * initialSize];//inicializacija pomocnog polja

                for (int i = 0; i < initialSize; i++)
                {
                    _intStorage[i] = _internalStorage[i];//kopiram sve u pomocno polje
                }
                _internalStorage = new X[2 * initialSize];//stvaram novo duplo vece polje
                for (int i = 0; i < initialSize; i++)
                {
                    _internalStorage[i] = _intStorage[i];//iz pomocnog u prošireno
                }
            }
            _internalStorage[velicina] = item;
            velicina++;//velicina sadrzi broj dodanih elemenata
        }

        public bool Remove(X item)
        {
            int pozicija = 0;
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i].Equals(item))
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
            _internalStorage[index] = default(X);//uklonjen element na poziciji index
            for (int i = index; i < initialSize; i++)
            {
                _internalStorage[index] = _internalStorage[index + 1];
            }
            return true;
        }

        /// Returns the item at the given index in the collection. /// </summary>             
        public X GetElement(int index)
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
        public int IndexOf(X item)
        {
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i].Equals(item))
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
                _internalStorage[i] = default(X);//praznjenje polje
            }
        }

        /// Determines whether the collection contains a specific value.
        public bool Contains(X item)
        {
            for (int i = 0; i < initialSize; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
