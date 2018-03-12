using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bildverarbeitung_Wallberg
{
    public static class DefaultVariables
    {
        public static string GetProjectPath()
        {
            // Ergebnis: Debug- oder Release-Ordner im Projektordner.
            string projectPath = Environment.CurrentDirectory;
            // Mit jedem Durchlauf geht es im Verzeichnisbaum eine Stufe höher.
            for (int i = 0; i < 2; i++)
            {
                projectPath = System.IO.Path.GetDirectoryName(projectPath);
            }
            return projectPath + @"\";
        }

    }
}
