using System;
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
        private long displacement;

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

        public void AddAllFilesToArchive()
        {
            XDocument doc = new XDocument();
            XElement library = new XElement("library");
            doc.Add(library);
            byte[] byteArray = new byte[21];
            using (BinaryWriter writer = new BinaryWriter(File.Open(ArchiveName, FileMode.CreateNew)))
            {
                //пишем в начало нашего архива пустую переменную размером в лонг, в бинарном виде.
                writer.Write(byteArray);
            }
            foreach (var item in FileList)
            {
                Service.ReadedItem = item;
                Service.ArchivePath = ArchiveName;
                Service.WriteArchive();
                displacement = Service.Displacement;
                XmlServices.AddtoXML(doc, item, displacement);
            }
            XmlServices.WriteXMLToEnd(ArchiveName);
        }

        //public static void AddFileToExistArchive(string zipPath, string addFileName, Label zipPathLabel)
        //{
        //    long disp = FindXML(zipPath);
        //    ArchiveUtilities.GETXML(zipPath, disp, zipPathLabel);

        //    FileInfo infoXML = new FileInfo(zipPath);
        //    XDocument doc = XDocument.Load(infoXML.DirectoryName + "\\" + "temp.xml");

        //    WriteArchive(zipPath, doc, addFileName);
        //    WriteXMLToEnd(zipPath);
        //}
        //public static void ExtractALL(string zipPath, string directoryName, string extractPath)
        //{
        //    XDocument doc = XDocument.Load(directoryName + "\\temp.xml");
        //    foreach (var item in doc.Root.Elements())
        //    {
        //        using (BinaryReader reader = new BinaryReader(File.Open(zipPath, FileMode.Open)))
        //        {
        //            reader.BaseStream.Seek(Convert.ToInt64(item.Element("displacement").Value), SeekOrigin.Begin);
        //            using (BinaryWriter writer = new BinaryWriter(File.Create(extractPath + "\\" + item.Element("fileName").Value)))
        //            {
        //                for (long i = 0; i < Convert.ToInt64(item.Element("size").Value); i++)
        //                {
        //                    writer.Write(reader.ReadByte());
        //                }
        //            }
        //        }
        //    }
        //    File.Delete(directoryName + "\\temp.xml");
        //}

        //public static void ExtractSingelFile(string fileName, DataGridView table, string path, string extractPath)
        //{
        //    FileInfo fi = new FileInfo(path);

        //    XDocument doc = XDocument.Load(fi.DirectoryName + "//temp.xml");
        //    foreach (var item in doc.Root.Elements())
        //    {
        //        if (item.Element("fileName").Value == fileName)
        //        {
        //            long size = Convert.ToInt64(item.Element("size").Value);
        //            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        //            {
        //                reader.BaseStream.Seek(Convert.ToInt64(item.Element("displacement").Value), SeekOrigin.Begin);
        //                using (FileStream fs = new FileStream(extractPath + "//" + item.Element("fileName").Value, FileMode.Create, FileAccess.Write))
        //                {
        //                    using (BinaryWriter writer = new BinaryWriter(fs))
        //                    {
        //                        while (writer.BaseStream.Position != size)
        //                        {
        //                            writer.Write(reader.ReadByte());
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
        

