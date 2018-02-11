using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;

// 
// xsd.exe /c /l:cs /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version390 DVDProfiler390.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version390
{
    public partial class Collection
    {
        [XmlIgnore]
        public static readonly Encoding DefaultEncoding;

        static Collection()
        {
            DefaultEncoding = Encoding.GetEncoding(1252);
        }

        public void Serialize(String fileName
            , Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            DVDProfilerSerializer<Collection>.Serialize(fileName, this, encoding);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class DVD : IComparable<DVD>
    {
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
            MyLinks = new MyLinks();
            PluginCustomData = new PluginData[0];
        }

        [XmlIgnore]
        public static Encoding DefaultEncoding
            => (Collection.DefaultEncoding);

        [XmlIgnore]
        public String[] CountryOfOriginList
            => (CountryOfOriginEnumerable.ToArray());

        private IEnumerable<String> CountryOfOriginEnumerable
        {
            get
            {
                yield return (CountryOfOrigin);
                yield return (CountryOfOrigin2);
                yield return (CountryOfOrigin3);
            }
        }

        public void Serialize(String fileName
            , Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            DVDProfilerSerializer<DVD>.Serialize(fileName, this, encoding);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Title);

            if (String.IsNullOrEmpty(Edition) == false)
            {
                sb.Append(": ");
                sb.Append(Edition);
            }

            sb.Append(" (");
            sb.Append(UPC);

            if (ID_VariantNum > 0)
            {
                sb.Append(" #");
                sb.Append(ID_VariantNum);
            }

            sb.Append(")");

            return (sb.ToString());
        }

        public override Boolean Equals(Object obj)
        {
            DVD other = obj as DVD;

            if (other == null)
            {
                return (false);
            }

            return (ID == other.ID);
        }

        public override Int32 GetHashCode()
            => (idField.GetHashCode());

        [XmlAnyElement]
        public XmlNode[] OpenElements;

        #region IComparable<DVD>

        public Int32 CompareTo(DVD other)
            => ((other == null) ? 1 : Utilities.CompareSortTitle(this, other));

        #endregion
    }

    public partial class MediaTypes
    {
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class CollectionType
    {
        public CollectionType()
        {
            Value = String.Empty;
        }

        public override String ToString()
            => (Value + "(Owned: " + IsPartOfOwnedCollection.ToString() + ")");

        public override Int32 GetHashCode()
            => (Value.GetHashCode());

        public override Boolean Equals(Object obj)
        {
            CollectionType other = obj as CollectionType;

            if (other == null)
            {
                return (false);
            }

            return ((Value == other.Value) && (IsPartOfOwnedCollection == other.IsPartOfOwnedCollection));
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class Locks
    {
        [XmlAnyElement]
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
            => (FullName);

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class LoanInfo
    {
        public override String ToString()
        {
            if (Loaned)
            {
                StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
        public XmlNode[] OpenElements;
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
            StringBuilder name = new StringBuilder();

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

        [XmlAnyAttribute]
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

        [XmlAnyElement]
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
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Exclusions
    {
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (DPOPrivate)
            {
                sb.Append("DPO Private");
            }

            if (DPOPublic)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append("DPO Public");
            }

            if (iPhone)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append("iPhone");
            }

            if (Mobile)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append("Mobile");
            }

            if (RemoteConnections)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append("Remote Connections");
            }

            if (MoviePick)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append("Movie Pick");
            }

            return (sb.ToString());
        }

        [XmlAnyElement]
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
            StringBuilder sb = new StringBuilder();

            sb.Append(Front);
            sb.Append(" / ");
            sb.Append(Back);

            return (sb.ToString());
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class Review
    {
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyAttribute]
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
                StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
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
            => (FormattedValue);

        [XmlAnyAttribute]
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
            StringBuilder sb = new StringBuilder();

            sb.Append(DescriptionSideA);

            if (String.IsNullOrEmpty(DescriptionSideB) == false)
            {
                sb.Append(" / ");
                sb.Append(DescriptionSideB);
            }

            return (sb.ToString());
        }

        [XmlAnyElement]
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
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyAttribute]
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
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyAttribute]
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
            StringBuilder sb = new StringBuilder();

            sb.Append(Caption);
            sb.Append(" (");
            sb.Append(Type);
            sb.Append(")");

            return (sb.ToString());
        }

        [XmlAnyAttribute]
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
            StringBuilder sb = new StringBuilder();

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
            => (Type != DividerType.Episode);
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
            StringBuilder sb = new StringBuilder();

            sb.Append(Content);
            sb.Append(" / ");
            sb.Append(Format);
            sb.Append(" / ");
            sb.Append(Channels);

            return (sb.ToString());
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Features
    {
        public Features()
        {
            OtherFeatures = String.Empty;
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Dimensions
    {
        public override String ToString()
            => ($"2D: {Dim2D}, 3D Anaglyph: {Dim3DAnaglyph}, 3D Blu-ray: {Dim3DBluRay}");

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Format
    {
        public Format()
        {
            AspectRatio = String.Empty;
            Color = new FormatColor();
            Dimensions = new Dimensions();
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(VideoStandard);
            sb.Append(" ");
            sb.Append(AspectRatio);

            return (sb.ToString());
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class FormatColor
    {
        public override String ToString()
            => ($"Color: {Color}, B/W: {BlackAndWhite}, Colorized: {Colorized}, Mixed: {Mixed}");

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class CastInformation
    {
        [XmlIgnore]
        public static readonly Encoding DefaultEncoding;

        static CastInformation()
        {
            DefaultEncoding = Encoding.GetEncoding("iso-8859-1");
        }

        public CastInformation()
        {
            Title = String.Empty;
            CastList = new Object[0];
        }

        public void Serialize(String fileName
            , Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            DVDProfilerSerializer<CastInformation>.Serialize(fileName, this, encoding);
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
        [XmlIgnore]
        public static Encoding DefaultEncoding
            => (CastInformation.DefaultEncoding);

        public CrewInformation()
        {
            Title = String.Empty;
            CrewList = new Object[0];
        }

        public void Serialize(String fileName
            , Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            DVDProfilerSerializer<CrewInformation>.Serialize(fileName, this, encoding);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

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

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }
}