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
        private List<Product> _list = new List<Product>();
        public ProductService(ILogger<ProductService> logger, ApplicationDbContextMaria applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
            _logger = logger;
            /*
            TypeProduct typeProduct=new TypeProduct(1,"Drank");
            TypeProduct typeProduct2=new TypeProduct(1,"Chips");
            var product2 = new Product(1, "Cola", "Colq",12.5, "45be3", 6, null, typeProduct);
            product2.Image = ImageHelper.ConvertToByte(@"cola.jpg");
          
            var product3 = new Product(2, "Corona", "Corona",2, "45be4", 6, null, typeProduct);
            product3.Image = ImageHelper.ConvertToByte(@"OIP.jpg");
            var product4 = new Product(3, "Coronq", "Chips",12.5, "45be5", 6, null, typeProduct2);
            product4.Image = ImageHelper.ConvertToByte(@"croc.jpg");
            _list.Add(product2);
            _list.Add(product3);
            _list.Add(product4);
            */
        }
        public Task<List<Product>> All()
        {
            return ApplicationDbContext.Products.ToListAsync<Product>();

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
                        await ApplicationDbContext.Products.AddAsync(productAdd);
                    }

                    await ApplicationDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
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
