namespace KeyBindUI.Framework.Entity;

public class KeyBindListInfo
{
    public string Name { get; set; }
    public FileInfo ConfigFileInfo { get; set; }
    public Dictionary<string, string> KeyBindList { get; set; } = new();
}