using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MP.APICOMPRAS.Domain.Entities;
using MP.APICOMPRAS.Domain.Repositories;
using MP.APICOMPRAS.Infra.Data.Context;

namespace MP.APICOMPRAS.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APICOMPRASDbContext _db;
        public ProductRepository(APICOMPRASDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}