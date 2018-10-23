using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundProcessor
{
    class FileItem
    {
        private bool selected;
        private string fileName;

        public bool Selected { get => selected; set => selected = value; }
        public string FileName { get => fileName; set => fileName = value; }

        public FileItem(string fname, bool chn = true) {
            fileName = fname;
            selected = chn;
        }

        public override string ToString() {
            return fileName;
        }
    }
}
