namespace ThingFormat.ThingFormats
{
    public class Exeption : ThingFormat
    {
        public Exeption(Diagram diagram) : base(diagram)
        {
        }
        public override string ToString()
        {
            return "Тест пройден некоректно и бессовестно";
        }
    }
}
