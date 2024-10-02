namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Аналитический презентатор (АП)
    /// </summary>
    public class AnalystPresenter : ThingFormat
    {
        public AnalystPresenter(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Аналитический Презентатор";
        }
    }
}
