# KeyBindUI
Key bind UI
## Install
1. [Install the latest version of SMAPI](https://smapi.io/).
2. Install [this mod](https://github.com/Enaium-StardewValleyMods/KeyBindUI/releases).
3. Install [EnaiumToolKit](https://github.com/Enaium-StardewValleyMods/EnaiumToolKit/releases).
4. Run the game using SMAPI.
## Support your mod
You can declare a config field in your mod entry class.

```csharp
public class ModEntry : Mod {
    
    public Config Config;
    
    public override void Entry(IModHelper helper) {
        Config = helper.ReadConfig<Config>();
    }
}
```