using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public record Grid(int[] Values)
    {
        static readonly int GridSize = 9;

        private int BlockSize => (int) Math.Floor(Math.Sqrt(GridSize));

        public Grid VaryGrid(int row, int col, int newValue)
        {
            var newValues = (int[]) Values.Clone();
            newValues[GetOffset(row, col)] = newValue;
            return new Grid(newValues);
        }

        public StringBuilder Display()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < GridSize; i++)
            {
                sb.AppendLine(string.Join(' ', Values.Skip(i * GridSize).Take(GridSize)));
            }

            return sb;
        }

        public Vector Row(int index) => new(Values.Skip(index * GridSize).Take(GridSize).ToArray());

        public Vector Column(int index) => new(Values.Where((_, i) => i % GridSize == index).ToArray());

        public Vector Block(int row, int col)
        {
            row *= BlockSize;
            col *= BlockSize;
            var result = new List<int>();
            for (int i = 0; i < BlockSize; i++)
            {
                var offset = GetOffset(row + i, col);
                result.AddRange(Values.Skip(offset).Take(BlockSize));
            }

            return new(result.ToArray());
        }

        private int GetOffset(int row, int col) => row * GridSize + col;
        public int GetSquare(int row, int col) => Values[GetOffset(row, col)];
        public void SetSquare(int row, int col, int value) => Values[GetOffset(row, col)] = value;
        public bool IsFull => Values.All(n => n > 0);

        public Move PotentialMove(int row, int col)
        {
            var possibleValues = new int[GridSize];
            for (int i = 0; i < GridSize; i++)
            {
                possibleValues[i] = i + 1;
            }

            var rowValues = Row(row);
            var colValues = Column(col);
            var blockValues = Block(row / BlockSize, col / BlockSize);
            return new Move(row, col, possibleValues
                .Where(v =>
                    !rowValues.HasValue(v) && !colValues.HasValue(v) && !blockValues.HasValue(v))
                .ToArray());
        }

        public Move NextPotentialMove()
        {
            var possibleMoves = new List<Move>();
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (GetSquare(row, col) == 0)
                    {
                        possibleMoves.Add(PotentialMove(row, col));
                    }
                }
            }

            return possibleMoves.OrderBy(m => m.PossibleValues.Length).FirstOrDefault();
        }
    }
}