using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId = 1,CategoryId = 1, ProductName = "Bilgisayar", UnitsInStock = 12, UnitPrice = 20},
                new Product {ProductId = 2,CategoryId = 2, ProductName = "Telefon", UnitsInStock = 25, UnitPrice = 15},
                new Product {ProductId = 3,CategoryId = 3, ProductName = "Tablet", UnitsInStock = 10, UnitPrice = 10},
                new Product {ProductId = 4, CategoryId = 4, ProductName = "Kulaklık", UnitsInStock = 100, UnitPrice = 8 },
                new Product {ProductId = 5, CategoryId = 5, ProductName = "Saat", UnitsInStock = 30, UnitPrice = 9 }
        };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
             Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
             
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetaiDto> GetProductDetaiDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
