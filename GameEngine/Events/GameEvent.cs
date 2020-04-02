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
        
        
        public int TriggerChance;
        public Action EventAction;
        public EventTypes EventType;

        public GameEvent(int chance, Action action, EventTypes type)
        {
            TriggerChance = chance;
            EventAction = action;
            EventType = type;
        }
    }
}
