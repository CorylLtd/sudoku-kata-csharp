﻿using System;
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
var hardGrid = new Grid(new[]
{
    0, 0, 0, 0, 0, 8, 0, 9, 0,
    1, 9, 0, 3, 0, 0, 4, 0, 0,
    0, 0, 0, 0, 0, 7, 0, 5, 6,
    0, 0, 9, 0, 0, 0, 5, 0, 4,
    2, 6, 0, 0, 0, 0, 0, 1, 9,
    4, 0, 3, 0, 0, 0, 6, 0, 0,
    5, 3, 0, 2, 0, 0, 0, 0, 0,
    0, 0, 1, 0, 0, 3, 0, 2, 7,
    0, 8, 0, 1, 0, 0, 0, 0, 0
});
var evilGrid = new Grid(new[]
{
    0, 1, 0, 0, 0, 0, 0, 0, 8,
    6, 0, 4, 0, 1, 0, 0, 0, 0,
    0, 0, 0, 8, 0, 2, 6, 0, 0,
    4, 0, 2, 0, 0, 5, 0, 0, 9,
    0, 0, 0, 0, 4, 0, 0, 0, 0,
    3, 0, 0, 9, 0, 0, 5, 0, 4,
    0, 0, 1, 7, 0, 8, 0, 0, 0,
    0, 0, 0, 0, 3, 0, 1, 0, 2,
    9, 0, 0, 0, 0, 0, 0, 5, 0
});
var grids = new[]
    {("Easy Grid", easyGrid), ("Medium Grid", mediumGrid), ("Hard Grid", hardGrid), ("Evil Grid", evilGrid)};
var solver = new GridSolver();
foreach (var grid in grids)
{
    Console.WriteLine(grid.Item1);
    var solved = solver.Solve(grid.Item2);
    Console.WriteLine(solved is not null ? solved : "Not Solved");
}