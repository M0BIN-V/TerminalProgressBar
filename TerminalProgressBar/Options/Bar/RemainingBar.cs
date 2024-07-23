using TerminalProgressBar.Options.Common;

namespace TerminalProgressBar.Options.Bar;

public class RemainingBar : CharBaseOptions
{
    public Start Start { get; set; } = new()
    {
        Char = '╺',
        Color = ConsoleColor.Red,
    };
}

public class Start : CharBaseOptions
{

}
