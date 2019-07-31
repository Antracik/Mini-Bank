using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Mini_Bank.Models.ViewModels;
using System.Threading;

namespace Mini_Bank.FileRepo
{
    public class FileRepository<T> : IRepository<T> where T : IBaseModel
    {
        private Semaphore semaphore = new Semaphore(1, 1);
        private List<T> _cachedRepo = null;

        public FileRepository()
        {
           //_cachedRepo = Read();
        }

        private string GetDirectoryPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = Path.Combine(path, "Data");

            Directory.CreateDirectory(path);

            //If for some reason in need of linux file system support, use this
            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
            //   path += "\\MiniBankData";
            //   Directory.CreateDirectory(path);
            //}
            //else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //{
            //   path += "/MiniBankData";
            //   Directory.CreateDirectory(path);
            //}

            return path;
        }

        /// <summary>
        /// Adds the given item to the cached repo, call SaveChanges to commit.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            _cachedRepo = Get().ToList();
            _cachedRepo.Add(item);
        }

        /// <summary>
        /// Adds the given items in a list to the cached repo, call SaveChanges to commit.
        /// </summary>
        /// <param name="rangeList"></param>
        public void AddRange(IEnumerable<T> rangeList)
        {
            _cachedRepo = Get().ToList();
            _cachedRepo.AddRange(rangeList);
        }

        /// <summary>
        /// Replaces the item in the collection with the provided one
        /// </summary>
        /// <param name="item"></param>
        public void Replace(T item)
        {
            _cachedRepo[_cachedRepo.FindIndex(index => item.Id == index.Id)] = item;
        }

        /// <summary>
        /// Reads all the data from a file for the given Type and returns a List<T>
        /// </summary>
        /// <returns></returns>
        private List<T> Read()
        {
            List<T> itemList = new List<T>();

            var ser = new DataContractJsonSerializer(typeof(List<T>));
            string fileName = itemList.GetType().GenericTypeArguments[0].Name;
            string path = GetDirectoryPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            if (!File.Exists(path))
            {
                semaphore.WaitOne();

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    itemList = ser.ReadObject(streamReader.BaseStream) as List<T>;
                }

                semaphore.Release();
            }

            return itemList;
        }

        /// <summary>
        /// Returns the cached repo
        /// </summary>
        /// <returns>_cachedRepo</returns>
        public IEnumerable<T> Get()
        {
            if (_cachedRepo == null)
                return _cachedRepo = Read();
            return _cachedRepo;
        }

        /// <summary>
        /// Saves the changes in the Cache Repo to the file
        /// </summary>
        public void SaveChanges()
        {
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string fileName = _cachedRepo.GetType().GenericTypeArguments[0].Name;
            string path = GetDirectoryPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            ser.WriteObject(stream, _cachedRepo);

            semaphore.WaitOne();

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

            semaphore.Release();
        }

        public void Delete(int id)
        {
            _cachedRepo.RemoveAt(_cachedRepo.FindIndex(item => item.Id == id));
        }

        /// <summary>
        /// Clears all data from the cache withouth reseting it
        /// </summary>
        public void Clear()
        {
            _cachedRepo.Clear();
            _cachedRepo = null;
        }

        /// <summary>
        /// Clears all data from the cache and resets it's data by calling Read()
        /// </summary>
        public void Reset()
        {
            Clear();
            _cachedRepo = Read();
        }
    }
}
