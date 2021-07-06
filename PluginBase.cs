using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRed
{
    public class PluginBase
    {
        class PluginDetails
        {
            public string pluginFileFullname;
            public string pluginFileName;
            public string pluginFunctionName;
            public string pluginName;
            public string pluginDescription;
            public string pluginAbout;
            public string pluginType;

            public PluginDetails()
            {
                pluginFileName = "";
                pluginFunctionName = "";
                pluginName = "";
                pluginDescription = "";
                pluginAbout = "";
                pluginType = "";
            }
        }

        private List<PluginDetails> fPluginList;
        public ToolStripMenuItem menuItem;
        public Subtitle subtitles;
        public DataGridView grid;
        public Sub_formats.SubFormats subFormats;

        public PluginBase()
        {
            fPluginList = new List<PluginDetails>();
            menuItem = new ToolStripMenuItem();
            subtitles = new Subtitle();
            subFormats = new Sub_formats.SubFormats();
        }

        public void LoadPluginFunction(string path, string filename, bool isAddInMenuItem)
        {
            int fFunctionsCount = 0;
            string[] functionList = null;

            Assembly a = Assembly.LoadFile(path);
            Type[] types = a.GetTypes();
            Type t = a.GetType("Program");
            Object o = a.CreateInstance("Program");

            MethodInfo pluginFunc = t.GetMethod("PluginFunctions");
            var result = pluginFunc.Invoke(o, null);
            functionList = result.ToString().Split(' ');

            fFunctionsCount = functionList.Count();
            for (int i = 0; i < fFunctionsCount; i++)
            {
                PluginDetails pFItem = new PluginDetails
                {
                    pluginFileFullname = path,
                    pluginFileName = filename,
                    pluginFunctionName = functionList[i]
                };

                pluginFunc = t.GetMethod("PluginName");
                result = pluginFunc.Invoke(o, new object[] { pFItem.pluginFunctionName });
                pFItem.pluginName = result.ToString();

                pluginFunc = t.GetMethod("PluginAbout");
                result = pluginFunc.Invoke(o, new object[] { pFItem.pluginFunctionName });
                pFItem.pluginAbout = result.ToString();

                pluginFunc = t.GetMethod("PluginDescriptions");
                result = pluginFunc.Invoke(o, new object[] { pFItem.pluginFunctionName });
                pFItem.pluginDescription = result.ToString();

                pluginFunc = t.GetMethod("PluginType");
                result = pluginFunc.Invoke(o, new object[] { pFItem.pluginFunctionName });
                pFItem.pluginType = result.ToString();

                fPluginList.Add(pFItem);

                if (isAddInMenuItem)
                {
                    fPluginList.Add(pFItem);
                    ToolStripMenuItem item = new ToolStripMenuItem
                    {
                        Name = pFItem.pluginFunctionName,
                        Text = pFItem.pluginName
                    };
                    item.Click += TMenu;

                    menuItem.DropDownItems.Add(item);
                }
            }
        }

        public void TMenu(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            string fn = t.Name;
            TMenuClick(fn);
        }

        public void TMenuClick(string fPluginName)
        {
            PluginDetails plDetails = fPluginList.Find(x => x.pluginFunctionName.Contains(fPluginName));

            Assembly a = Assembly.LoadFile(plDetails.pluginFileFullname);
            Type[] types = a.GetTypes();
            Type t = a.GetType("Program");
            Object o = a.CreateInstance("Program");

            if (plDetails.pluginFunctionName.Contains("Index"))
            {
                MethodInfo pluginFunc = t.GetMethod(plDetails.pluginFunctionName);
                var result = pluginFunc.Invoke(o, new object[] { subtitles.getSubtitlesString(), grid.CurrentCell.RowIndex });
                CheckSub(result.ToString());
            }
            else
            {
                MethodInfo pluginFunc = t.GetMethod(plDetails.pluginFunctionName);
                var result = pluginFunc.Invoke(o, new object[] { subtitles.getSubtitlesString() });
                CheckSub(result.ToString());
            }
        }

        public void CheckSub(string sub)
        {
            string[] subSplit = sub.Split(new string[] { "&&" }, StringSplitOptions.None);
            if (subSplit[0].Contains("ErrorMessage:") || subSplit[0].Contains("SuccessMessage:"))
            {
                try
                {
                    subSplit = subSplit[0].Split(':');
                    int num = Convert.ToInt32(subSplit[1].Split(')')[0].Split('(')[1]);

                    grid.Rows[num - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                catch { }
                if (!String.IsNullOrEmpty(subSplit[1]))
                {
                    MessageBox.Show(subSplit[1], "Вывод");
                }

            }
            else
                subtitles.setSubtitleString(sub);
        }
    }
}
