using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Area
    {
        public Cell[][] AreaGrid
        {
            get => default;
            set
            {
            }
        }

        public Area()
        {
        }

        public Area(int width, int height)
        {
            setAreaGrid(width, height);
        }

        public void setAreaGrid(int width, int height)
        {
            // instantiate area grid with a cell object in each cell
            AreaGrid = new Cell[height][];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    AreaGrid[height][width] = new Cell();
                }
            }
        }
    }
}