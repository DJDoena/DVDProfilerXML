using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DoenaSoft.ToolBox.Generics;

// 
// xsd.exe /c /l:cs /f /n:DoenaSoft.DVDProfiler.DVDProfilerXML.Version400 DVDProfiler400.xsd
//

namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version400
{
    public partial class Collection
    {
        [XmlIgnore]
        public static readonly Encoding DefaultEncoding;

        static Collection()
        {
            DefaultEncoding = Encoding.GetEncoding(1252);
        }

        public void Serialize(string fileName, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            Serializer<Collection>.Serialize(fileName, this, encoding);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Count: ");

            if (DVDList != null)
            {
                sb.Append(DVDList.Length);
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class DVD : IComparable<DVD>, IEquatable<DVD>
    {
        public DVD()
        {
            ProfileTimestamp = DateTime.UtcNow;
            ID = string.Empty;
            MediaTypes = new MediaTypes();
            UPC = string.Empty;
            CollectionNumber = string.Empty;
            CollectionType = new CollectionType();
            Title = string.Empty;
            Edition = string.Empty;
            OriginalTitle = string.Empty;
            CountryOfOrigin = string.Empty;
            RatingSystem = string.Empty;
            Rating = string.Empty;
            CaseType = string.Empty;
            GenreList = new string[0];
            RegionList = new string[0];
            Format = new Format();
            Features = new Features();
            StudioList = new string[0];
            MediaCompanyList = new string[0];
            AudioList = new AudioTrack[0];
            SubtitleList = new string[0];
            SRP = new Price();
            DiscList = new Disc[0];
            SortTitle = string.Empty;
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
        public static Encoding DefaultEncoding => Collection.DefaultEncoding;

        [XmlIgnore]
        public string[] CountryOfOriginList => (this.CountryOfOriginEnumerable.ToArray());

        private IEnumerable<string> CountryOfOriginEnumerable
        {
            get
            {
                yield return CountryOfOrigin;
                yield return CountryOfOrigin2;
                yield return CountryOfOrigin3;
            }
        }

        public void Serialize(string fileName, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            Serializer<DVD>.Serialize(fileName, this, encoding);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Title);

            if (string.IsNullOrEmpty(Edition) == false)
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

            return sb.ToString();
        }

        public override bool Equals(object obj) => this.Equals(obj as DVD);

        public override int GetHashCode() => ID.GetHashCode();

        [XmlAnyElement]
        public XmlNode[] OpenElements;

        #region IComparable<DVD>

        public int CompareTo(DVD other) => ((other == null) ? 1 : Utilities.CompareSortTitle(this, other));

        #endregion

        #region IEquatable<DVD>

        public bool Equals(DVD other) => (other != null) ? (ID == other.ID) : false;

        #endregion
    }

    public partial class MediaTypes
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

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

            if (string.IsNullOrEmpty(CustomMediaType) == false)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" / ");
                }

                sb.Append(CustomMediaType);
            }

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class CollectionType : IEquatable<CollectionType>
    {
        public CollectionType()
        {
            Value = string.Empty;
        }

        public override string ToString() => Value + "(Owned: " + IsPartOfOwnedCollection.ToString() + ")";

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj) => this.Equals(obj as CollectionType);

        public bool Equals(CollectionType other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = Value == other.Value
                && IsPartOfOwnedCollection == other.IsPartOfOwnedCollection;

            return equals;
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
            Name = string.Empty;
            FullName = string.Empty;
        }

        public override string ToString() => FullName;

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class LoanInfo
    {
        public override string ToString()
        {
            if (Loaned)
            {
                var sb = new StringBuilder();

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

                return sb.ToString();
            }
            else
            {
                return "not loaned";
            }
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class User
    {
        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            EmailAddress = string.Empty;
            PhoneNumber = string.Empty;
        }

        public User(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
            PhoneNumber = user.PhoneNumber;
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class BoxSet
    {
        public BoxSet()
        {
            Parent = string.Empty;
            ContentList = new string[0];
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Type);
            sb.Append(" at ");
            sb.Append(Timestamp.ToShortDateString());

            if (User != null)
            {
                sb.Append(" by ");
                sb.Append(User.ToString());
            }

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Exclusions
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

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

            return sb.ToString();
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Front);
            sb.Append(" / ");
            sb.Append(Back);

            return sb.ToString();
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class Review
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Film: ");
            sb.Append(Film);
            sb.Append(" / Video: ");
            sb.Append(Video);
            sb.Append(" / Audio: ");
            sb.Append(Audio);
            sb.Append(" / Extras: ");
            sb.Append(Extras);

            return sb.ToString();
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class PurchaseInfo
    {
        public PurchaseInfo()
        {
            Price = new Price();
            Place = string.Empty;
            Type = string.Empty;
            Website = string.Empty;
        }

        public override string ToString()
        {
            if (Price != null)
            {
                var sb = new StringBuilder();

                sb.Append(Price);

                if (DateSpecified)
                {
                    sb.Append(" at ");
                    sb.Append(Date.ToShortDateString());
                }

                return sb.ToString();
            }

            return base.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Price
    {
        public Price()
        {
            DenominationType = string.Empty;
            DenominationDesc = string.Empty;
            FormattedValue = string.Empty;
        }

        public override string ToString() => FormattedValue;

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class Disc
    {
        public Disc()
        {
            DescriptionSideA = string.Empty;
            DescriptionSideB = string.Empty;
            DiscIDSideA = string.Empty;
            DiscIDSideB = string.Empty;
            LabelSideA = string.Empty;
            LabelSideB = string.Empty;
            Location = string.Empty;
            Slot = string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(DescriptionSideA);

            if (string.IsNullOrEmpty(DescriptionSideB) == false)
            {
                sb.Append(" / ");
                sb.Append(DescriptionSideB);
            }

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class CrewMember : IPerson
    {
        public CrewMember()
        {
            this.FirstName = string.Empty;
            this.MiddleName = string.Empty;
            this.LastName = string.Empty;
            CreditType = string.Empty;
            CreditSubtype = string.Empty;
            CustomRole = string.Empty;
            this.CreditedAs = string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(this.FirstName) == false)
            {
                sb.Append(this.FirstName);
            }

            if (string.IsNullOrEmpty(this.MiddleName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.MiddleName);
            }

            if (string.IsNullOrEmpty(this.LastName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.LastName);
            }

            if (this.BirthYear > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(" + this.BirthYear + ")");
            }

            sb.Append(": ");
            sb.Append(CreditType);
            sb.Append(" / ");
            sb.Append(CreditSubtype);

            if (string.IsNullOrEmpty(CustomRole) == false)
            {
                sb.Append(" (");
                sb.Append(CustomRole);
                sb.Append(")");
            }

            if (string.IsNullOrEmpty(this.CreditedAs) == false)
            {
                sb.Append(" (as ");
                sb.Append(this.CreditedAs);
                sb.Append(")");
            }

            return sb.ToString();
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class CastMember : IPerson
    {
        public CastMember()
        {
            this.FirstName = string.Empty;
            this.MiddleName = string.Empty;
            this.LastName = string.Empty;
            Role = string.Empty;
            this.CreditedAs = string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(this.FirstName) == false)
            {
                sb.Append(this.FirstName);
            }

            if (string.IsNullOrEmpty(this.MiddleName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.MiddleName);
            }

            if (string.IsNullOrEmpty(this.LastName) == false)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append(this.LastName);
            }

            if (this.BirthYear > 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }

                sb.Append("(" + this.BirthYear + ")");
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

            if (string.IsNullOrEmpty(this.CreditedAs) == false)
            {
                sb.Append(" (as ");
                sb.Append(this.CreditedAs);
                sb.Append(")");
            }

            return sb.ToString();
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class Divider
    {
        public Divider()
        {
            Caption = string.Empty;
            Type = DividerType.Episode;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Caption);
            sb.Append(" (");
            sb.Append(Type);
            sb.Append(")");

            return sb.ToString();
        }

        [XmlAnyAttribute]
        public XmlNode[] OpenAttributes;
    }

    public partial class CrewDivider : Divider
    {
        public CrewDivider()
        {
            CreditType = string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Caption);
            sb.Append(" (");
            sb.Append(Type);

            if (Type != DividerType.Episode)
            {
                sb.Append(", ");
                sb.Append(CreditType);
            }

            sb.Append(")");

            return sb.ToString();
        }

        public bool ShouldSerializeCreditType() => Type != DividerType.Episode;
    }

    public partial class AudioTrack
    {
        public AudioTrack()
        {
            Content = string.Empty;
            Format = string.Empty;
            Channels = string.Empty;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Content);
            sb.Append(" / ");
            sb.Append(Format);
            sb.Append(" / ");
            sb.Append(Channels);

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Features
    {
        public Features()
        {
            OtherFeatures = string.Empty;
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Dimensions
    {
        public override string ToString() => $"2D: {Dim2D}, 3D Anaglyph: {Dim3DAnaglyph}, 3D Blu-ray: {Dim3DBluRay}";

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class Format
    {
        public Format()
        {
            AspectRatio = string.Empty;
            Color = new ColorFormat();
            Dimensions = new Dimensions();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(VideoStandard);
            sb.Append(" ");
            sb.Append(AspectRatio);

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }

    public partial class ColorFormat
    {
        public override string ToString() => $"Color: {Color}, B/W: {BlackAndWhite}, Colorized: {Colorized}, Mixed: {Mixed}";

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
            Title = string.Empty;
            CastList = new object[0];
        }

        public void Serialize(string fileName
            , Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            Serializer<CastInformation>.Serialize(fileName, this, encoding);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

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

            return sb.ToString();
        }

        [XmlAnyElement()]
        public XmlNode[] OpenElements;
    }

    public partial class CrewInformation
    {
        [XmlIgnore]
        public static Encoding DefaultEncoding => CastInformation.DefaultEncoding;

        public CrewInformation()
        {
            Title = string.Empty;
            CrewList = new object[0];
        }

        public void Serialize(string fileName, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding;

            Serializer<CrewInformation>.Serialize(fileName, this, encoding);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

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

            return sb.ToString();
        }

        [XmlAnyElement]
        public XmlNode[] OpenElements;
    }
}