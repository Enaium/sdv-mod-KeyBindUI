using System.Reflection;
using StardewModdingAPI;

namespace KeyBindUI.Framework.Entity;

public record KeyBindInfoList(
    (string Name, IMod Instance) Mod,
    List<(PropertyInfo PropertyInfo, object config)> Infos);