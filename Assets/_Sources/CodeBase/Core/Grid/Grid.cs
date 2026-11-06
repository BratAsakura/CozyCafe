using System;

namespace CozyCafe.Core.Grid
{
    public class Grid
    {
        private Cell[,] _cells;
        private BoardShape _board;
        private Random _random = new();
        public Cell[,] Cells => _cells;

        public Grid(BoardShape board)
        {
            _board = board;
            _cells = new Cell[board.Width, board.Height];

            for (int x = 0; x < _board.Width; x++)
            {
                for (int y = 0; y < _board.Height; y++)
                {
                    if (_board.IsHole(x, y))
                        _cells[x, y] = new(true);
                    else
                        _cells[x, y] = new(false);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0)
                return null;
            else if (x > _board.Width)
                return null;

            if (y < 0)
                return null;
            else if (y > _board.Height)
                return null;

            return _cells[x, y];
        }

        public void FillRandom(Chip[] availableChips)
        {
            int randIndex;

            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    if (IsValidCell(x,y))
                    {
                        randIndex = _random.Next(0, availableChips.Length);
                        Chip chip = availableChips[randIndex];
                        _cells[x, y].SetChip(chip);
                    }
                }
            }
        }

        private bool IsValidCell(int x, int y)
        {
            if (x < 0 || x > _cells.GetLength(0))
                return false;
            else if (y < 0 || y > _cells.GetLength(1))
                return false;
            else if (_cells[x, y].IsHole)
                return false;
            else 
                return true;
        }
    }
}