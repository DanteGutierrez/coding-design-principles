using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommand
{
    public class ColorCommand : ICommand
    {
        private Entity entity = null;
        private string description;
        private string color;
        private string oldColor;
        public ColorCommand(Entity entity, string description, string color)
        {
            this.entity = entity;
            this.description = description;
            this.color = color;
        }
        public void Execute()
        {
            oldColor = entity.GetColor();
            entity.Color(color);
        }

        public void Undo()
        {
            entity.Color(oldColor);
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
