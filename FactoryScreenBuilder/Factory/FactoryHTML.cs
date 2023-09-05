using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FactoryScreenBuilder.Factory
{
    public class FactoryHTML : IFactory
    {
        public bool Build(string filename, List<Control> controls)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<!DOCTYPE html><html style='height: 100vh; width: 100vw; margin: 0px;'><head></head><body style='position:relative; height: 100%; width: 100%; margin: 0px;'>");
                foreach(Control control in controls)
                {
                    switch(control.GetType())
                    {
                        case Type label when label == typeof(Label):
                            sb.Append("<label for='' ");
                            sb.Append(StyleTag(control));
                            sb.Append(">");
                            sb.Append(control.Text);
                            sb.Append("</label>");
                            break;
                        case Type button when button == typeof(Button):
                            sb.Append("<input type='button' ");
                            sb.Append(StyleTag(control));
                            sb.Append(" value='");
                            sb.Append(control.Text);
                            sb.Append("'/>");
                            break;
                        default:
                            break;
                    }
                }
                sb.Append("</body></html>");
                //Console.WriteLine(sb.ToString());
                StreamWriter sw = new StreamWriter(filename + ".html");
                sw.Write(sb.ToString());
                sw.Close();
            }
            catch(Exception _i)
            {
                Console.WriteLine(_i.Message);
                return false;
            }
            return true;
        }
        public List<Control> Read(string filename)
        {
            int width = 591;
            try
            {
                StreamReader sr = new StreamReader(filename + ".html");
                XmlDocument html = new XmlDocument();
                html.LoadXml(sr.ReadToEnd());
                XmlNodeList elements = html.SelectSingleNode("//body").ChildNodes;

                List<Control> finalControls = new List<Control>();
                for(int i = 0; i < elements.Count; i++)
                {
                    XmlNode element = elements[i];
                    string[] style = element.Attributes[1].Value.Split(';');
                    Control control = new Control()
                    {
                        Height = int.Parse(TrimStyle(style[1])),
                        Width = int.Parse(TrimStyle(style[2])),
                        Top = int.Parse(TrimStyle(style[3])),
                        Left = int.Parse(TrimStyle(style[4]))
                    };
                    if(element.Name.Equals("label"))
                    {
                        control.Text = element.InnerText;
                        finalControls.Add(new CustomLabel((uint)i, width, control));
                    }
                    // Button first attribute is type, third is text
                    else if(element.Name.Equals("input") && element.Attributes[0].Value.Equals("button"))
                    {
                        control.Text = element.Attributes[2].Value;
                        finalControls.Add(new CustomButton((uint)i, width, control));
                    }
                }
                sr.Close();
                return finalControls;
            }
            catch (Exception _i)
            {
                Console.WriteLine(_i.StackTrace);
                return null;
            }
        }
        private string StyleTag(Control control)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("style='position:absolute; height: ");
            sb.Append(control.Height);
            sb.Append("px; width: ");
            sb.Append(control.Width);
            sb.Append("px; top: ");
            sb.Append(control.Top);
            sb.Append("px; left: ");
            sb.Append(control.Left);
            sb.Append("px;'");
            return sb.ToString();
        }
        private string TrimStyle(string style)
        {
            style = style.Split(':')[1];
            style = style.Replace("px", "");
            return style.Trim();
        }
    }
}
