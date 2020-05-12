using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameBoard
{
    /// <summary>
    /// A class to handle all the keyboard inputs
    /// </summary>
    public class KeyboardInputHandler
    {
        /// <summary>
        /// A function to send the keyboard input to the right classes based on what state the game is in
        /// </summary>
        /// <param name="eVirtualKey">Keyboard input</param>
        /// <param name="cellObject">The object that is going to me manipulated</param>
        public static void HandleInput(VirtualKey eVirtualKey, ICellObject cellObject)
        {
            switch (Game.Instance.CurrentGameState)
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
