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
    public class ProductService
    {
        private ILogger<ProductService> _logger;
        private ApplicationDbContextMaria ApplicationDbContext;
        private object oo = new object();
        public ProductService(ILogger<ProductService> logger, ApplicationDbContextMaria applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext?? throw new ArgumentNullException("MyCoolDbContext is null", (Exception)null);
            _logger = logger;
            
        }
        public List<Product> All()
        {
            return ApplicationDbContext.Products.ToList<Product>();

        }

        public Task<Product> Product(string code)
        {
            return  ApplicationDbContext.Products.FirstOrDefaultAsync(t => t.Code.Equals(code));
        }


        public async void Add(Product productAdd)
        {
            var data = ApplicationDbContext.Products.FirstOrDefault(i => i.Id.Equals(productAdd.Id));
            using var transaction = ApplicationDbContext.Database.BeginTransaction();
            {
                try
                {
                  
                    if (data != null)
                    {
                        ApplicationDbContext.Products.Update(productAdd);
                       
                    }
                    else
                    {
                        ApplicationDbContext.Products.Add(productAdd);
                    }
                  
                        ApplicationDbContext.SaveChanges();
                        transaction.Commit();
                  
                     
                }
                catch (Exception e)
                {
                    _logger.LogError(e.StackTrace);
                    await transaction.RollbackAsync();

                }
            }
        }

        public void Delete(Product productAdd)
        {
            using var transaction = ApplicationDbContext.Database.BeginTransaction();
            {
                try
                {
                    var ret = ApplicationDbContext.Products.FirstOrDefault(t => t.Id.Equals(productAdd.Id));
                    if (ret != null)
                    {

                        ApplicationDbContext.Products.Remove(productAdd);
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
