namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Презентационный системщик (ПС)
    /// </summary>
    public class PresenterSystem : ThingFormat
    {
        public PresenterSystem(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Презентационный Системщик";
        }
    }
}
