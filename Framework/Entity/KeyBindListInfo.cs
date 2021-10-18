using System.Collections.Generic;
using System.IO;
using StardewModdingAPI.Utilities;

namespace KeyBindUI.Framework.Entity
{
    public class KeyBindListInfo
    {
        public string Name { get; set; }
        public FileInfo ConfigFileInfo { get; set; }
        public Dictionary<string, string> KeyBindList { get; set; } = new Dictionary<string, string>();
    }
}