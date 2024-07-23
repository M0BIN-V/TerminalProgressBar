using TerminalProgressBar.Options;
using TerminalProgressBar.Options.Bar;
using TerminalProgressBar.Options.Status;

namespace TerminalProgressBar;

public class ProgressBar
{
    public int Top { get; set; } = 0;
    public BarOptions Bar { get; set; } = new();
    public TitleOptions Title { get; set; } = new();
    public StatusOptions Status { get; set; } = new();

    public int MaxValue { get; set; } = 100;

    public void Show(int value)
    {
        var convertedValue = (value * Bar.Width) / MaxValue;

        Console.SetCursorPosition(0, Top);

        ShowTitle();

        ShowBar(convertedValue);

        ShowStatus(convertedValue, value);
    }

    void ShowTitle()
    {
        if (Title.IsVisible)
        {
            Console.ForegroundColor = Title.Color;
            Console.Write(Title.Text);
        }
    }

    void ShowBar(int convertedValue)
    {
        for (int i = 0; i < Bar.Width; i++)
        {
            if (i >= convertedValue)
            {
                Console.ForegroundColor = Bar.RemainingBar.Color;
                if (i == convertedValue)
                {
                    Console.Write(Bar.RemainingBar.Start.Char);
                }
                else
                {
                    Console.Write(Bar.ElapsedBar.Char);
                }
            }
            else
            {
                Console.ForegroundColor = convertedValue == Bar.Width ?
                    Bar.CompleteBarColor : Bar.ElapsedBar.Color;

                Console.Write(Bar.RemainingBar.Char);
            }
        }
    }

    void ShowStatus(int convertedValue, int value)
    {
        if (Status.Percent.IsVisible)
        {
            Console.ForegroundColor = Status.Percent.Color;
            Console.Write($" {GetPercent(convertedValue)}%");
        }

        if (Status.Separator.IsVisible)
        {
            Console.ForegroundColor = Status.Separator.Color;
            Console.Write(Status.Separator.Display);
        }

        if (Status.Counter.IsVisible)
        {
            Console.ForegroundColor = Status.Counter.Color;
            Console.Write($"{value}/{MaxValue} ");
        }

        Console.ResetColor();
    }

    int GetPercent(int value)
    {
        return (value * 100) / Bar.Width;
    }
}
