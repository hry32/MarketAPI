using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UsersRepository: IRepository<Users>
    {
        AppDbContext _dbContext;
        public UsersRepository(AppDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public void Add(Users _object)
        {
            var obj = _dbContext.Users.AddAsync(_object);
            _dbContext.SaveChanges();
        }
        public void Update(Users _object)
        {
            _dbContext.Users.Update(_object);
            _dbContext.SaveChanges();
        }
        public void Delete(Users Id)
        {
            _dbContext.Users.Remove(Id);
            _dbContext.SaveChanges();
        }
        public List<Users> GetAll()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Users GetById(int Id)
        {
            return _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }


}
