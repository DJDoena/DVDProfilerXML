using System;
using System.IO;
using System.Xml.Serialization;

//
// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version381 COOs381.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version381
{
    public partial class CountryOfOriginList
    {
        private static XmlSerializer Serializer;

        public static CountryOfOriginList Deserialize()
        {
            String fileName;

            fileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + @"\DVD Profiler\coos.xod";
            if (File.Exists(fileName))
            {
                return (Deserialize(fileName));
            }
            else
            {
                return (null);
            }
        }

        public static CountryOfOriginList Deserialize(String fileName)
        {
            if (Serializer == null)
            {
                Serializer = new XmlSerializer(typeof(CountryOfOriginList));
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                CountryOfOriginList retVal;

                retVal = (CountryOfOriginList)(Serializer.Deserialize(fs));
                return (retVal);
            }
        }
    }
}