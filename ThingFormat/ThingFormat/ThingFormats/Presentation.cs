namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Презентатор (П)
    /// </summary>
    public class Presentation : ThingFormat
    {
        public Presentation(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Презентатор";
        }
    }
}
