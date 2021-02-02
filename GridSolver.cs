using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class GridSolver
    {
        public Grid Solve(Grid grid)
        {
            return FindSolution(new List<Grid> {grid});
        }

        private Grid FindSolution(List<Grid> grids)
        {
            return grids.Select(SolveGrid).FirstOrDefault();
        }

        private Grid SolveGrid(Grid grid)
        {
            if (grid.IsFull) return grid;
            var nextMove = grid.NextPotentialMove();
            if (nextMove is not null)
            {
                var possibleGrids = nextMove.PossibleValues.Select(
                        pv => grid.VaryGrid(nextMove.Row, nextMove.Col, pv))
                    .ToList();
                return FindSolution(possibleGrids);
            }

            return null;
        }
    }
}