using Abstraction;
using ApiRest.Abstraction;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> : ICrud<T>
    {

    }
    public class Repository<T> : IRepository<T> where T: IEntity
    {
        IDbContext<T> _ctx;
        public Repository(IDbContext<T> ctx)
        {
            _ctx = ctx;
        }

        public IList<T> GetDetalleOrdenVenta(int id)
        {
           return _ctx.GetDetalleOrdenVenta(id);
        }

        public IList<T> GetAll(int id)
        {
            return _ctx.GetAll(id);
        }

        public IList<T> GetById(long cedula, string tabla)
        {
            return _ctx.GetById(cedula, tabla);
        }

        public T Save(T entity)
        {
            return _ctx.Save(entity);
        }
    }
}
