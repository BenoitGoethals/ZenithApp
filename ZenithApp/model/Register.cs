using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.services;

namespace ZenithApp.model
{
    public class Register
    {
        private BasketService BasketService;
        public Register(BasketService basketService)
        {
            BasketService = basketService;
        }
     //   private ObservableCollection<Basket> _collection = new ObservableCollection<Basket>();
        private object Olock = new object();
        private readonly List<Action> _actions = new List<Action>();

        public Register()
        {
        //    _collection.CollectionChanged += _collection_CollectionChanged;
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
            BasketService.Delete(basket);
     //       _collection.Remove(basket);
            lock (Olock)
            {
                _actions.ForEach(a => a.Invoke());
            }
        }

        public  void AddBasketAsync(Basket basket)
        {
             BasketService.Add(basket);
            
                _actions.ForEach(a => a.Invoke());
            
            // _collection.Add(basket);
        }

        public Task<List<Basket>> All()
        {
            return BasketService.All();

        }


        public void Subsribe(Action update)
        {
            _actions.Add(update);
        }
    }
}