using System;
using System.IO;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;

// 
// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version400 Localities400.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version400
{
    partial class Localities
    {
        public static Localities Deserialize()
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DVD Profiler", "localities.xod");

            if (File.Exists(fileName))
            {
                var localities = DVDProfilerSerializer<Localities>.Deserialize(fileName);

                return localities;
            }
            else
            {
                return null;
            }
        }
    }
}