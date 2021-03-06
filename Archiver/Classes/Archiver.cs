﻿using System;
using System.IO;
using System.Xml.Linq;

namespace Archiver
{
    /// <summary>
    /// Класс Package являеться классом для реализации всех поставленых задач программы(Упаковка\распаковка отдельного\всех файлов, открытие архива) 
    /// </summary>
    class Package
    {
        private string[] _fileList;
        private string _archiveName;
        private StreamsServices _streamsServices;
        private XMLServices _xmlServices;
        private long _displacement;

        protected XMLServices XmlServices
        {
            get
            {
                if (_xmlServices == null)
                    _xmlServices = new XMLServices();
                return _xmlServices;
            }
        }
        internal string[] FileList
        {
            get { return _fileList; }
            set { _fileList = value; }
        }
        internal string ArchiveName
        {
            get { return _archiveName; }
            set { _archiveName = value; }
        }
        protected StreamsServices Service
        {
            get
            {
                if (_streamsServices == null)
                    _streamsServices = new StreamsServices();
                return _streamsServices;
            }
        }


        // Метод добавления всех выбранных файлов в архив
        public void AddAllFilesToArchive() 
        {
            XDocument doc = new XDocument();
            XElement library = new XElement("library");
            doc.Add(library);
            byte[] byteArray = new byte[21];

            using (FileStream archiveFile = File.Open(ArchiveName, FileMode.CreateNew))
            {
                try
                {
                    using (BinaryWriter writer = new BinaryWriter(archiveFile))
                    {
                        //пишем в начало нашего архива пустую переменную размером в лонг, в бинарном виде.
                        writer.Write(byteArray);
                    }
                    foreach (var item in FileList)
                    {
                        MakeArchive(doc, item);
                    }

                    XmlServices.WriteXMLToEnd(ArchiveName);
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.Source + Strings.ioExp);
                }
                catch (TypeAccessException)
                {
                    Console.WriteLine(Strings.typeAccessExc);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine(Strings.nullRefExp);
                }
            }
        }
        //Задание всех нужных параметров для создания архива
        private void MakeArchive(XDocument doc, string item)
        {
            Service.ReadedItem = item;
            Service.ArchivePath = ArchiveName;
            Service.WriteArchive();
            _displacement = Service.Displacement;
            XmlServices.XMLPath = ArchiveName;
            XmlServices.AddtoXML(doc, item, _displacement);
        }
        
        //Открытие архива(поиск XML и запись списка содержащихся в архиве файлов
        public void openArchive()
        {
            XmlServices.XMLPath = ArchiveName;
            XmlServices.GETXML(ArchiveName);
            FileList = XmlServices.GetArchiveFileNames();
        }
        
        //Добавление файла в существующий архив
        public void AddFileToExistArchive(string zipPath, string addFileName)
        {
            ArchiveName = zipPath;
            XmlServices.XMLPath = ArchiveName;
            XmlServices.GETXML(ArchiveName);

            XDocument doc = XDocument.Load(XmlServices.XMLPath);

            MakeArchive(doc, addFileName);

            XmlServices.WriteXMLToEnd(ArchiveName);
        }
        
        // Извлечение всех файлов находящихся в архиве в указуную директорию
        public void ExtractALL(string directoryName)
        {

            XDocument doc = XDocument.Load(XmlServices.XMLPath);
            foreach (var item in doc.Root.Elements())
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ArchiveName, FileMode.Open)))
                {
                    string newFileName = directoryName + Path.AltDirectorySeparatorChar + item.Element("fileName").Value;
                    long disp = Convert.ToInt64(item.Element("displacement").Value);
                    long newFileSize = Convert.ToInt64(item.Element("size").Value);
                    reader.BaseStream.Seek(disp, SeekOrigin.Begin);
                    using (BinaryWriter writer = new BinaryWriter(File.Create(newFileName)))
                    {
                        for (long i = 0; i < newFileSize; i++)
                        {
                            writer.Write(reader.ReadByte());
                        }
                    }
                }
            }
            File.Delete(XmlServices.XMLPath);
        }
        
        // Выборочное извлечение одного файла из архива
        public void ExtractSingelFile(string fileName, string extractPath)
        {

            Archiver.Classes.ArchiveFileInfo infos = XmlServices.getFileInfo(fileName, extractPath);

            using (BinaryReader reader = new BinaryReader(File.Open(ArchiveName, FileMode.Open)))
            {
                reader.BaseStream.Seek(infos.disp, SeekOrigin.Begin);
                using (FileStream fs = new FileStream(infos.newFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        while (writer.BaseStream.Position != infos.size)
                        {
                            writer.Write(reader.ReadByte());
                        }
                    }
                }
            }
        }
    }
}
        

