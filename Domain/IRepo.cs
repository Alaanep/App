﻿namespace App.Domain
{
    public interface IRepo<T> : IBaseRepo<T> where T : Entity { }
    public interface IBaseRepo<T> where T : Entity {
        //crud
        bool Add(T obj);
        T Get(string id);
        List<T> Get();
        bool Update(T obj);
        bool Delete(string id);

        Task<bool> AddAsync(T obj);
        Task<T> GetAsync(string id);
        Task<List<T>> GetAsync();
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
