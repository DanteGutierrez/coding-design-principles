﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDecorator
{
    public class ShiftDecorator : File, IFileComponent
    {
        //private static readonly List<char> CHARLIST_UPPER = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        //private static readonly List<char> CHARLIST_LOWER = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private int shift = 0;
        public ShiftDecorator(IFileComponent component, int shift) : base(component) {
            this.shift = shift;
        }
        public string GetFile()
        {
            if (Component == null) return "";
            string temp_file = Component.GetFile();
            StringBuilder sb = new();
            foreach (char letter in temp_file)
            {
                sb.Append((char)((letter + char.MaxValue + shift) % char.MaxValue));
            }
            return sb.ToString();
        }
    }
}
