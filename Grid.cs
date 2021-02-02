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

        /// <summary>
        /// Determine if this grid is solved
        /// </summary>
        public bool IsSolved => Values.All(n => n > 0);

        /// <summary>
        /// Produce a clone of this grid, with one new move made
        /// </summary>
        /// <param name="row">Index of row for new move</param>
        /// <param name="col">Index of col for new move</param>
        /// <param name="newValue">New move value</param>
        public Grid VaryGrid(int row, int col, int newValue)
        {
            var newValues = (int[]) Values.Clone();
            newValues[GetOffset(row, col)] = newValue;
            return new Grid(newValues);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < GridSize; i++)
            {
                sb.AppendLine(string.Join(' ', Values.Skip(i * GridSize).Take(GridSize)));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get all the numbers in a row
        /// </summary>
        /// <param name="index">Index of the row</param>
        private Vector Row(int index) => new(Values.Skip(index * GridSize).Take(GridSize).ToArray());

        /// <summary>
        /// Get all the numbers in a column
        /// </summary>
        /// <param name="index">Index of the column</param>
        private Vector Column(int index) => new(Values.Where((_, i) => i % GridSize == index).ToArray());

        /// <summary>
        /// Get all the numbers in a block
        /// </summary>
        /// <param name="row">Row index of a cell in the block</param>
        /// <param name="col">Column index of a cell in the block</param>
        private Vector Block(int row, int col)
        {
            row -= row % BlockSize;
            col -= col % BlockSize;
            var result = new List<int>();
            for (int i = 0; i < BlockSize; i++)
            {
                var offset = GetOffset(row + i, col);
                result.AddRange(Values.Skip(offset).Take(BlockSize));
            }

            return new(result);
        }

        private int GetOffset(int row, int col) => row * GridSize + col;

        private bool IsEmpty(int row, int col) => Values[GetOffset(row, col)] == 0;

        /// <summary>
        /// Get all the potential moves that can be made at the given square
        /// </summary>
        /// <param name="row">Row index of the given square</param>
        /// <param name="col">Column index of the given square</param>
        private Move GetPotentialMove(int row, int col)
        {
            var rowValues = Row(row);
            var colValues = Column(col);
            var blockValues = Block(row, col);
            var possibleValues = Enumerable.Range(1, GridSize)
                .Where(v => !rowValues.HasValue(v) && !colValues.HasValue(v) && !blockValues.HasValue(v))
                .ToArray();
            
            return new Move(row, col, possibleValues);
        }

        /// <summary>
        /// Get the next move by looking at all the squares and determining which
        /// square has the fewest possible values
        /// </summary>
        /// <returns></returns>
        public Move GetNextPotentialMove()
        {
            var possibleMoves = new List<Move>();
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (IsEmpty(row, col))
                    {
                        possibleMoves.Add(GetPotentialMove(row, col));
                    }
                }
            }

            return possibleMoves.OrderBy(m => m.PossibleValues.Length).FirstOrDefault();
        }
    }
}