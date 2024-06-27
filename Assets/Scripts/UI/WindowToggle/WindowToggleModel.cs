using KaifGames.TestClicker.UI.Window;

namespace KaifGames.TestClicker.UI.WindowToggle
{
    public sealed class WindowToggleModel
    {
        public WindowModel Window { get; }

        public WindowToggleModel(WindowModel window)
        {
            Window = window;
        }
    }
}
