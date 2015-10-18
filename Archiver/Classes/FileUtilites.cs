using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Archiver.Classes
{
    public static class FileUtilites
    {
        //Размео буфера чтения\записи
        private static int BUFFER_SIZE = 4096;
        ///Чтение файла до его окончания
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }

        // Рекурсивный поиск файлов в SubDirectorys
        public static List<string> DirSearch(string sDir)
        {
            List<string> fileNames = new List<string>();
            foreach (var item in GetFiles(sDir))
            {
                fileNames.Add(item);
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (var item in GetFiles(d))
                {
                    fileNames.Add(item);
                }
                DirSearch(d);
            }
            return fileNames;
        }
        //Получение файлов в папке
        private static List<string> GetFiles(string d)
        {
            List<String> retList = new List<string>();
            foreach (string f in Directory.GetFiles(d))
            {
                FileInfo finfo = new FileInfo(f);
                if (finfo.Exists != false)
                {
                    retList.Add(finfo.FullName);

                }
            }
            return retList;
        }
    }
}
