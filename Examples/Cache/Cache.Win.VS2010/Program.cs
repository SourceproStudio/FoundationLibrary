using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourcePro.Csharp.Practices.FoundationLibrary.Caching;
using System.IO;

namespace SourcePro.Csharp.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name : ");
            Person person = new Person() { Name = Console.ReadLine() };

            //写入缓存。
            Cache cache = new Cache();
            cache.Add(
                new KeyValuePair<string, object>("PersonData", person),
                new CacheItemDependency(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CacheDependency.txt")));

            person = cache["PersonData"] as Person;

            Console.WriteLine("Cached Person's Name is : {0}", person);

            //更新缓存依赖文件。
            AppendText();

            object cacheData = cache["PersonData"];

            if (cacheData == null)
                Console.WriteLine("Cached Data was removed !");

            Console.ReadLine();
        }

        #region AppendText
        static private void AppendText()
        {
            using (Stream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CacheDependency.txt"), FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    try
                    {
                        writer.WriteLine("Updated time : {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    finally
                    {
                        writer.Close();
                        fileStream.Close();
                    }
                }
            }
        }
        #endregion
    }

    #region Person
    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        override public string ToString()
        {
            return string.Format("Name = {0}", this.Name);
        }
    }
    #endregion
}
