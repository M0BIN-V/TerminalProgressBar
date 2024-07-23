namespace TerminalProgressBar.Options.Common;

public abstract class OptionsBase
{
    public ConsoleColor Color { get; set; } = ConsoleColor.White;
    public bool IsVisible { get; set; } = true;
}
