using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Archiver
{
    class Package
    {
        private string[] _fileList;
        private string _archiveName;
        private StreamsServices _streamsServices;
        private XMLServices _xmlServices;
        private long _displacement;
        private long _totalSize;

        public long TotalSize
        {
            get { return _totalSize; }
            set { _totalSize = value; }
        }
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


        //Вычисление показателей прогресса записи
        public void CreateProgressBar()
        {
            foreach (string file in FileList)
            {
                FileInfo fi = new FileInfo(file);
                TotalSize += fi.Length;
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
                        Service.ReadedItem = item;
                        Service.ArchivePath = ArchiveName;
                        Service.WriteArchive();
                        _displacement = Service.Displacement;
                        XmlServices.XMLPath = ArchiveName;
                        XmlServices.AddtoXML(doc, item, _displacement);
                    }

                    XmlServices.WriteXMLToEnd(ArchiveName);
                }
                catch (IOException)
                {
                    Console.WriteLine(Strings.ioExp);
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
        
        //Открытие архива(поиск XML и запись списка содержащихся в архиве файлов
        public void openArchive()
        {
            XmlServices.XMLPath = ArchiveName;
            XmlServices.GETXML(ArchiveName);
            FileList = XmlServices.GetArchiveFileNames();
            //File.Delete(XmlServices.XMLPath);
        }
        
        //Добавление файла в существующий архив
        public void AddFileToExistArchive(string zipPath, string addFileName)
        {
            ArchiveName = zipPath;
            XmlServices.XMLPath = ArchiveName;
            XmlServices.GETXML(ArchiveName);

            XDocument doc = XDocument.Load(XmlServices.XMLPath);


            Service.ReadedItem = addFileName;
            Service.ArchivePath = ArchiveName;
            Service.WriteArchive();
            _displacement = Service.Displacement;
            XmlServices.XMLPath = ArchiveName;
            XmlServices.AddtoXML(doc, addFileName, _displacement);

            XmlServices.WriteXMLToEnd(ArchiveName);
        }
        
        // Извлечение всех файлов находящихся в архиве в указуную директорию
        public void ExtractALL(string directoryName)
        {

            //XmlServices.GETXML(ArchiveName);
            XDocument doc = XDocument.Load(XmlServices.XMLPath);
            foreach (var item in doc.Root.Elements())
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ArchiveName, FileMode.Open)))
                {
                    string newFileName = directoryName + "\\" + item.Element("fileName").Value;
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
            XDocument doc = XDocument.Load(XmlServices.XMLPath);
            foreach (var item in doc.Root.Elements())
            {
                if (item.Element("fileName").Value == fileName)
                {
                    long size = Convert.ToInt64(item.Element("size").Value);
                    long disp = Convert.ToInt64(item.Element("displacement").Value);
                    string newFilePath = extractPath +"//" + item.Element("fileName").Value;
                    using (BinaryReader reader = new BinaryReader(File.Open(ArchiveName, FileMode.Open)))
                    {
                        reader.BaseStream.Seek(disp, SeekOrigin.Begin);
                        using (FileStream fs = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                        {
                            using (BinaryWriter writer = new BinaryWriter(fs))
                            {
                                while (writer.BaseStream.Position != size)
                                {
                                    writer.Write(reader.ReadByte());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
        

