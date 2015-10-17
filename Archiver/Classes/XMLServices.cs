using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Archiver
{
    class XMLServices
    {
        private string _XMLPath;
        private string _XMLName = "temp.xml";
        
        public string XMLPath
        {
            get { return _XMLPath; }
            set 
            {
                FileInfo fi = new FileInfo(value);
                string newPathXML = fi.DirectoryName + "\\" + _XMLName;
                _XMLPath = newPathXML; 
            }
        }
        
        //Запись информации о добавленом файле в XML
        public void AddtoXML(XDocument doc, string name, long displace)
        {

            FileInfo temp = new FileInfo(name);
            XElement file = new XElement("file");
            file.Add(new XAttribute("name", name));

            XElement fileName = new XElement("fileName");
            fileName.Value = temp.Name;
            file.Add(fileName);

            XElement type = new XElement("type");
            type.Value = temp.Extension.ToString();
            file.Add(type);

            XElement size = new XElement("size");
            size.Value = temp.Length.ToString();
            file.Add(size);

            XElement displacement = new XElement("displacement");
            displacement.Value = displace.ToString();
            file.Add(displacement);


            doc.Root.Add(file);
            doc.Save(XMLPath);

        }
        //Запись файла XML и его смещения по отношению к концу архива
        public void WriteXMLToEnd(string path)
        {
            FileInfo fi = new FileInfo(XMLPath);
            long displacement = fi.Length;
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                writer.Seek(0, SeekOrigin.End);

                using (BinaryReader reader = new BinaryReader(File.Open(XMLPath, FileMode.Open)))
                {
                    writer.Write(Archiver.Classes.BinaryExtenrion.ReadAllBytes(reader));
                }
                writer.Seek(0, SeekOrigin.Begin);
                writer.Write(displacement);
            }
            File.Delete(XMLPath);
        }
        //Получение XML-файла из архива
        public void GETXML(string ArchiveName)
        {
            FileInfo fi = new FileInfo(XMLPath);

            using (BinaryReader reader = new BinaryReader(File.Open(ArchiveName, FileMode.Open)))
            {
                long disp = BitConverter.ToInt64(reader.ReadBytes(21), 0);
                using (BinaryWriter writer = new BinaryWriter(File.Open(XMLPath, FileMode.CreateNew)))
                {
                    reader.BaseStream.Seek(-disp, SeekOrigin.End);
                    writer.Write(Archiver.Classes.BinaryExtenrion.ReadAllBytes(reader));
                }
            }
        }
        //Получение списка имен файлов находящихся в архиве
        public string[] GetArchiveFileNames()
        {
            List<string> List = new List<string>();
            XDocument doc = XDocument.Load(XMLPath);
            foreach (var item in doc.Root.Elements())
            {
                List.Add(item.Element("fileName").Value);
            }
            return List.ToArray();
        }
    }
}
