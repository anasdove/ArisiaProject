using System;
using System.Collections;
using System.Collections.Generic;

namespace ArisiaProject.Domain
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Add(ICollection<T> items);

        void Update(T item);

        void Update(ICollection<T> items);

        void Remove(T item);

        void Remove(ICollection<T> items);

        T GetById(Guid itemId);

        T GetByName(string name);

        ICollection<T> GetAll();
    }
}
