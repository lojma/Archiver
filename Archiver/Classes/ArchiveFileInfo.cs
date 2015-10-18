using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiver.Classes
{
    class ArchiveFileInfo
    {
        public long size;// = Convert.ToInt64(item.Element("size").Value);
        public long disp; //= Convert.ToInt64(item.Element("displacement").Value);
        public string newFilePath; // = extractPath + "//" + item.Element("fileName").Value;
         
    }
}
