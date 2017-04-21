using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// 
// xsd.exe /c /l:cs /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version380 DVDProfiler380.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version380
{
    public static class Countries
    {
        public static readonly Dictionary<Int32, String> Dictionary;

        static Countries()
        {
            Dictionary = new Dictionary<Int32, String>(52);
            Dictionary.Add(0, "United States");
            Dictionary.Add(1, "New Zealand");
            Dictionary.Add(2, "Australia");
            Dictionary.Add(3, "Canada");
            Dictionary.Add(4, "United Kingdom");
            Dictionary.Add(5, "Germany");
            Dictionary.Add(6, "China");
            Dictionary.Add(7, "Former Soviet Union");
            Dictionary.Add(8, "France");
            Dictionary.Add(9, "Netherlands");
            Dictionary.Add(10, "Spain");
            Dictionary.Add(11, "Sweden");
            Dictionary.Add(12, "Norway");
            Dictionary.Add(13, "Italy");
            Dictionary.Add(14, "Denmark");
            Dictionary.Add(15, "Portugal");
            Dictionary.Add(16, "Finland");
            Dictionary.Add(17, "Japan");
            Dictionary.Add(18, "South Korea");
            Dictionary.Add(19, "Canada (Quebec)");
            Dictionary.Add(20, "South Africa");
            Dictionary.Add(21, "Hong Kong");
            Dictionary.Add(22, "Switzerland");
            Dictionary.Add(23, "Brazil");
            Dictionary.Add(24, "Israel");
            Dictionary.Add(25, "Mexico");
            Dictionary.Add(26, "Iceland");
            Dictionary.Add(27, "Indonesia");
            Dictionary.Add(28, "Taiwan");
            Dictionary.Add(29, "Poland");
            Dictionary.Add(30, "Belgium");
            Dictionary.Add(31, "Turkey");
            Dictionary.Add(32, "Argentina");
            Dictionary.Add(33, "Slovakia");
            Dictionary.Add(34, "Hungary");
            Dictionary.Add(35, "Singapore");
            Dictionary.Add(36, "Czech Republic");
            Dictionary.Add(37, "Malaysia");
            Dictionary.Add(38, "Thailand");
            Dictionary.Add(39, "India");
            Dictionary.Add(40, "Austria");
            Dictionary.Add(41, "Greece");
            Dictionary.Add(42, "Vietnam");
            Dictionary.Add(43, "Philippines");
            Dictionary.Add(44, "Ireland");
            Dictionary.Add(45, "Estonia");
            Dictionary.Add(46, "Romania");
            Dictionary.Add(47, "Iran");
            Dictionary.Add(48, "Russia");
            Dictionary.Add(49, "Chile");
            Dictionary.Add(50, "Colombia");
            Dictionary.Add(51, "Peru");

        }
    }

    public partial class Collection
    {
        private static XmlSerializer s_XmlSerializer;

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(Collection));
                }
                return (s_XmlSerializer);
            }
        }

        public static void Serialize(String fileName, Collection instance)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
                {
                    xtw.Formatting = Formatting.Indented;
                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(fileName, this);
        }

        public static Collection Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    Collection instance;

                    instance = (Collection)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append("Count: ");
            if (DVDList != null)
            {
                sb.Append(DVDList.Length);
            }
            else
            {
                sb.Append("none");
            }
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class DVD
    {
        private static XmlSerializer s_XmlSerializer;

        public DVD()
        {
            ProfileTimestamp = DateTime.UtcNow;
            ID = String.Empty;
            MediaTypes = new MediaTypes();
            UPC = String.Empty;
            CollectionNumber = String.Empty;
            CollectionType = new CollectionType();
            Title = String.Empty;
            Edition = String.Empty;
            OriginalTitle = String.Empty;
            CountryOfOrigin = String.Empty;
            RatingSystem = String.Empty;
            Rating = String.Empty;
            CaseType = String.Empty;
            GenreList = new String[0];
            RegionList = new String[0];
            Format = new Format();
            Features = new Features();
            StudioList = new String[0];
            MediaCompanyList = new String[0];
            AudioList = new AudioTrack[0];
            SubtitleList = new String[0];
            SRP = new Price();
            DiscList = new Disc[0];
            SortTitle = String.Empty;
            PurchaseInfo = new PurchaseInfo();
            Review = new Review();
            MediaBanners = new MediaBanners();
            EventList = new Event[0];
            BoxSet = new BoxSet();
            LoanInfo = new LoanInfo();
        }

        [XmlIgnore()]
        public Int32 LocalityAsID
        {
            [DebuggerStepThrough()]
            get
            {
                String[] split;

                split = ID.Split('.');
                if (split.Length == 1)
                {
                    return (0);
                }
                else
                {
                    if (split[1] == String.Empty)
                    {
                        return (0);
                    }
                    else
                    {
                        return (Int32.Parse(split[1]));
                    }
                }
            }
        }

        [XmlIgnore()]
        public String LocalityAsText
        {
            get
            {
                String locality;

                if (Countries.Dictionary.TryGetValue(LocalityAsID, out locality) == false)
                {
                    locality = "<unknown>";
                }
                return (locality);
            }
        }

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(DVD));
                }
                return (s_XmlSerializer);
            }
        }

        public static void Serialize(String fileName, DVD instance)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
                {
                    xtw.Formatting = Formatting.Indented;
                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(fileName, this);
        }

        public static DVD Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    DVD instance;

                    instance = (DVD)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Title);
            if (String.IsNullOrEmpty(Edition) == false)
            {
                sb.Append(": ");
                sb.Append(Edition);
            }
            sb.Append(" (");
            sb.Append(UPC);
            sb.Append(")");
            return (sb.ToString());
        }

        public override Boolean Equals(Object obj)
        {
            DVD other;

            other = obj as DVD;
            if (other == null)
            {
                return (false);
            }
            return (ID == other.ID);
        }

        public override Int32 GetHashCode()
        {
            return (idField.GetHashCode());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class MediaTypes
    {
        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            if (DVD)
            {
                sb.Append("DVD");
            }
            if (BluRay)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }
                sb.Append("Blu-ray");
            }
            if (HDDVD)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }
                sb.Append("HD-DVD");
            }
            if (String.IsNullOrEmpty(CustomMediaType) == false)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }
                sb.Append(CustomMediaType);
            }
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class BasicDVD
    {
        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Title);
            if (String.IsNullOrEmpty(Edition) == false)
            {
                sb.Append(": ");
                sb.Append(Edition);
            }
            sb.Append(" (");
            sb.Append(UPC);
            sb.Append(")");
            return (sb.ToString());
        }

        [XmlIgnore()]
        public Int32 LocalityAsID
        {
            [DebuggerStepThrough()]
            get
            {
                String[] split;

                split = ID.Split('.');
                if (split.Length == 1)
                {
                    return (0);
                }
                else
                {
                    if (split[1] == String.Empty)
                    {
                        return (0);
                    }
                    else
                    {
                        return (Int32.Parse(split[1]));
                    }
                }
            }
        }

        [XmlIgnore()]
        public String LocalityAsText
        {
            get
            {
                String locality;

                if (Countries.Dictionary.TryGetValue(LocalityAsID, out locality) == false)
                {
                    locality = "<unknown>";
                }
                return (locality);
            }
        }
    }

    public partial class CollectionType
    {
        public CollectionType()
        {
            Value = String.Empty;
        }

        public override String ToString()
        {
            return (Value + "(Owned: " + IsPartOfOwnedCollection.ToString() + ")");
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class Locks
    {
        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Tag
    {
        public Tag()
        {
            Name = String.Empty;
            FullName = String.Empty;
        }

        public override String ToString()
        {
            return (FullName);
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class LoanInfo
    {
        public override String ToString()
        {
            if (Loaned)
            {
                StringBuilder sb;

                sb = new StringBuilder();
                if (DueSpecified)
                {
                    sb.Append("until");
                    sb.Append(Due.ToShortDateString());
                }
                if (User != null)
                {
                    if (DueSpecified)
                    {
                        sb.Append(" ");
                    }
                    sb.Append("by ");
                    sb.Append(User.ToString());
                }
                return (sb.ToString());
            }
            else
            {
                return ("not loaned");
            }
        }
    }

    public partial class BasicUser
    {
        public BasicUser()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder name;

            name = new StringBuilder();
            if (String.IsNullOrEmpty(FirstName) == false)
            {
                name.Append(FirstName);
            }
            if (String.IsNullOrEmpty(LastName) == false)
            {
                if (name.Length != 0)
                {
                    name.Append(" ");
                }
                name.Append(LastName);
            }
            return (name.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class User : BasicUser
    {
        public User()
        {
            EmailAddress = String.Empty;
            PhoneNumber = String.Empty;
        }

        public User(BasicUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = String.Empty;
            PhoneNumber = String.Empty;
        }
    }

    public partial class BoxSet
    {
        public BoxSet()
        {
            Parent = String.Empty;
            ContentList = new String[0];
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Event
    {
        public Event()
        {
            Type = EventType.Watched;
            Timestamp = DateTime.UtcNow;
            User = new User();
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Type);
            sb.Append(" at ");
            sb.Append(Timestamp.ToShortDateString());
            if (User != null)
            {
                sb.Append(" by ");
                sb.Append(User.ToString());
            }
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Exclusions
    {
        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class MediaBanners
    {
        public MediaBanners()
        {
            Front = MediaBannersRestriction.Automatic;
            Back = MediaBannersRestriction.Automatic;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Front);
            sb.Append(" / ");
            sb.Append(Back);
            return (sb.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class Review
    {
        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append("Film: ");
            sb.Append(Film);
            sb.Append(" / Video: ");
            sb.Append(Video);
            sb.Append(" / Audio: ");
            sb.Append(Audio);
            sb.Append(" / Extras: ");
            sb.Append(Extras);
            return (sb.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class PurchaseInfo
    {
        public PurchaseInfo()
        {
            Price = new Price();
            Place = String.Empty;
            Type = String.Empty;
            Website = String.Empty;
        }

        public override String ToString()
        {
            if (Price != null)
            {
                StringBuilder sb;

                sb = new StringBuilder();
                sb.Append(Price);
                if (DateSpecified)
                {
                    sb.Append(" at ");
                    sb.Append(Date.ToShortDateString());
                }
                return (sb.ToString());
            }
            return (base.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Price
    {
        public Price()
        {
            DenominationType = String.Empty;
            DenominationDesc = String.Empty;
            FormattedValue = String.Empty;
        }

        public override String ToString()
        {
            return (FormattedValue);
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class Disc
    {
        public Disc()
        {
            DescriptionSideA = String.Empty;
            DescriptionSideB = String.Empty;
            DiscIDSideA = String.Empty;
            DiscIDSideB = String.Empty;
            LabelSideA = String.Empty;
            LabelSideB = String.Empty;
            Location = String.Empty;
            Slot = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(DescriptionSideA);
            if (String.IsNullOrEmpty(DescriptionSideB) == false)
            {
                sb.Append(" / ");
                sb.Append(DescriptionSideB);
            }
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class CrewMember : IPerson
    {
        public CrewMember()
        {
            FirstName = String.Empty;
            MiddleName = String.Empty;
            LastName = String.Empty;
            CreditType = String.Empty;
            CreditSubtype = String.Empty;
            CustomRole = String.Empty;
            CreditedAs = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            if (String.IsNullOrEmpty(FirstName) == false)
            {
                sb.Append(FirstName);
            }
            if (String.IsNullOrEmpty(MiddleName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(MiddleName);
            }
            if (String.IsNullOrEmpty(LastName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(LastName);
            }
            if (BirthYear > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append("(" + BirthYear + ")");
            }
            sb.Append(": ");
            sb.Append(CreditType);
            sb.Append(" / ");
            sb.Append(CreditSubtype);
            if (String.IsNullOrEmpty(CustomRole) == false)
            {
                sb.Append(" (");
                sb.Append(CustomRole);
                sb.Append(")");
            }
            if (String.IsNullOrEmpty(CreditedAs) == false)
            {
                sb.Append(" (as ");
                sb.Append(CreditedAs);
                sb.Append(")");
            }
            return (sb.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class CastMember : IPerson
    {
        public CastMember()
        {
            FirstName = String.Empty;
            MiddleName = String.Empty;
            LastName = String.Empty;
            Role = String.Empty;
            CreditedAs = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            if (String.IsNullOrEmpty(FirstName) == false)
            {
                sb.Append(FirstName);
            }
            if (String.IsNullOrEmpty(MiddleName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(MiddleName);
            }
            if (String.IsNullOrEmpty(LastName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(LastName);
            }
            if (BirthYear > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append("(" + BirthYear + ")");
            }
            sb.Append(": ");
            sb.Append(Role);
            if (Voice)
            {
                sb.Append(" (voice)");
            }
            if (Uncredited)
            {
                sb.Append(" (uncredited)");
            }
            if (String.IsNullOrEmpty(CreditedAs) == false)
            {
                sb.Append(" (as ");
                sb.Append(CreditedAs);
                sb.Append(")");
            }
            return (sb.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class Divider
    {
        public Divider()
        {
            Caption = String.Empty;
            Type = DividerType.Episode;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Caption);
            sb.Append(" (");
            sb.Append(Type);
            sb.Append(")");
            return (sb.ToString());
        }

        [XmlAnyAttribute()]
        public XmlNode[] OpenAttributes;
    }

    public partial class CrewDivider : Divider
    {
        public CrewDivider()
        {
            CreditType = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Caption);
            sb.Append(" (");
            sb.Append(Type);
            if (Type != DividerType.Episode)
            {
                sb.Append(", ");
                sb.Append(CreditType);
            }
            sb.Append(")");
            return (sb.ToString());
        }

        public Boolean ShouldSerializeCreditType()
        {
            return (Type != DividerType.Episode);
        }
    }

    public partial class AudioTrack
    {
        public AudioTrack()
        {
            Content = String.Empty;
            Format = String.Empty;
            Channels = String.Empty;
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Content);
            sb.Append(" / ");
            sb.Append(Format);
            sb.Append(" / ");
            sb.Append(Channels);
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Features
    {
        public Features()
        {
            OtherFeatures = String.Empty;
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Dimensions
    {
        public override String ToString()
        {
            return ("2D: " + Dim2D.ToString() + ", 3D Anaglyph: " + Dim3DAnaglyph.ToString()
                + ", 3D Blu-ray: " + Dim3DBluRay.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class Format
    {
        public Format()
        {
            AspectRatio = String.Empty;
            Color = Color.Empty;
            Dimensions = new Dimensions();
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(VideoStandard);
            sb.Append(" ");
            sb.Append(AspectRatio);
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class BasicCollection
    {
        private static XmlSerializer s_XmlSerializer;

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            [DebuggerStepThrough()]
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(BasicCollection));
                }
                return (s_XmlSerializer);
            }
        }

        public static void Serialize(String fileName, BasicCollection instance)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
                {
                    xtw.Formatting = Formatting.Indented;
                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(fileName, this);
        }

        public static BasicCollection Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    BasicCollection instance;

                    instance = (BasicCollection)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append("Count: ");
            if (DVDList != null)
            {
                sb.Append(DVDList.Length);
            }
            else
            {
                sb.Append("none");
            }
            return (sb.ToString());
        }
    }

    public partial class CastInformation
    {
        private static XmlSerializer s_XmlSerializer;

        public CastInformation()
        {
            Title = String.Empty;
            CastList = new Object[0];
        }

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            [DebuggerStepThrough()]
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(CastInformation));
                }
                return (s_XmlSerializer);
            }
        }

        public static void Serialize(String fileName, CastInformation instance)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
                {
                    xtw.Formatting = Formatting.Indented;
                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(fileName, this);
        }

        public static CastInformation Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    CastInformation instance;

                    instance = (CastInformation)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Title);
            sb.Append("(Count: ");
            if (CastList != null)
            {
                sb.Append(CastList.Length);
            }
            else
            {
                sb.Append("none");
            }
            sb.Append(")");
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class CrewInformation
    {
        private static XmlSerializer s_XmlSerializer;

        public CrewInformation()
        {
            Title = String.Empty;
            CrewList = new Object[0];
        }

        [XmlIgnore()]
        public static XmlSerializer XmlSerializer
        {
            [DebuggerStepThrough()]
            get
            {
                if (s_XmlSerializer == null)
                {
                    s_XmlSerializer = new XmlSerializer(typeof(CrewInformation));
                }
                return (s_XmlSerializer);
            }
        }

        public static void Serialize(String fileName, CrewInformation instance)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
                {
                    xtw.Formatting = Formatting.Indented;
                    XmlSerializer.Serialize(xtw, instance);
                }
            }
        }

        public void Serialize(String fileName)
        {
            Serialize(fileName, this);
        }

        public static CrewInformation Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (XmlTextReader xtr = new XmlTextReader(fs))
                {
                    CrewInformation instance;

                    instance = (CrewInformation)(XmlSerializer.Deserialize(xtr));
                    return (instance);
                }
            }
        }

        public override String ToString()
        {
            StringBuilder sb;

            sb = new StringBuilder();
            sb.Append(Title);
            sb.Append("(Count: ");
            if (CrewList != null)
            {
                sb.Append(CrewList.Length);
            }
            else
            {
                sb.Append("none");
            }
            sb.Append(")");
            return (sb.ToString());
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }
}