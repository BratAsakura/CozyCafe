namespace CozyCafe.Core.Grid 
{
    public class Chip
    {
        private int _type;

        public Chip(int type)
        {
            _type = type;
        }

        public int Type => _type;

        public bool TrySimilar(Chip chip) =>
            _type == chip.Type;
    }
}