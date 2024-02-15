﻿using HomeControlAPI.Domain;

namespace HomeControlAPI.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T toAdd);
        void Remove(T entity);

        void Update(T entity);
        T? GetById(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
