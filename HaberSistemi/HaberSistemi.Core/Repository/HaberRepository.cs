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
    public class HaberRepository : IHaberRepository
    {
        private readonly HaberContext _context = new HaberContext();

        public IEnumerable<Data.Model.Haber> GetAll()
        {
            return _context.Habers.Select(x => x); // Tüm haberleri çekecek
        }

        public Haber GetById(int id)
        {
            return _context.Habers.FirstOrDefault(x => x.ID == id);
        }
        public Haber Get(System.Linq.Expressions.Expression<Func<Haber, bool>> expression)
        {
            return _context.Habers.FirstOrDefault(expression);
        }

        public IQueryable<Haber> GetMany(Expression<Func<Haber, bool>> expression)
        {
            return _context.Habers.Where(expression);
        }

        public void Insert(Haber obj)
        {
            _context.Habers.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Haber obj)
        {
            _context.Habers.AddOrUpdate(obj);
        }


        public int Count()
        {
            return _context.Habers.Count();
        }

        public void Delete(int id)
        {
            var Haber = GetById(id);
            if(Haber != null)
            {
                _context.Habers.Remove(Haber);
            }
        }

        public void Delete(Haber obj)
        {
            throw new NotImplementedException();
        }
    }
}
