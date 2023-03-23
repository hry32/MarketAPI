using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ProductsRepository: IRepository<Products>
    {
        AppDbContext _dbContext;
        public ProductsRepository(AppDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public void Add(Products _object)
        {
            var obj = _dbContext.Products.AddAsync(_object);
            _dbContext.SaveChanges();
        }
        public void Update(Products _object)
        {
            _dbContext.Products.Update(_object);
            _dbContext.SaveChanges();
        }
        public void Delete(Products Id)
        {
            _dbContext.Products.Remove(Id);
            _dbContext.SaveChanges();
        }
        public List<Products> GetAll()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Products GetById(int Id)
        {
            return _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
