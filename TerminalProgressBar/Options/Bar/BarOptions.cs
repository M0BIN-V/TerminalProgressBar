namespace TerminalProgressBar.Options.Bar;

public class BarOptions
{
    public int Width { get; set; } = 30;

    public RemainingBar RemainingBar { get; set; } = new()
    {
        Char = '━',
        Color = ConsoleColor.Red,
    };

    public ElapsedBar ElapsedBar { get; set; } = new()
    {
        Char = '━',
        Color = ConsoleColor.Cyan,
    };

    public ConsoleColor CompleteBarColor { get; set; } = ConsoleColor.Green;
}
