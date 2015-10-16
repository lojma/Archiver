using System.IO;

namespace Archiver
{
    public class StreamsServices
    {
        private const int BUFFER_SIZE = 4096;
        private string _archivePath;
        private string _readedItem;
        private long _displacement;

        public long Displacement
        {
            get { return _displacement; }
            private set { _displacement = value; }
        }
        public string ReadedItem
        {
            get { return _readedItem; }
            set { _readedItem = value; }
        }
        public string ArchivePath
        {
            get { return _archivePath; }
            set { _archivePath = value; }
        }

        public void WriteArchive() //алгоритм записи файлов любого размера
        {
            using (FileStream fs = new FileStream(ReadedItem, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] chunk;
                    chunk = br.ReadBytes(BUFFER_SIZE);
                    using (BinaryWriter writer = new BinaryWriter(File.Open(ArchivePath, FileMode.Append)))
                    {
                        Displacement = writer.BaseStream.Position;//при каждом начале нового файла дописываем смещение для него;
                        while (br.BaseStream.Position != fs.Length)
                        {
                            writer.Write(chunk);
                            chunk = br.ReadBytes(BUFFER_SIZE);
                        }
                        writer.Write(chunk);
                    }
                }
            }
        }
    }
}