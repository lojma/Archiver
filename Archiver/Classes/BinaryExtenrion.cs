using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Archiver.Classes
{
    public static class BinaryExtenrion
    {
        private static int BUFFER_SIZE = 4096;
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }
    }
}
