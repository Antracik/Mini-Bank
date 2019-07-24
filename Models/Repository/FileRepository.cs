using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Mini_Bank.Models.ViewModels;
using System.Threading;

namespace Mini_Bank.Models.Repository
{
    public class FileRepository<T> : IRepository<T> where T : IBaseModel
    {
        private Semaphore semaphore = new Semaphore(1, 1);
        private List<T> _cachedRepo;

        public FileRepository()
        {
            Read();
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

        public void AddItem(T item)
        {
            List<T> itemList;
            string fileName = item.GetType().Name;
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string path = GetDirectoryPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            semaphore.WaitOne();

            itemList = Read();
            itemList.Add(item);

            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

            semaphore.Release();
        }

        public void AddRange(IEnumerable<T> rangeList)
        {
            List<T> itemList;
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string fileName = rangeList.GetType().GenericTypeArguments[0].Name;
            string path = GetDirectoryPath();

            fileName += ".json";
            
            path = Path.Combine(path, fileName);

            semaphore.WaitOne();
            
            itemList = Read();
            itemList.AddRange(rangeList);
           
            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

            semaphore.Release();
        }

        public List<T> Read()
        {
            List<T> itemList = new List<T>();
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            string fileName = itemList.GetType().GenericTypeArguments[0].Name;
            string path = GetDirectoryPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    itemList = ser.ReadObject(streamReader.BaseStream) as List<T>;
                }
            }

            _cachedRepo = itemList;

            return itemList;
        }

        public List<T> GetCachedRepo()
        {
            return _cachedRepo;
        }
    }
}
