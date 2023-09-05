using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryScreenBuilder.Factory
{
    public class FactoryJSON : IFactory
    {
        public bool Build(string filename, List<Control> controls)
        {
            try
            {
                List<FactoryControl> factoryControls = new List<FactoryControl>();
                foreach(Control control in controls)
                {
                    switch (control.GetType())
                    {
                        case Type label when label == typeof(Label):
                            factoryControls.Add(new FactoryControl(control.Text, control.Height, control.Width, control.Top, control.Left, FactoryControlType.Label));
                            break;
                        case Type button when button == typeof(Button):
                            factoryControls.Add(new FactoryControl(control.Text, control.Height, control.Width, control.Top, control.Left, FactoryControlType.Button));
                            break;
                        default:
                            break;
                    }
                }

                StringBuilder sb = new StringBuilder();
                
                string json = JsonSerializer.Serialize(factoryControls);
                StreamWriter sw = new StreamWriter(filename + ".json");
                sw.Write(json);
                sw.Close();
                return true;
            }
            catch(Exception _i)
            {
                Console.WriteLine(_i.Message);
                return false;
            }
        }
        public List<Control> Read(string filename)
        {
            int width = 591;
            try
            {
                StreamReader sr = new StreamReader(filename + ".json");
                List<FactoryControl> jsonControls = JsonSerializer.Deserialize<List<FactoryControl>>(JsonDocument.Parse(sr.ReadToEnd()));
                List<Control> finalControls = new List<Control>();
                for(int i = 0; i < jsonControls.Count; i++)
                {
                    FactoryControl control = jsonControls[i];
                    Control realControl = new Control()
                    {
                        Text = control.Text,
                        Height = control.Height,
                        Width = control.Width,
                        Top = control.Top,
                        Left = control.Left
                    };
                    switch(jsonControls[i].Type)
                    {
                        case FactoryControlType.Label:
                            finalControls.Add(new CustomLabel((uint)i, width, realControl));
                            break;
                        case FactoryControlType.Button:
                            finalControls.Add(new CustomButton((uint)i, width, realControl));
                            break;
                        default:
                            break;
                    }
                }
                sr.Close();
                return finalControls;
            }
            catch(Exception _i)
            {
                Console.WriteLine(_i.Message);
                return null;
            }
        }
    }
}
