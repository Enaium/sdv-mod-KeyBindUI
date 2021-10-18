using System;
using System.Collections.Generic;
using System.IO;
using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using KeyBindUI.Framework.Entity;
using KeyBindUI.Framework.Screen;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace KeyBindUI.Framework.Gui
{
    public class KeyBindGui : ScreenGui
    {
        public KeyBindGui() : base("Key Bind UI")
        {
            var mods = Environment.CurrentDirectory + "/" + "Mods";
            foreach (var info in new DirectoryInfo(mods).GetDirectories())
            {
                var keyBindListInfo = new KeyBindListInfo();
                var config = new FileInfo(info.FullName + "/config.json");
                keyBindListInfo.ConfigFileInfo = config;
                if (!config.Exists)
                {
                    continue;
                }

                keyBindListInfo.Name = info.Name;
                var read = new JsonTextReader(config.OpenText());
                var readFrom = (JObject) JToken.ReadFrom(read);
                read.Close();
                foreach (var keyValuePair in readFrom)
                {
                    if (keyValuePair.Value == null || keyValuePair.Value.Type != JTokenType.String) continue;
                    try
                    {
                        keyBindListInfo.KeyBindList[keyValuePair.Key] =
                            KeybindList.Parse(keyValuePair.Value.ToString()).ToString();
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }

                AddElement(new Button(info.Name,
                    ModEntry.GetInstance().Helper.Translation.Get("KeyBindUI.Framework.Screen.ModsGui.KeySetting"))
                {
                    OnLeftClicked = () => { OpenScreenGui(new KeyBindListGui(keyBindListInfo)); }
                });
            }
        }
    }
}