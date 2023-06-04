using Abstraction;
using ApiRest.Abstraction;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        //Objecto que permite implementar Entity framework
        DbSet<T> _items;
        ApiDbContext _ctx;

        //Obtenemos nuestro proveedor de datos configurado
        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            //Setear nuestra lista obtenido del objecto
            _items = ctx.Set<T>();
        }

        public IList<T> GetDetalleOrdenVenta(int id)
        {
            return _items.FromSqlRaw("Select * from DetalleOrdenVenta where OrdenVentaId=" + id).ToList();
        }

        public IList<T> GetAll(int id)
        {
            // Verificar si la entidad ya existe en la base de datos
            T existingEntity = _items.FirstOrDefault(i => i.Id.Equals(id));

            if (existingEntity != null)
                return _items.Where(i => i.Id.Equals(id)).ToList();
            else
                return _items.ToList();
        }

        public IList<T> GetById(long cedula,string tabla)
        {
            // Verificar si la entidad ya existe en la base de datos
            T existingEntity = _items.FromSqlRaw("Select * from "+ tabla + " where Cedula=" + cedula).FirstOrDefault();

            if (existingEntity != null)
                return _items.FromSqlRaw("Select * from "+ tabla + " where Cedula=" + cedula).ToList();
            else
                return _items.ToList();
        }

        public T Save(T entity)
        {
            // Verificar si la entidad ya existe en la base de datos
            T existingEntity = _items.FirstOrDefault(i => i.Id.Equals(entity.Id));

            if (existingEntity != null)
                //se actualiza la entidad existente con los valores de la entidad que se pasa como parámetro.
                _ctx.Entry(existingEntity).CurrentValues.SetValues(entity);
            else
                _items.Add(entity);

            // Guardar los cambios
            _ctx.SaveChanges();
            return entity;
        }
    }
}
