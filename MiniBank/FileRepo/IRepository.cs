using System.Collections.Generic;
using Shared;

namespace Mini_Bank.FileRepo
{
    public interface IRepository<T> where T : IBaseModel
    {
        void AddItem(T item);
        void AddRange(IEnumerable<T> rangeList);
        IEnumerable<T> Get();
        /// <summary>
        /// Replaces an item in the repository with the same ID as the provided item. 
        /// Remember to call SaveChanges() to commit changes.
        /// </summary>
        /// <param name="item"></param>
        void Replace(T item);
        /// <summary>
        /// Always call this function when making changes to the repository (eg. Adding, Replacing, Deleting)
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// Delete the item with given ID
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        void Clear();
        void Reset();
    }
}
