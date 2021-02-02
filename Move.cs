namespace SudokuSolver
{
    public record Move(int Row, int Col, int[] PossibleValues);
}