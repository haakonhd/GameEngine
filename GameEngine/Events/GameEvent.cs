using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Events
{
    public class GameEvent
    {
        public enum EventTypes
        {
            Collision,
            Interaction,
            Enter
        }
        
        /// <summary>
        /// 0 means 0%, 1 means 100% chance for event to trigger
        /// </summary>
        public double TriggerChance;
        /// <summary>
        /// An action can be triggered when interacted with on the game board
        /// </summary>
        public Action EventAction;
        /// <summary>
        /// Collision, Interaction, or Enter
        /// </summary>
        public EventTypes EventType;

        public GameEvent(double chance, Action action, EventTypes type)
        {
            TriggerChance = chance;
            EventAction = action;
            EventType = type;
        }
    }
}
