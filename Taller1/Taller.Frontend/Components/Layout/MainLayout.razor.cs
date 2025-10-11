using MudBlazor;
using MudBlazor.Utilities;

namespace Taller.Frontend.Components.Layout;

public partial class MainLayout
{
    private bool _drawerOpen = true;
    private bool _isDarkMode = true;
    private MudTheme? _theme = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _theme = new()
        {
            PaletteLight = _lightPalette,
            PaletteDark = _darkPalette,
            LayoutProperties = new LayoutProperties()
        };
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private void DarkModeToggle()
    {
        _isDarkMode = !_isDarkMode;
    }

    private readonly PaletteLight _lightPalette = new()
    {
        Primary = Colors.Gray.Lighten3,
        Background = Colors.Gray.Lighten3,
        Black = "#110e2d",
        AppbarText = "#FFFFFF",
        AppbarBackground = Colors.Teal.Default,
        DrawerBackground = Colors.Teal.Lighten2,
        DrawerText = Colors.Gray.Darken3,
        GrayLight = "#e8e8e8",
        GrayLighter = "#f9f9f9",
        Info = Colors.Teal.Accent4,
    };

    private readonly PaletteDark _darkPalette = new()
    {
        Primary = Colors.Teal.Darken1,
        Surface = Colors.Gray.Darken3,
        Background = Colors.Gray.Darken3,
        BackgroundGray = Colors.Gray.Darken2,
        AppbarText = "#FFFFFF",
        AppbarBackground = Colors.Teal.Default,
        DrawerBackground = Colors.Gray.Darken4,
        ActionDefault = "#74718e",
        ActionDisabled = "#9999994d",
        ActionDisabledBackground = "#605f6d4d",
        TextPrimary = "#b2b0bf",
        TextSecondary = "#92929f",
        TextDisabled = "#ffffff33",
        DrawerIcon = "#92929f",
        DrawerText = "#92929f",
        GrayLight = "#2a2833",
        GrayLighter = "#1e1e2d",
        Info = Colors.Teal.Darken1,
        Success = "#3dcb6c",
        Warning = "#ffb545",
        Error = "#ff3f5f",
        LinesDefault = "#33323e",
        TableLines = "#33323e",
        Divider = "#292838",
        OverlayLight = "#1e1e2d80",
    };

    public string DarkLightModeButtonIcon => _isDarkMode switch
    {
        true => Icons.Material.Rounded.AutoMode,
        false => Icons.Material.Outlined.DarkMode,
    };
}