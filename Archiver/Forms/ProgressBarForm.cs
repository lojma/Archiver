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
    public partial class ProgressBarForm : Form
    {
        private int _totalSize;
        private int _currentPosition;
        public int TotalSize
        {
            get { return _totalSize; }
            set { _totalSize = value; }
        }
        public int CurrentPosition
        {
            get { return _currentPosition; }
            set { _currentPosition = value; }
        }
        public ProgressBarForm()
        {
            InitializeComponent();
        }
    }
}
