using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.Data;
using ZenithApp.model;

namespace ZenithApp.services
{
    public class BasketService
    {
        private ILogger<BasketService> _logger;
        private ApplicationDbContextMaria ApplicationDbContext;

        public BasketService(ILogger<BasketService> logger, ApplicationDbContextMaria applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
            _logger = logger;

        }
        public List<Basket> All()
        {
            return ApplicationDbContext.Baskets.ToList<Basket>();

        }

        public Task<Basket> Product(int code)
        {
            return ApplicationDbContext.Baskets.FirstOrDefaultAsync(t => t.Id.Equals(code));
        }


        public  void Add(Basket basket)
        {
            var data = ApplicationDbContext.Products.FirstOrDefault(i => i.Id.Equals(basket.Id));
            using var transaction = ApplicationDbContext.Database.BeginTransaction();
            {
                try
                {

                    if (data != null)
                    {
                        ApplicationDbContext.Baskets.Update(basket);

                    }
                    else
                    {
                         ApplicationDbContext.Baskets.Add(basket);
                    }

                    ApplicationDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.StackTrace);
                     transaction.Rollback();

                }
            }
        }

        public void Delete(Basket basket)
        {
            using var transaction = ApplicationDbContext.Database.BeginTransaction();
            {
                try
                {
                    var ret = ApplicationDbContext.Baskets.FirstOrDefault(t => t.Id.Equals(basket.Id));
                    if (ret != null)
                    {

                        ApplicationDbContext.Baskets.Remove(basket);
                        ApplicationDbContext.SaveChanges();
                        transaction.Commit();
                        _logger.LogInformation("Deleted " + ret);

                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e.StackTrace);
                    transaction.Rollback();

                }

            }


        }
    }
}
