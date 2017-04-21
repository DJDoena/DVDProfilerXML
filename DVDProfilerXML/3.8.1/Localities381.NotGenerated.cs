using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

//
// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version381 Localities381.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version381
{
    public partial class Localities
    {
        private static XmlSerializer s_XmlSerializer;

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(Localities));
                }
                return (s_XmlSerializer);
            }
        }

        public static Localities Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    Localities instance;

                    instance = (Localities)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public static Localities Deserialize()
        {
            String fileName;

            fileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + @"\DVD Profiler\localities.xod";
            if (File.Exists(fileName))
            {
                return (Deserialize(fileName));
            }
            else
            {
                return (null);
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append("Count: ");
            if (LocalityList != null)
            {
                sb.Append(LocalityList.Length);
            }
            else
            {
                sb.Append("none");
            }
            return (sb.ToString());
        }
    }
}