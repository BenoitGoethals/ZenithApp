using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithApp.model
{
    public class Register
    {
        private ObservableCollection<Basket> _collection = new ObservableCollection<Basket>();
        private object Olock = new object();

        List<Action> _actions = new List<Action>();

        public Register()
        {
            _collection.CollectionChanged += _collection_CollectionChanged;
        }

        private void _collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lock (Olock)
            {
                _actions.ForEach(a => a.Invoke());
            }

        }

        public void Remove(Basket basket)
        {
            _collection.Remove(basket);
        }

        public void AddBasket(Basket basket)
        {
            _collection.Add(basket);
        }

        public Task<List<Basket>> All()
        {
            return Task.FromResult(_collection.ToList());

        }


        public void Subsribe(Action update)
        {
            _actions.Add(update);
        }
    }
}