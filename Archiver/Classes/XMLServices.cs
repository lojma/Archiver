using System;
using System.IO;
using System.Xml.Linq;

namespace Archiver
{
    class XMLServices
    {
        
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
            doc.Save("temp.xml");

        }
        public void WriteXMLToEnd(string path)
        {
            FileInfo fi = new FileInfo("temp.xml");
            long displacement = fi.Length;
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Open)))
            {
                writer.Seek(0, SeekOrigin.End);

                using (BinaryReader reader = new BinaryReader(File.Open(fi.Name, FileMode.Open)))
                {
                    writer.Write(Archiver.Classes.BinaryExtenrion.ReadAllBytes(reader));
                }
                writer.Seek(0, SeekOrigin.Begin);
                writer.Write(displacement);
            }
            File.Delete(fi.Name);
        }

        public long FindXML(string pathZIP)
        {
            using (BinaryReader str = new BinaryReader(File.Open(pathZIP, FileMode.Open)))
            {

                long disp = BitConverter.ToInt64(str.ReadBytes(21), 0);

                return disp;
            }
        }
        //public void GETXML(string zipPath, long displacement, Label lbl)
        //{
        //    FileInfo fi = new FileInfo(zipPath);

        //    using (BinaryReader reader = new BinaryReader(File.Open(zipPath, FileMode.Open)))
        //    {
        //        using (BinaryWriter writer = new BinaryWriter(File.Open(fi.DirectoryName + "\\temp.xml", FileMode.CreateNew)))
        //        {
        //            reader.BaseStream.Seek(-displacement, SeekOrigin.End);
        //            writer.Write(reader.ReadAllBytes());
        //        }
        //    }
        //    lbl.Text = zipPath;
        //}
    }
}
