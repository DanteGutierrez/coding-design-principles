using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommand
{
    public class MoveCommand : ICommand
    {
        private int x = 0;
        private int y = 0;
        private string description;
        private Entity entity = null;

        public MoveCommand(Entity entity, string description, int x, int y)
        {
            this.entity = entity;
            this.description = description;
            this.x = x;
            this.y = y;
        }

        public void Execute()
        {
            entity.Adjust(x, y);
        }

        public void Undo()
        {
            entity.Adjust(-1 * x, -1 * y);
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
