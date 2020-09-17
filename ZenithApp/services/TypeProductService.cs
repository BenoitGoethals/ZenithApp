using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.Data;
using ZenithApp.model;

namespace ZenithApp.services
{
    public class TypeProductService
    {
        private ApplicationDbContextMaria DbContext;
        public TypeProductService(ApplicationDbContextMaria dbContext)
        {
            this.DbContext = dbContext;
        }
        private List<TypeProduct> _list;

        public TypeProductService()
        {

        }

        public Task<List<TypeProduct>> All()
        {
            return DbContext.TypeProducts.ToListAsync<TypeProduct>();

        }
    }
}
