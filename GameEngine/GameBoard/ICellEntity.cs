using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameBoard
{
    public interface ICellEntity
    {
        object Entity { get; set; }
        (int x, int y) Position { get; set; }
        long EntityLifetime{ get; set; }
    }
}
