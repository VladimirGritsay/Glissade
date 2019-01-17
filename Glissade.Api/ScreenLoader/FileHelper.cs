using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL {
    class FileHelper   {
        string path = "";

        public string GetLink() {
            Entity entity = new Entity();
            while(File.Exists(entity.FileName + entity.Pref + entity.Expansion)) {
                entity.Pref++;
            }
            path = entity.FileName + entity.Pref + entity.Expansion;
            return path;
        }

        public byte[] GetScreen() {
            FileInfo file = new FileInfo(path);
            byte[] ScreenBytes = File.ReadAllBytes(path);
            return ScreenBytes;
        }
    }
}
