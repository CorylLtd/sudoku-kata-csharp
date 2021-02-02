using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public sealed record Vector(IEnumerable<int> Values)
    {
        private bool PrintMembers(StringBuilder builder)
        {
            builder.AppendJoin(' ', Values.Select(v => $"{v}"));
            return true;
        }

        public bool HasValue(int value) => Values.Contains(value);
    }
}