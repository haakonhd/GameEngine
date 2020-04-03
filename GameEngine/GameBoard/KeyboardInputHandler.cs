using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameBoard
{
    public class KeyboardInputHandler
    {

        public static void HandleInput(VirtualKey eVirtualKey, ICellObject cellObject)
        {
            switch (Game.GetInstance().CurrentGameState)
            {
                case Game.GameState.Movement:
                    Movement.HandleInput(eVirtualKey, cellObject);
                    break;

                case Game.GameState.Dialog:
                    //TODO add logic
                    break;

                case Game.GameState.Combat:
                    //TODO add logic
                    break;

                case Game.GameState.Menu:
                    //TODO add logic
                    break;
            }
        }

    }
}
