using System;
using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using KeyBindUI.Framework.Entity;
using KeyBindUI.Framework.Screen;

namespace KeyBindUI.Framework.Gui;

public class KeyBindListGui : ScreenGui
{
    public KeyBindListGui(KeyBindListInfo keyBindListInfo) : base(keyBindListInfo.Name)
    {
        foreach (var keyValuePair in keyBindListInfo.KeyBindList)
        {
            AddElement(new Button(keyValuePair.Key,
                ModEntry.GetInstance().Helper.Translation.Get("KeyBindUI.Framework.Screen.ModsGui.KeySetting"))
            {
                OnLeftClicked = () =>
                {
                    OpenScreenGui(
                        new ModKeyBindListGui(keyBindListInfo,
                            new Tuple<string, string>(keyValuePair.Key, keyValuePair.Value)));
                }
            });
        }
    }
}