using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archiver
{
    public partial class MainForm : Form
    {
        private Package _package;
        internal Package Package
        {
            get
            {
                if (_package == null)
                    _package = new Package();
                return _package;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        //Добавление списка файлов находящихся в папке
        private void button_Add_Dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            //openFile.InitialDirectory = "d:\\";
            //openFile.Multiselect = true;
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                dataList.Columns[4].Visible = false;
                foreach (var item in Directory.GetFiles(openFolder.SelectedPath))
                {
                    FileInfo finfo = new FileInfo(item);
                    dataList.Rows.Add(finfo.Name, finfo.FullName, "delete", "not in archive");
                }
                DirSearch(openFolder.SelectedPath);
                
            }
        }
        //Добавление файлов в таблицу
        private void addFiles_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "d:\\";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in openFile.FileNames)
                {
                    FileInfo finfo = new FileInfo(item);
                    dataList.Rows.Add(finfo.Name, finfo.FullName, "delete", "not in archive");
                }
            }
        }
        // Рекурсивный поиск файлов в SubDirectorys
        public void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        FileInfo finfo = new FileInfo(f);
                        if (finfo.Exists != false)
                        {
                            dataList.Rows.Add(finfo.Name, finfo.FullName, "delete", "not in archive");
                        }
                        else Console.WriteLine("Файл " + finfo.FullName + " не существует. Он не будет помещен в архив");
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        //Обробатчик таблицы
        private void deleteRow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //удаление файла из списка при нажатие кнопки соответсвующего ряда
            if (dataList.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
            }
            //Извлечение файла (одного) из архива по нажатию ссылки определенного ряда
            if (dataList.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            {
                FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
                DialogResult result = folderBrowse.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string extractPath = folderBrowse.SelectedPath;
                    string extractingFile = dataList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Package.ExtractSingelFile(extractingFile, extractPath);
                }
            }
        }
        //Создание архива всех файлов находящихся в талице
        private void makeZip_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            saveForm.AddExtension = true;
            saveForm.DefaultExt = ".container";

            if (saveForm.ShowDialog() == DialogResult.OK)
            {
                ProgressBarForm progressBar = new ProgressBarForm();
                progressBar.Show();
                Package.FileList = GetFileList();
                Package.ArchiveName = saveForm.FileName;
                Package.AddAllFilesToArchive();
                MessageBox.Show(Strings.archivatingComplete + Package.ArchiveName);
            }

        }
        //получение из талицы массива строк, содержащего полные имена файлов
        private string[] GetFileList()
        {
            List<string> List = new List<string>();
            for(int i= 0; i< dataList.Rows.Count-1; i++)
            {
                 List.Add(dataList.Rows[i].Cells[1].Value.ToString());
            }
            return List.ToArray();
        }
        //Открытие архива(получение XML и записи имен файлов входящих в архив; дальнейшее помещение их в таблицу для отображения пользователю) 
        private void openZip_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "d:\\";
            openFile.Multiselect = false;
            openFile.Filter = "(*.package)|*.container";
            openFile.FilterIndex = 2;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Package.ArchiveName = openFile.FileName;
                Package.openArchive();
                dataList.Rows.Clear();
                dataList.Columns[1].Visible = false;
                dataList.Columns[2].Visible = false;
                dataList.Columns[3].Visible = false;
                foreach (var item in Package.FileList)
                {
                    dataList.Rows.Add(item);
                }

            }
        }
        //Извлечение всех файлов архива в заданую директорию
        private void extractFullZIP_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            DialogResult result = folderbrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                Package.ExtractALL(folderbrowser.SelectedPath);
            }
        }
        //Добавление файла в существующий архив(выбор целевого архива и файла для записи)
        private void addToExistArchive_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog archiveName = new OpenFileDialog();
            DialogResult result = archiveName.ShowDialog();

            if (result == DialogResult.OK)
            {
                OpenFileDialog addFile = new OpenFileDialog();
                DialogResult addFileResult = addFile.ShowDialog();
                if (addFileResult == DialogResult.OK)
                {
                    Package.AddFileToExistArchive(archiveName.FileName, addFile.FileName);
                }
            }
        }

        
    }
}
