using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL {
    class FileHelper  {
        public string NameGeneration() {
            Entity entity = new Entity();
            while(File.Exists(entity.FileName + entity.Pref + entity.Expansion)) {
                entity.Pref++;
            }
            string path = entity.FileName + entity.Pref + entity.Expansion;
            return path;
        }
    }
}
