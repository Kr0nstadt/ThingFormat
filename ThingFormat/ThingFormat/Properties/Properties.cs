namespace ThingFormat.Properties
{
    public class Properties
    {
        public int Point => _point;
        public void AddPoints(int points) => _point += points;

        public Properties()
        {
            _point = 0;
        }

        public Properties(int point)
        {
            _point = point;
        }

        private int _point; 
    }
}
