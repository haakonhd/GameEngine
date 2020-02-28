﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.GameBoard;

namespace GameEngine.Implementation.Pokemon.FactoryObjects
{
    class MessageBox : ICellEntity
    {
        public object Entity { get; set; }
        public (int x, int y) Position { get; set; }
        public long EntityLifetime { get; set; }

        public MessageBox()
        {

        }
    }
}