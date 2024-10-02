namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Метафорный аналитик (МА)
    /// </summary>
    public class MetaphoristAnalyst : ThingFormat
    {
        public MetaphoristAnalyst(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Метафорный Аналитик";
        }
    }
}
