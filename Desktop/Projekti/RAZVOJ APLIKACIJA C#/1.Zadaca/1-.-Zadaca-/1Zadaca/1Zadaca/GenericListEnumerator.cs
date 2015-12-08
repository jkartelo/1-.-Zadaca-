using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _1Zadaca
{

    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private IGenericList<T> _collection;
        public int globalno_stanje = -1;
        public GenericListEnumerator(IGenericList<T> collection)
        {
            _collection = collection;
        }
        public bool MoveNext()
        {
            globalno_stanje++;
            if(_collection.Count>globalno_stanje)
            {                
                return true;
            }
            // Zove se prije svake iteracije. 
            // Vratite true ako treba ući u iteraciju, false ako ne 
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se 
            // nalazimo u kolekciji 
            return false;
        }
        public T Current
        {
            get
            {
                return _collection.GetElement(globalno_stanje);
                // Zove se na svakom ulasku u iteraciju 
                // Hint: Koristite stanje postavljeno u MoveNext() dijelu 
                // kako bi odredili što se zapravo vraća u ovom koraku 
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose()
        { // Ignorirajte 
        }
        public void Reset()
        { // Ignorirajte 
        }
    }
}