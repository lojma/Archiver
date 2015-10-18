using System.IO;

namespace Archiver
{
    public class StreamsServices
    {
        private const int BUFFER_SIZE = 4096;
        private string _archivePath;
        private string _readedItem;
        private long _displacement;
        private long _writerPosition;
        private long _readerPosition;
        private ProgressBarForm _progressBar;

        public ProgressBarForm ProgressBar
        {
            get
            {
                if (_progressBar == null)
                    _progressBar = new ProgressBarForm();
                return _progressBar;
            }
        }
        public long ReaderPosition
        {
            get { return _readerPosition; }
            set { _readerPosition = value; }
        }
        public long WriterPosition
        {
            get { return _writerPosition; }
            set { _writerPosition = value; }
        }

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
            try
            {
                using (FileStream fs = new FileStream(ReadedItem, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] chunk;
                        chunk = br.ReadBytes(BUFFER_SIZE);
                        ProgressBar.CurrentPosition = System.Convert.ToInt32(br.BaseStream.Position);
                        using (BinaryWriter writer = new BinaryWriter(File.Open(ArchivePath, FileMode.Append)))
                        {
                            Displacement = writer.BaseStream.Position;//при каждом начале нового файла дописываем смещение для него;
                            while (br.BaseStream.Position != fs.Length)
                            {
                                ProgressBar.TotalSize = System.Convert.ToInt32(writer.BaseStream.Position);
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
                System.Console.WriteLine(fileNotFoundExp.FileName + Strings.ioExp);
            }
        }
    }
}