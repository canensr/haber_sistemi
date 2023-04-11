using HaberSistemi.Core.Insfrastructure;
using HaberSistemi.Data.DataContext;
using HaberSistemi.Data.DataContext.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Core.Repository
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public IEnumerable<Kullanici> GetAll()
        {
            return _context.Kullanicis.Select(x => x);
        }

        public Kullanici GetById(int id)
        {
            return _context.Kullanicis.FirstOrDefault(x => x.ID == id);
        }
        public Kullanici Get(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanicis.FirstOrDefault(expression);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanicis.Where(expression);
        }

        public void Insert(Kullanici obj)
        {
            _context.Kullanicis.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kullanici obj)
        {
            _context.Kullanicis.AddOrUpdate(obj);
        }

        public int Count()
        {
            return _context.Resims.Count();
        }

        public void Delete(int id)
        {
            var Kullanici = GetById(id);
            if (Kullanici != null)
            {
                _context.Kullanicis.Remove(Kullanici);
            }
        }

        public void Delete(Kullanici obj)
        {
            throw new NotImplementedException();
        }
    }
}
