namespace TerminalProgressBar.Options.Status;

public class StatusOptions
{
    public CounterOptions Counter { get; set; } = new();
    public PercentOptions Percent { get; set; } = new();
    public Separator Separator { get; set; } = new();
}
