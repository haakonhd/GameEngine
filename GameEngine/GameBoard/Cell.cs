using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Cell
    {
        public List<ICellObject> CellObjects{ get; set; }

        public Cell()
        {
            CellObjects = new List<ICellObject>();
        }
    }
}