using System;
using System.Collections.Generic;

namespace Abstraction
{
    public interface ICrud<T>
    {
        T Save(T entity);
        IList<T> GetAll(int id);
        IList<T> GetById(long cedula,string tabla);
        IList<T> GetDetalleOrdenVenta(int id);
    }
}
