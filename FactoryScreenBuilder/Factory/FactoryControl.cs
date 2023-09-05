using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryScreenBuilder.Factory
{
    public class FactoryControl
    {
        public string Text { get; set; } = "";
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Top { get; set; } = 0;
        public int Left { get; set; } = 0;
        public FactoryControlType Type { get; set; } = FactoryControlType.Other;
        public FactoryControl(string text, int height, int width, int top, int left, FactoryControlType type)
        {
            Text = text;
            Height = height;
            Width = width;
            Top = top;
            Left = left;
            Type = type;
        }
        public FactoryControl() { }
    }
}
