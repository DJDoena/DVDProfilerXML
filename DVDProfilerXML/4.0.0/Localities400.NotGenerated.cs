using System;
using System.IO;
using DoenaSoft.ToolBox.Generics;

// 
// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version400.Localities Localities400.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version400.Localities
{
    public partial class Localities
    {
        public static Localities Deserialize()
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DVD Profiler", "localities.xod");

            if (File.Exists(fileName))
            {
                var localities = Serializer<Localities>.Deserialize(fileName);

                return localities;
            }
            else
            {
                return null;
            }
        }
    }
}