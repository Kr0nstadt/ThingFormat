namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Презентационный аналитик (ПА)
    /// </summary>
    public class PresenterAnalyst : ThingFormat
    {
        public PresenterAnalyst(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Презентационный Аналитик";
        }
    }
}
