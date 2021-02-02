using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public class GridSolver
    {
        public Grid Solve(Grid grid) => FindSolution(new[] {grid});

        private Grid FindSolution(IEnumerable<Grid> grids) =>
            grids.Select(SolveGrid).FirstOrDefault(solvedGrid => solvedGrid is not null);

        private Grid SolveGrid(Grid grid)
        {
            if (grid.IsSolved) return grid;
            var nextMove = grid.GetNextPotentialMove();
            if (nextMove is not null)
            {
                var possibleGrids = nextMove.PossibleValues.Select(
                    pv => grid.VaryGrid(nextMove.Row, nextMove.Col, pv));

                return FindSolution(possibleGrids);
            }

            return null;
        }
    }
}