namespace TerminalProgressBar;

public class ProgressBar
{
    #region Properties
    public int Width { get; init; } = 20;
    public int Max { get; init; } = 100;
    public string Title { get; init; } = "";
    public char RemainingBarChar { get; init; } = '━';
    public char ElapsedBarBarChar { get; init; } = '━';
    public char EndElapsedBarChar { get; init; } = '╺';
    public ConsoleColor ReminingBarColor { get; init; } = ConsoleColor.Red;
    public ConsoleColor ElapsedBarColor { get; init; } = ConsoleColor.Blue;
    public ConsoleColor CompleteBarColor { get; init; } = ConsoleColor.Green;
    #endregion

    public void Show(int value)
    {
        value = (value * Width) / Max;

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(Title + " ");

        for (int i = 0; i < Width; i++)
        {
            if (i >= value)
            {
                Console.ForegroundColor = ReminingBarColor;
                if (i == value)
                {
                    Console.Write(EndElapsedBarChar);
                }
                else
                {
                    Console.Write(ElapsedBarBarChar);
                }
            }
            else
            {
                Console.ForegroundColor = value == Width ? CompleteBarColor : ElapsedBarColor;

                Console.Write(RemainingBarChar);
            }
        }
        Console.ResetColor();

        Console.Write($" {GetPercent(value)}% ");
    }

    int GetPercent(int value)
    {
        return (value * 100) / Width;
    }
}
