using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameBoard
{
    /// <summary>
    /// An entity to be placed on the board. Unlike CellObject, CellEntity allows you to insert things like GUI elements
    /// </summary>
    public interface ICellEntity
    {
        /// <summary>
        /// The element that the entity will hold
        /// </summary>
        object Entity { get; set; }

        /// <summary>
        /// The position the element will have
        /// </summary>
        (int x, int y) Position { get; set; }

        /// <summary>
        /// If the entity is supposed to be visible only for a little while you can set lifetime in milliseconds
        /// </summary>
        long EntityLifetime{ get; set; }
    }
}
