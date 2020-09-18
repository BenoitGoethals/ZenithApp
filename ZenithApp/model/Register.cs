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
        private readonly BasketService _basketService;
        public Register(BasketService basketService)
        {
            _basketService = basketService;
        }
     
        private object Olock = new object();
        private readonly List<Action> _actions = new List<Action>();

        public Register()
        {
   
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
            _basketService.Delete(basket);
     
            lock (Olock)
            {
                _actions.ForEach(a => a.Invoke());
            }
        }

        public  void AddBasketAsync(Basket basket)
        {
            _basketService.Add(basket);

            lock (Olock)
            {
                _actions.ForEach(a => a.Invoke());
            }

            // _collection.Add(basket);
        }

        public List<Basket> All()
        {
            return _basketService.All();

        }


        public void Subsribe(Action update)
        {
            lock (Olock)
            {
                _actions.Add(update);
            }
        }
    }
}