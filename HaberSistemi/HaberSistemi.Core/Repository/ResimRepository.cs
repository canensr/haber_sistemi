using HaberSistemi.Core.Insfrastructure;
using HaberSistemi.Data.DataContext;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Core.Repository
{
    public class ResimRepository : IResimRepository
    {

        private readonly HaberContext _context = new HaberContext();
        public IEnumerable<Data.Model.Resim> GetAll()
        {
            return _context.Resims.Select(x => x);
        }

        public Resim GetById(int id)
        {
            return _context.Resims.FirstOrDefault(x => x.ID == id);
        }
        public Resim Get(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resims.FirstOrDefault(expression);
        }

        public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resims.Where(expression);
        }

        public void Insert(Resim obj)
        {
            _context.Resims.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Resim obj)
        {
            _context.Resims.AddOrUpdate(obj);
        }

        public int Count()
        {
            return _context.Resims.Count();
        }

        public void Delete(int id)
        {
            var Resim = GetById(id);
            if (Resim != null)
            {
                _context.Resims.Remove(Resim);
            }
        }

        public void Delete(Resim obj)
        {
            throw new NotImplementedException();
        }
    }
}
