using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "d:\\";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in openFile.FileNames)
                {
                    dataList.Columns[4].Visible = false;
                    System.IO.FileInfo finfo = new System.IO.FileInfo(item);
                    dataList.Rows.Add(finfo.Name, finfo.FullName, "delete", "not in archive");
                }
            }
        }

        private void deleteRow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataList.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
            }
            if (dataList.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            {
            }
        }

        private void makeZip_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            saveForm.AddExtension = true;
            saveForm.DefaultExt = ".container";

            if (saveForm.ShowDialog() == DialogResult.OK)
            {
                Package.FileList = GetFileList();
                Package.ArchiveName = saveForm.FileName;
                Package.AddAllFilesToArchive();
            }

        }

        private string[] GetFileList()
        {
            List<string> List = new List<string>();
            for(int i= 0; i< dataList.Rows.Count-1; i++)
            {
                 List.Add(dataList.Rows[i].Cells[1].Value.ToString());
            }
            return List.ToArray();
        }

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

            }
        }

        private void extractFullZIP_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            DialogResult result = folderbrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
               //Package.ExtractALL(testGetter, )
            }
        }

        private void addToExistArchive_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDial = new OpenFileDialog();
            DialogResult result = openFileDial.ShowDialog();

            if (result == DialogResult.OK)
            {
                OpenFileDialog addFile = new OpenFileDialog();
                DialogResult addFileResult = addFile.ShowDialog();
                if (addFileResult == DialogResult.OK)
                {

                }
            }
        }
    }
}
