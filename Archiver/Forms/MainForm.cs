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
                Package.FileList = openFile.FileNames;
                Package.ArchiveName = "testGetter";
                Package.AddAllFilesToArchive();
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


            }

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


            }
        }

        private void extractFullZIP_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            DialogResult result = folderbrowser.ShowDialog();
            if (result == DialogResult.OK)
            {

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
