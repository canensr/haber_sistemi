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
    public class RolRepository : IRolRepository
    {

        private readonly HaberContext _context = new HaberContext();


        public IEnumerable<Rol> GetAll()
        {
            return _context.Rols.Select(x => x);
        }

        public Rol GetById(int id)
        {
            return _context.Rols.FirstOrDefault(x => x.ID == id);
        }
        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rols.FirstOrDefault(expression);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rols.Where(expression);
        }

        public void Insert(Rol obj)
        {
            _context.Rols.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            _context.Rols.AddOrUpdate(obj);
        }
        public int Count()
        {
            return _context.Rols.Count();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol != null)
            {
                _context.Rols.Remove(Rol);
            }
        }

        public void Delete(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
