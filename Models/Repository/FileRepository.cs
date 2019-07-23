using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.Models.Repository
{
    public class FileRepository<T> where T : IBaseModel
    {

        private static string GetDirectoryPath()
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

        public static void AddItem(T item)
        {
            IEnumerable<T> itemList = Enumerable.Empty<T>();
            string fileName = item.GetType().Name;
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string path = GetDirectoryPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            itemList = Read();

            itemList = itemList.Append(item).ToList();
            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

        }

        public static void AddRange(IEnumerable<T> rangeList)
        {
            IEnumerable<T> itemList = Enumerable.Empty<T>();
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string fileName = itemList.GetType().Name;
            string path = GetDirectoryPath();

            fileName = fileName.Replace("[]", ".json");
            
            path = Path.Combine(path, fileName);

            itemList = Read();

            itemList = itemList.Concat(rangeList).ToList();

            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

        }

        public static IEnumerable<T> Read()
        {
            IEnumerable<T> itemList = Enumerable.Empty<T>();
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            string fileName = itemList.GetType().Name;
            string path = GetDirectoryPath();

            fileName = fileName.Replace("[]", ".json");

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    itemList = ser.ReadObject(streamReader.BaseStream) as IEnumerable<T>;
                }
            }

            return itemList;
        }
    }
}
