namespace ThingFormat.ThingFormats
{
    /// <summary>
    /// Системный презентатор (СП)
    /// </summary>
    public class SystemPresenter : ThingFormat
    {
        public SystemPresenter(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Системный Презентатор";
        }
    }
}
