namespace CozyCafe.Core.Grid
{
    public class Cell
    {
        private bool _isHole;
        private Chip _chip;

        public Cell(bool isHole)
        {
            _isHole = isHole;
        }

        public bool IsEmpty => _chip == null;
        public bool IsHole => _isHole;
        public Chip CurrentChip => _chip;

        public void SetChip(Chip chip)
        {
            if (_isHole)
                return;

            _chip = chip;
        }

        public Chip GetChip()
        {
            Chip temp = _chip;
            _chip = null;
            return temp;
        }
    }
}