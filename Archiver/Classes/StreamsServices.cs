using System.IO;

namespace Archiver
{
    /// <summary>
    /// Класс предоставляет средство записи файлов любых размеров
    /// </summary>
    public class StreamsServices
    {
        private const int BUFFER_SIZE = 4096;
        private string _archivePath;
        private string _readedItem;
        private long _displacement;

        public long Displacement
        {
            get { return _displacement; }
            private set
            {
                if (value > 0)
                {
                    _displacement = value;
                }
                else throw new System.ArgumentException();
            }
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

        public void WriteArchive() //алгоритм записи файлов произвольного размера
        {
            try
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
            catch (FileNotFoundException fileNotFoundExp)
            {
                System.Console.WriteLine(fileNotFoundExp.FileName + Strings.fileNotFoundExp);
            }
            catch (FileLoadException fileLoadExp)
            {
                System.Console.WriteLine(fileLoadExp.FileName + Strings.fileLoadExp);
            }
            catch (EndOfStreamException endOfStreamExp)
            {
                System.Console.WriteLine(endOfStreamExp.Source + Strings.endOfStreamExp);
            }
            catch (IOException IOExp)
            {
                System.Console.WriteLine(IOExp.Source + Strings.ioExp);
            }
        }
    }
}