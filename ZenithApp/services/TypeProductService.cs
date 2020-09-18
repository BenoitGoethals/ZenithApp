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
        private readonly ApplicationDbContextMaria _dbContext;
        public TypeProductService(ApplicationDbContextMaria dbContext)
        {
            this._dbContext = dbContext;
        }




        public Task<List<TypeProduct>> All => _dbContext.TypeProducts.ToListAsync<TypeProduct>();
    }
}
