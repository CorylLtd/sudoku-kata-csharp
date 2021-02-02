using System;
using SudokuSolver;

var easyGrid = new Grid(new[]
{
    5, 3, 0, 0, 7, 0, 0, 0, 0,
    6, 0, 0, 1, 9, 5, 0, 0, 0,
    0, 9, 8, 0, 0, 0, 0, 6, 0,
    8, 0, 0, 0, 6, 0, 0, 0, 3,
    4, 0, 0, 8, 0, 3, 0, 0, 1,
    7, 0, 0, 0, 2, 0, 0, 0, 6,
    0, 6, 0, 0, 0, 0, 2, 8, 0,
    0, 0, 0, 4, 1, 9, 0, 0, 5,
    0, 0, 0, 0, 8, 0, 0, 7, 9
});

var mediumGrid = new Grid(new[]
{
    0, 4, 2, 7, 9, 0, 0, 0, 0,
    0, 3, 0, 0, 8, 0, 0, 6, 0,
    8, 0, 5, 1, 0, 0, 0, 0, 0,
    0, 0, 4, 0, 7, 0, 0, 0, 0,
    3, 0, 8, 0, 4, 0, 2, 0, 9,
    0, 0, 0, 0, 3, 0, 8, 0, 0,
    0, 0, 0, 0, 0, 4, 9, 0, 7,
    0, 2, 0, 0, 5, 0, 0, 4, 0,
    0, 0, 0, 0, 6, 7, 3, 2, 0
});

var solver = new GridSolver();
var solved = solver.Solve(mediumGrid);
Console.WriteLine(solved is not null ? solved.Display() : "Not Solved");

