using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    /// <summary>
    /// Represents a square in the game grid. Can hold multiple cell objects
    /// </summary>
    public class Cell
    {
        public List<ICellObject> CellObjects{ get; set; }

        public Cell()
        {
            CellObjects = new List<ICellObject>();
        }
    }
}