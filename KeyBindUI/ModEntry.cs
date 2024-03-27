using EnaiumToolKit.Framework.Screen.Components;
using KeyBindUI.Framework.Gui;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace KeyBindUI;

public class ModEntry : Mod
{
    private static ModEntry _instance;

    public ModEntry()
    {
        _instance = this;
    }

    private readonly Button _keyBindUi = new Button("KeyBindUI", "", 20, 0, 200, 80);

    public override void Entry(IModHelper helper)
    {
        helper.Events.Display.Rendered += (sender, args) =>
        {
            if (Game1.activeClickableMenu is GameMenu gameMenu && gameMenu.currentTab == GameMenu.numberOfTabs)
            {
                _keyBindUi.Render(args.SpriteBatch);
            }
        };

        helper.Events.Input.ButtonPressed += (sender, args) =>
        {
            if (args.Button != SButton.MouseLeft || !_keyBindUi.Hovered) return;
            _keyBindUi.Hovered = false;
            Game1.activeClickableMenu = new KeyBindGui();
            Game1.playSound("drumkit6");
        };
    }

    public static ModEntry GetInstance()
    {
        return _instance;
    }
}