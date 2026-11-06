using CozyCafe.Core.Grid;
using UnityEngine;
using Grid = CozyCafe.Core.Grid.Grid;

namespace CozyCafe.Debugging 
{ 
    public class CafeTester : MonoBehaviour
    {
        [SerializeField] private BoardShape _board;
        private Chip _chip;
        private Cell _cell;
        private Chip[] _chips;
        private Cell _holeCell;
        private Grid _grid;

        private void Awake()
        {
            _chip = new(1);
            _cell = new(false);
            _holeCell = new(true);
            _grid = new(_board);
            _chips = new Chip[5];

            for (int i = 0; i < _chips.Length; i++)
                _chips[i] = new Chip(i);
        }

        private void Start()
        {
            Debug.Log("---Проверка клетки---");
            _cell.SetChip(_chip);
            Debug.Log($"Клетка пустая: {_cell.IsEmpty}");
            _cell.GetChip();
            Debug.Log($"Клетка пустая: {_cell.IsEmpty}");

            _holeCell.SetChip(_chip);
            Debug.Log($"Клетка-дырка пустая: {_holeCell.IsEmpty}");

            Debug.Log("---Проверка доски---");
            Debug.Log($"Длина доски: {_board.Height}");
            Debug.Log($"Высота доски: {_board.Height}");
            Debug.Log($"Проверка координат  0,0: {_board.IsHole(0, 0)}");
            Debug.Log($"Проверка координат  3,3: {_board.IsHole(3, 3)}");
            Debug.Log($"Проверка координат  20,5: {_board.IsHole(20, 5)}");
            Debug.Log($"Проверка координат  2,12: {_board.IsHole(2, 12)}");
            Debug.Log($"Проверка координат  33,22: {_board.IsHole(33, 22)}");
            Debug.Log("---Проверка Сетки---");
            _grid.FillRandom(_chips);
            PrintGrid();
            
        }

        public void PrintGrid()
        {
            System.Text.StringBuilder sb = new();

            for (int y = 0; y < _grid.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < _grid.Cells.GetLength(0); x++)
                {
                    Cell cell = _grid.GetCell(x, y);

                    if(cell != null)
                    {
                        if (cell.IsHole)
                            sb.Append(".");
                        else if (cell.IsEmpty)
                            sb.Append(" ");
                        else
                            sb.Append(cell.CurrentChip.Type.ToString());
                    }  
                }
                sb.Append("\n");
            }

            Debug.Log(sb.ToString());
        }
    }
}