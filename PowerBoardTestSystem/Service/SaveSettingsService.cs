using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PowerBoardTestSystem.Service
{
    class SaveSettingsService
    {
        public string path;
        public string name;

        public SaveSettingsService(string path,string name)
        {
            this.path = path;
            this.name = name;
        }

        public void save(string text)
        {
            File.WriteAllText(path + "/" + name, text);
        }
    }
}
