using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Mini_Bank.Models.Repository
{
    public class FileRepository<T> where T : class
    {

        private static string GetPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += @"\MiniBankData";

            Directory.CreateDirectory(path);

            return path;
        }

        public static void AddItem(T item)
        {
            var itemList = new List<T>();
            string fileName = item.GetType().Name;
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();

            fileName += ".json";

            string path = GetPath();

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                itemList = Read();
                File.Delete(path);
            }

            itemList.Add(item);
            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

        }

        public static void AddRange(List<T> rangeList)
        {
            var itemList = new List<T>();
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            string fileName = itemList.GetType().GenericTypeArguments[0].Name;
            string path = GetPath();

            fileName += ".json";

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                itemList = Read();
                File.Delete(path);
            }

            itemList.AddRange(rangeList);
            ser.WriteObject(stream, itemList);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }

        }

        public static List<T> Read()
        {
            var itemList = new List<T>();
            var ser = new DataContractJsonSerializer(typeof(List<T>));
            string fileName = itemList.GetType().GenericTypeArguments[0].Name;

            fileName += ".json";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += @"\MiniBankData";
            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    itemList = ser.ReadObject(streamReader.BaseStream) as List<T>;
                }
            }

            return itemList;
        }
    }
}
