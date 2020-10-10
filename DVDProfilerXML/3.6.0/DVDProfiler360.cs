//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Text;
//using System.Xml;
//using System.Xml.Serialization;

//namespace DoenaSoft.DVDProfiler.DVDProfilerXML.Version360
//{
//    public static class Countries
//    {
//        public static readonly Dictionary<Int32, String> Dictionary;

//        static Countries()
//        {
//            Dictionary = new Dictionary<Int32, String>(52);
//            Dictionary.Add(0, "United States");
//            Dictionary.Add(1, "New Zealand");
//            Dictionary.Add(2, "Australia");
//            Dictionary.Add(3, "Canada");
//            Dictionary.Add(4, "United Kingdom");
//            Dictionary.Add(5, "Germany");
//            Dictionary.Add(6, "China");
//            Dictionary.Add(7, "Former Soviet Union");
//            Dictionary.Add(8, "France");
//            Dictionary.Add(9, "Netherlands");
//            Dictionary.Add(10, "Spain");
//            Dictionary.Add(11, "Sweden");
//            Dictionary.Add(12, "Norway");
//            Dictionary.Add(13, "Italy");
//            Dictionary.Add(14, "Denmark");
//            Dictionary.Add(15, "Portugal");
//            Dictionary.Add(16, "Finland");
//            Dictionary.Add(17, "Japan");
//            Dictionary.Add(18, "South Korea");
//            Dictionary.Add(19, "Canada (Quebec)");
//            Dictionary.Add(20, "South Africa");
//            Dictionary.Add(21, "Hong Kong");
//            Dictionary.Add(22, "Switzerland");
//            Dictionary.Add(23, "Brazil");
//            Dictionary.Add(24, "Israel");
//            Dictionary.Add(25, "Mexico");
//            Dictionary.Add(26, "Iceland");
//            Dictionary.Add(27, "Indonesia");
//            Dictionary.Add(28, "Taiwan");
//            Dictionary.Add(29, "Poland");
//            Dictionary.Add(30, "Belgium");
//            Dictionary.Add(31, "Turkey");
//            Dictionary.Add(32, "Argentina");
//            Dictionary.Add(33, "Slovakia");
//            Dictionary.Add(34, "Hungary");
//            Dictionary.Add(35, "Singapore");
//            Dictionary.Add(36, "Czech Republic");
//            Dictionary.Add(37, "Malaysia");
//            Dictionary.Add(38, "Thailand");
//            Dictionary.Add(39, "India");
//            Dictionary.Add(40, "Austria");
//            Dictionary.Add(41, "Greece");
//            Dictionary.Add(42, "Vietnam");
//            Dictionary.Add(43, "Philippines");
//            Dictionary.Add(44, "Ireland");
//            Dictionary.Add(45, "Estonia");
//            Dictionary.Add(46, "Romania");
//            Dictionary.Add(47, "Iran");
//            Dictionary.Add(48, "Russia");
//            Dictionary.Add(49, "Chile");
//            Dictionary.Add(50, "Colombia");
//            Dictionary.Add(51, "Peru");

//        }
//    }

//    [Serializable()]
//    [XmlRoot(Namespace = "", IsNullable = false)]
//    public class Collection
//    {
//        private static XmlSerializer s_XmlSerializer;

//        [XmlIgnore()]
//        public static XmlSerializer XmlSerializer
//        {
//            get
//            {
//                if (s_XmlSerializer == null)
//                {
//                    s_XmlSerializer = new XmlSerializer(typeof(Collection));
//                }
//                return (s_XmlSerializer);
//            }
//        }

//        public static void Serialize(String fileName, Collection instance)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
//                {
//                    xtw.Formatting = Formatting.Indented;
//                    XmlSerializer.Serialize(xtw, instance);
//                }
//            }
//        }

//        public void Serialize(String fileName)
//        {
//            Serialize(fileName, this);
//        }

//        public static Collection Deserialize(String fileName)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (XmlTextReader xtr = new XmlTextReader(fs))
//                {
//                    Collection instance;

//                    instance = (Collection)(XmlSerializer.Deserialize(xtr));
//                    return (instance);
//                }
//            }
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append("Count: ");
//            if (DVDList != null)
//            {
//                sb.Append(DVDList.Length);
//            }
//            else
//            {
//                sb.Append("none");
//            }
//            return (sb.ToString());
//        }

//        private DVD[] dVDField;

//        [XmlElement("DVD")]
//        public DVD[] DVDList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dVDField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dVDField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    [XmlRoot(Namespace = "", IsNullable = false)]
//    public class DVD
//    {
//        private static XmlSerializer s_XmlSerializer;

//        public DVD()
//        {
//            ProfileTimestamp = DateTime.UtcNow;
//            ID = String.Empty;
//            MediaTypes = new MediaTypes();
//            UPC = String.Empty;
//            CollectionNumber = String.Empty;
//            CollectionType = String.Empty;
//            Title = String.Empty;
//            Edition = String.Empty;
//            OriginalTitle = String.Empty;
//            CountryOfOrigin = String.Empty;
//            RatingSystem = String.Empty;
//            Rating = String.Empty;
//            CaseType = String.Empty;
//            GenreList = new String[0];
//            RegionList = new String[0];
//            Format = new Format();
//            Features = new Features();
//            StudioList = new String[0];
//            MediaCompanyList = new String[0];
//            AudioList = new AudioTrack[0];
//            SubtitleList = new String[0];
//            SRP = new Price();
//            DiscList = new Disc[0];
//            SortTitle = String.Empty;
//            PurchaseInfo = new PurchaseInfo();
//            Review = new Review();
//            MediaBanners = new MediaBanners();
//            EventList = new Event[0];
//            BoxSet = new BoxSet();
//            LoanInfo = new LoanInfo();
//        }

//        [XmlIgnore()]
//        public Int32 LocalityAsID
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                String[] split;

//                split = ID.Split('.');
//                if (split.Length == 1)
//                {
//                    return (0);
//                }
//                else
//                {
//                    if (split[1] == String.Empty)
//                    {
//                        return (0);
//                    }
//                    else
//                    {
//                        return (Int32.Parse(split[1]));
//                    }
//                }
//            }
//        }

//        [XmlIgnore()]
//        public String LocalityAsText
//        {
//            get
//            {
//                String locality;

//                if (Countries.Dictionary.TryGetValue(LocalityAsID, out locality) == false)
//                {
//                    locality = "<unknown>";
//                }
//                return (locality);
//            }
//        }

//        [XmlIgnore()]
//        public static XmlSerializer XmlSerializer
//        {
//            get
//            {
//                if (s_XmlSerializer == null)
//                {
//                    s_XmlSerializer = new XmlSerializer(typeof(DVD));
//                }
//                return (s_XmlSerializer);
//            }
//        }

//        public static void Serialize(String fileName, DVD instance)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
//                {
//                    xtw.Formatting = Formatting.Indented;
//                    XmlSerializer.Serialize(xtw, instance);
//                }
//            }
//        }

//        public void Serialize(String fileName)
//        {
//            Serialize(fileName, this);
//        }

//        public static DVD Deserialize(String fileName)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (XmlTextReader xtr = new XmlTextReader(fs))
//                {
//                    DVD instance;

//                    instance = (DVD)(XmlSerializer.Deserialize(xtr));
//                    return (instance);
//                }
//            }
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Title);
//            if (String.IsNullOrEmpty(Edition) == false)
//            {
//                sb.Append(": ");
//                sb.Append(Edition);
//            }
//            sb.Append(" (");
//            sb.Append(UPC);
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        public override Boolean Equals(Object obj)
//        {
//            DVD other;

//            other = obj as DVD;
//            if (other == null)
//            {
//                return (false);
//            }
//            return (ID == other.ID);
//        }

//        public override Int32 GetHashCode()
//        {
//            return (idField.GetHashCode());
//        }

//        private DateTime profileTimestampField;

//        private String idField;

//        private MediaTypes mediaTypesField;

//        private String uPCField;

//        private String collectionNumberField;

//        private String collectionTypeField;

//        private String titleField;

//        private String distTraitField;

//        private String originalTitleField;

//        private String countryOfOriginField;

//        private Int32 productionYearField;

//        private DateTime releasedField;

//        private Boolean releasedFieldSpecified;

//        private Int32 runningTimeField;

//        private String ratingSystemField;

//        private String ratingField;

//        private Int32 ratingAgeField;

//        private Int32 ratingVariantField;

//        private String ratingDetailsField;

//        private String caseTypeField;

//        private Boolean caseSlipCoverField;

//        private Boolean caseSlipCoverFieldSpecified;

//        private String[] genresField;

//        private String[] regionsField;

//        private Format formatField;

//        private Features featuresField;

//        private String[] studiosField;

//        private String[] mediaCompaniesField;

//        private AudioTrack[] audioField;

//        private String[] subtitlesField;

//        private Price sRPField;

//        private Object[] actorsField;

//        private Object[] creditsField;

//        private String overviewField;

//        private String easterEggsField;

//        private Disc[] discsField;

//        private String sortTitleField;

//        private DateTime lastEditedField;

//        private Boolean lastEditedFieldSpecified;

//        private Int32 wishPriorityField;

//        private Int32 countAsField;

//        private String customMediaTypeField;

//        private PurchaseInfo purchaseInfoField;

//        private Review reviewField;

//        private MediaBanners mediaBannersField;

//        private Exclusions exclusionsField;

//        private Event[] eventsField;

//        private BoxSet boxSetField;

//        private LoanInfo loanInfoField;

//        private String notesField;

//        private Tag[] tagsField;

//        private Locks locksField;

//        public DateTime ProfileTimestamp
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return profileTimestampField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                profileTimestampField = value;
//            }
//        }

//        public String ID
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return idField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                idField = value;
//            }
//        }

//        public MediaTypes MediaTypes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mediaTypesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mediaTypesField = value;
//            }
//        }

//        public String UPC
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return uPCField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                uPCField = value;
//            }
//        }

//        public String CollectionNumber
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return collectionNumberField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                collectionNumberField = value;
//            }
//        }

//        public String CollectionType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return collectionTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                collectionTypeField = value;
//            }
//        }

//        public String Title
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return titleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                titleField = value;
//            }
//        }

//        [XmlElement("DistTrait")]
//        public String Edition
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return distTraitField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                distTraitField = value;
//            }
//        }

//        public String OriginalTitle
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return originalTitleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                originalTitleField = value;
//            }
//        }

//        public String CountryOfOrigin
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return countryOfOriginField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                countryOfOriginField = value;
//            }
//        }

//        public Int32 ProductionYear
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return productionYearField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                productionYearField = value;
//            }
//        }

//        [XmlElement(DataType = "date")]
//        public DateTime Released
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return releasedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                releasedField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean ReleasedSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return releasedFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                releasedFieldSpecified = value;
//            }
//        }

//        public Int32 RunningTime
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return runningTimeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                runningTimeField = value;
//            }
//        }

//        public String RatingSystem
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingSystemField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingSystemField = value;
//            }
//        }

//        public String Rating
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingField = value;
//            }
//        }

//        public Int32 RatingAge
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingAgeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingAgeField = value;
//            }
//        }

//        public Int32 RatingVariant
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingVariantField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingVariantField = value;
//            }
//        }

//        public String RatingDetails
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingDetailsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingDetailsField = value;
//            }
//        }

//        public String CaseType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseTypeField = value;
//            }
//        }

//        [XmlElement("CaseSlipCover")]
//        public Boolean SlipCover
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseSlipCoverField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseSlipCoverField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean SlipCoverSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseSlipCoverFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseSlipCoverFieldSpecified = value;
//            }
//        }

//        [XmlArray("Genres")]
//        [XmlArrayItem("Genre", IsNullable = false)]
//        public String[] GenreList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return genresField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                genresField = value;
//            }
//        }

//        [XmlArray("Regions")]
//        [XmlArrayItem("Region", IsNullable = false)]
//        public String[] RegionList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return regionsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                regionsField = value;
//            }
//        }

//        public Format Format
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatField = value;
//            }
//        }

//        public Features Features
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featuresField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featuresField = value;
//            }
//        }

//        [XmlArray("Studios")]
//        [XmlArrayItem("Studio", IsNullable = false)]
//        public String[] StudioList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return studiosField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                studiosField = value;
//            }
//        }

//        [XmlArray("MediaCompanies")]
//        [XmlArrayItem("MediaCompany", IsNullable = false)]
//        public String[] MediaCompanyList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mediaCompaniesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mediaCompaniesField = value;
//            }
//        }

//        [XmlArray("Audio")]
//        [XmlArrayItem("AudioTrack", IsNullable = false)]
//        public AudioTrack[] AudioList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioField = value;
//            }
//        }

//        [XmlArray("Subtitles")]
//        [XmlArrayItem("Subtitle", IsNullable = false)]
//        public String[] SubtitleList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return subtitlesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                subtitlesField = value;
//            }
//        }

//        public Price SRP
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return sRPField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                sRPField = value;
//            }
//        }

//        [XmlArray("Actors")]
//        [XmlArrayItem("Actor", typeof(CastMember), IsNullable = false)]
//        [XmlArrayItem("Divider", typeof(Divider), IsNullable = false)]
//        public Object[] CastList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return actorsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                actorsField = value;
//            }
//        }

//        [XmlArray("Credits")]
//        [XmlArrayItem("Credit", typeof(CrewMember), IsNullable = false)]
//        [XmlArrayItem("Divider", typeof(CrewDivider), IsNullable = false)]
//        public Object[] CrewList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditsField = value;
//            }
//        }

//        public String Overview
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return overviewField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                overviewField = value;
//            }
//        }

//        public String EasterEggs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return easterEggsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                easterEggsField = value;
//            }
//        }

//        [XmlArray("Discs")]
//        [XmlArrayItem("Disc", IsNullable = false)]
//        public Disc[] DiscList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return discsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                discsField = value;
//            }
//        }

//        public String SortTitle
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return sortTitleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                sortTitleField = value;
//            }
//        }

//        public DateTime LastEdited
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastEditedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastEditedField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean LastEditedSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastEditedFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastEditedFieldSpecified = value;
//            }
//        }

//        public Int32 WishPriority
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return wishPriorityField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                wishPriorityField = value;
//            }
//        }

//        public Int32 CountAs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return countAsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                countAsField = value;
//            }
//        }

//        public String CustomMediaType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return customMediaTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                customMediaTypeField = value;
//            }
//        }

//        public PurchaseInfo PurchaseInfo
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchaseInfoField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchaseInfoField = value;
//            }
//        }

//        public Review Review
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return reviewField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                reviewField = value;
//            }
//        }

//        public MediaBanners MediaBanners
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mediaBannersField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mediaBannersField = value;
//            }
//        }

//        public Exclusions Exclusions
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return exclusionsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                exclusionsField = value;
//            }
//        }

//        [XmlArray("Events")]
//        [XmlArrayItem("Event", IsNullable = false)]
//        public Event[] EventList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return eventsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                eventsField = value;
//            }
//        }

//        public BoxSet BoxSet
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return boxSetField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                boxSetField = value;
//            }
//        }

//        public LoanInfo LoanInfo
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return loanInfoField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                loanInfoField = value;
//            }
//        }

//        public String Notes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return notesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                notesField = value;
//            }
//        }

//        [XmlArray("Tags")]
//        [XmlArrayItem("Tag", IsNullable = false)]
//        public Tag[] TagList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return tagsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                tagsField = value;
//            }
//        }

//        public Locks Locks
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return locksField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                locksField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class MediaTypes
//    {
//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            if (DVD)
//            {
//                sb.Append("DVD");
//            }
//            if (BluRay)
//            {
//                if (sb.Length > 0)
//                {
//                    sb.Append(" / ");
//                }
//                sb.Append("Blu-ray");
//            }
//            if (HDDVD)
//            {
//                if (sb.Length > 0)
//                {
//                    sb.Append(" / ");
//                }
//                sb.Append("HD-DVD");
//            }
//            if (String.IsNullOrEmpty(CustomMediaType) == false)
//            {
//                if (sb.Length > 0)
//                {
//                    sb.Append(" / ");
//                }
//                sb.Append(CustomMediaType);
//            }
//            return (sb.ToString());
//        }

//        private Boolean dVDField;

//        private Boolean hDDVDField;

//        private Boolean bluRayField;

//        private String customMediaTypeField;

//        public Boolean DVD
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dVDField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dVDField = value;
//            }
//        }

//        public Boolean HDDVD
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return hDDVDField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                hDDVDField = value;
//            }
//        }

//        public Boolean BluRay
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return bluRayField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                bluRayField = value;
//            }
//        }

//        public String CustomMediaType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return customMediaTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                customMediaTypeField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class BasicDVD
//    {
//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Title);
//            if (String.IsNullOrEmpty(Edition) == false)
//            {
//                sb.Append(": ");
//                sb.Append(Edition);
//            }
//            sb.Append(" (");
//            sb.Append(UPC);
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        private String idField;

//        private MediaTypes mediaTypesField;

//        private String uPCField;

//        private String collectionNumberField;

//        private String collectionTypeField;

//        private String titleField;

//        private String distTraitField;

//        private String originalTitleField;

//        private String countryOfOriginField;

//        private Int32 productionYearField;

//        private DateTime releasedField;

//        private Boolean releasedFieldSpecified;

//        private Int32 runningTimeField;

//        private String ratingSystemField;

//        private String ratingField;

//        private Int32 ratingAgeField;

//        private Int32 ratingVariantField;

//        private String caseTypeField;

//        private Boolean caseSlipCoverField;

//        private Boolean caseSlipCoverFieldSpecified;

//        private String overviewField;

//        private String easterEggsField;

//        private String sortTitleField;

//        private DateTime lastEditedField;

//        private Boolean lastEditedFieldSpecified;

//        private Int32 wishPriorityField;

//        private Int32 countAsField;

//        private String customMediaTypeField;

//        private PurchaseInfo purchaseInfoField;

//        private String notesField;

//        [XmlIgnore()]
//        public Int32 LocalityAsID
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                String[] split;

//                split = ID.Split('.');
//                if (split.Length == 1)
//                {
//                    return (0);
//                }
//                else
//                {
//                    if (split[1] == String.Empty)
//                    {
//                        return (0);
//                    }
//                    else
//                    {
//                        return (Int32.Parse(split[1]));
//                    }
//                }
//            }
//        }

//        [XmlIgnore()]
//        public String LocalityAsText
//        {
//            get
//            {
//                String locality;

//                if (Countries.Dictionary.TryGetValue(LocalityAsID, out locality) == false)
//                {
//                    locality = "<unknown>";
//                }
//                return (locality);
//            }
//        }

//        public String ID
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return idField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                idField = value;
//            }
//        }

//        public MediaTypes MediaTypes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mediaTypesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mediaTypesField = value;
//            }
//        }

//        public String UPC
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return uPCField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                uPCField = value;
//            }
//        }

//        public String CollectionNumber
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return collectionNumberField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                collectionNumberField = value;
//            }
//        }

//        public String CollectionType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return collectionTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                collectionTypeField = value;
//            }
//        }

//        public String Title
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return titleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                titleField = value;
//            }
//        }

//        [XmlElement("DistTrait")]
//        public String Edition
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return distTraitField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                distTraitField = value;
//            }
//        }

//        public String OriginalTitle
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return originalTitleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                originalTitleField = value;
//            }
//        }

//        public String CountryOfOrigin
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return countryOfOriginField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                countryOfOriginField = value;
//            }
//        }

//        public Int32 ProductionYear
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return productionYearField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                productionYearField = value;
//            }
//        }

//        [XmlElement(DataType = "date")]
//        public DateTime Released
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return releasedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                releasedField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean ReleasedSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return releasedFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                releasedFieldSpecified = value;
//            }
//        }

//        public Int32 RunningTime
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return runningTimeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                runningTimeField = value;
//            }
//        }

//        public String RatingSystem
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingSystemField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingSystemField = value;
//            }
//        }

//        public String Rating
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingField = value;
//            }
//        }

//        public Int32 RatingAge
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingAgeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingAgeField = value;
//            }
//        }

//        public Int32 RatingVariant
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingVariantField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingVariantField = value;
//            }
//        }

//        public String CaseType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseTypeField = value;
//            }
//        }

//        public Boolean CaseSlipCover
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseSlipCoverField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseSlipCoverField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean CaseSlipCoverSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseSlipCoverFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseSlipCoverFieldSpecified = value;
//            }
//        }

//        public String Overview
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return overviewField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                overviewField = value;
//            }
//        }

//        public String EasterEggs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return easterEggsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                easterEggsField = value;
//            }
//        }

//        public String SortTitle
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return sortTitleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                sortTitleField = value;
//            }
//        }

//        public DateTime LastEdited
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastEditedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastEditedField = value;
//            }
//        }


//        [XmlIgnore()]
//        public Boolean LastEditedSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastEditedFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastEditedFieldSpecified = value;
//            }
//        }

//        public Int32 WishPriority
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return wishPriorityField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                wishPriorityField = value;
//            }
//        }

//        public Int32 CountAs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return countAsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                countAsField = value;
//            }
//        }

//        public String CustomMediaType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return customMediaTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                customMediaTypeField = value;
//            }
//        }

//        public PurchaseInfo PurchaseInfo
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchaseInfoField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchaseInfoField = value;
//            }
//        }

//        public String Notes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return notesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                notesField = value;
//            }
//        }
//    }

//    [Serializable()]
//    public class Locks
//    {
//        private Boolean entireField;

//        private Boolean coversField;

//        private Boolean titleField;

//        private Boolean mediaTypeField;

//        private Boolean overviewField;

//        private Boolean regionsField;

//        private Boolean genresField;

//        private Boolean sRPField;

//        private Boolean studiosField;

//        private Boolean discInformationField;

//        private Boolean castField;

//        private Boolean crewField;

//        private Boolean featuresField;

//        private Boolean audioTracksField;

//        private Boolean subtitlesField;

//        private Boolean easterEggsField;

//        private Boolean runningTimeField;

//        private Boolean releaseDateField;

//        private Boolean productionYearField;

//        private Boolean caseTypeField;

//        private Boolean videoFormatsField;

//        private Boolean ratingField;

//        public Boolean Entire
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return entireField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                entireField = value;
//            }
//        }

//        public Boolean Covers
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return coversField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                coversField = value;
//            }
//        }

//        public Boolean Title
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return titleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                titleField = value;
//            }
//        }

//        public Boolean MediaType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mediaTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mediaTypeField = value;
//            }
//        }

//        public Boolean Overview
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return overviewField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                overviewField = value;
//            }
//        }

//        public Boolean Regions
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return regionsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                regionsField = value;
//            }
//        }

//        public Boolean Genres
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return genresField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                genresField = value;
//            }
//        }

//        public Boolean SRP
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return sRPField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                sRPField = value;
//            }
//        }

//        public Boolean Studios
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return studiosField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                studiosField = value;
//            }
//        }

//        public Boolean DiscInformation
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return discInformationField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                discInformationField = value;
//            }
//        }

//        public Boolean Cast
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return castField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                castField = value;
//            }
//        }

//        public Boolean Crew
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return crewField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                crewField = value;
//            }
//        }

//        public Boolean Features
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featuresField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featuresField = value;
//            }
//        }

//        public Boolean AudioTracks
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioTracksField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioTracksField = value;
//            }
//        }

//        public Boolean Subtitles
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return subtitlesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                subtitlesField = value;
//            }
//        }

//        public Boolean EasterEggs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return easterEggsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                easterEggsField = value;
//            }
//        }

//        public Boolean RunningTime
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return runningTimeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                runningTimeField = value;
//            }
//        }

//        public Boolean ReleaseDate
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return releaseDateField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                releaseDateField = value;
//            }
//        }

//        public Boolean ProductionYear
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return productionYearField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                productionYearField = value;
//            }
//        }

//        public Boolean CaseType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return caseTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                caseTypeField = value;
//            }
//        }

//        public Boolean VideoFormats
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return videoFormatsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                videoFormatsField = value;
//            }
//        }

//        public Boolean Rating
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return ratingField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                ratingField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class Tag
//    {
//        public Tag()
//        {
//            Name = String.Empty;
//            FullName = String.Empty;
//        }

//        public override String ToString()
//        {
//            return (FullName);
//        }

//        private String nameField;

//        private String fullNameField;

//        [XmlAttribute()]
//        public String Name
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return nameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                nameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String FullName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return fullNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                fullNameField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class LoanInfo
//    {
//        public override String ToString()
//        {
//            if (Loaned)
//            {
//                StringBuilder sb;

//                sb = new StringBuilder();
//                if (DueSpecified)
//                {
//                    sb.Append("until");
//                    sb.Append(Due.ToShortDateString());
//                }
//                if (User != null)
//                {
//                    if (DueSpecified)
//                    {
//                        sb.Append(" ");
//                    }
//                    sb.Append("by ");
//                    sb.Append(User.ToString());
//                }
//                return (sb.ToString());
//            }
//            else
//            {
//                return ("not loaned");
//            }
//        }

//        private Boolean loanedField;

//        private DateTime dueField;

//        private Boolean dueFieldSpecified;

//        private BasicUser userField;

//        public Boolean Loaned
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return loanedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                loanedField = value;
//            }
//        }

//        [XmlElement(DataType = "date")]
//        public DateTime Due
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dueField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dueField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean DueSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dueFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dueFieldSpecified = value;
//            }
//        }

//        public BasicUser User
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return userField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                userField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class BasicUser
//    {
//        public BasicUser()
//        {
//            FirstName = String.Empty;
//            LastName = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder name;

//            name = new StringBuilder();
//            if (String.IsNullOrEmpty(FirstName) == false)
//            {
//                name.Append(FirstName);
//            }
//            if (String.IsNullOrEmpty(LastName) == false)
//            {
//                if (name.Length != 0)
//                {
//                    name.Append(" ");
//                }
//                name.Append(LastName);
//            }
//            return (name.ToString());
//        }

//        private String firstNameField;

//        private String lastNameField;

//        [XmlAttribute()]
//        public String FirstName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return firstNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                firstNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String LastName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastNameField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class User : BasicUser
//    {
//        public User()
//        {
//            EmailAddress = String.Empty;
//            PhoneNumber = String.Empty;
//        }

//        public User(BasicUser user)
//        {
//            FirstName = user.FirstName;
//            LastName = user.LastName;
//            EmailAddress = String.Empty;
//            PhoneNumber = String.Empty;
//        }

//        private String emailAddressField;

//        private String phoneNumberField;

//        [XmlAttribute()]
//        public String EmailAddress
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return emailAddressField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                emailAddressField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String PhoneNumber
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return phoneNumberField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                phoneNumberField = value;
//            }
//        }
//    }

//    [Serializable()]
//    public class BoxSet
//    {
//        public BoxSet()
//        {
//            Parent = String.Empty;
//            ContentList = new String[0];
//        }

//        private String parentField;

//        private String[] contentsField;

//        public String Parent
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return parentField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                parentField = value;
//            }
//        }

//        [XmlArray("Contents")]
//        [XmlArrayItem("Content", IsNullable = false)]
//        public String[] ContentList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return contentsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                contentsField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class Event
//    {
//        public Event()
//        {
//            Type = EventType.Watched;
//            Timestamp = DateTime.UtcNow;
//            User = new User();
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Type);
//            sb.Append(" at ");
//            sb.Append(Timestamp.ToShortDateString());
//            if (User != null)
//            {
//                sb.Append(" by ");
//                sb.Append(User.ToString());
//            }
//            return (sb.ToString());
//        }

//        private EventType eventTypeField;

//        private DateTime timestampField;

//        private User userField;

//        [XmlElement("EventType")]
//        public EventType Type
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return eventTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                eventTypeField = value;
//            }
//        }

//        public DateTime Timestamp
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return timestampField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                timestampField = value;
//            }
//        }

//        public User User
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return userField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                userField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    [XmlType(AnonymousType = true)]
//    public enum EventType
//    {
//        Watched,

//        Returned,

//        Borrowed
//    }

//    [Serializable()]
//    public class Exclusions
//    {
//        private Boolean moviePickField;

//        private Boolean moviePickFieldSpecified;

//        private Boolean mobileField;

//        private Boolean mobileFieldSpecified;

//        private Boolean iPhoneField;

//        private Boolean iPhoneFieldSpecified;

//        private Boolean remoteConnectionsField;

//        private Boolean remoteConnectionsFieldSpecified;

//        private Boolean dPOPublicField;

//        private Boolean dPOPublicFieldSpecified;

//        private Boolean dPOPrivateField;

//        private Boolean dPOPrivateFieldSpecified;

//        public Boolean MoviePick
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return moviePickField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                moviePickField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean MoviePickSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return moviePickFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                moviePickFieldSpecified = value;
//            }
//        }

//        public Boolean Mobile
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mobileField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mobileField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean MobileSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return mobileFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                mobileFieldSpecified = value;
//            }
//        }

//        public Boolean iPhone
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return iPhoneField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                iPhoneField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean iPhoneSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return iPhoneFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                iPhoneFieldSpecified = value;
//            }
//        }

//        public Boolean RemoteConnections
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return remoteConnectionsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                remoteConnectionsField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean RemoteConnectionsSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return remoteConnectionsFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                remoteConnectionsFieldSpecified = value;
//            }
//        }

//        public Boolean DPOPublic
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dPOPublicField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dPOPublicField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean DPOPublicSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dPOPublicFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dPOPublicFieldSpecified = value;
//            }
//        }

//        public Boolean DPOPrivate
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dPOPrivateField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dPOPrivateField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean DPOPrivateSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dPOPrivateFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dPOPrivateFieldSpecified = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class MediaBanners
//    {
//        public MediaBanners()
//        {
//            Front = MediaBannersRestriction.Automatic;
//            Back = MediaBannersRestriction.Automatic;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Front);
//            sb.Append(" / ");
//            sb.Append(Back);
//            return (sb.ToString());
//        }

//        private MediaBannersRestriction frontField;

//        private MediaBannersRestriction backField;

//        [XmlAttribute()]
//        public MediaBannersRestriction Front
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return frontField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                frontField = value;
//            }
//        }

//        [XmlAttribute()]
//        public MediaBannersRestriction Back
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return backField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                backField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public enum MediaBannersRestriction
//    {
//        On,

//        Off,

//        Automatic
//    }

//    [Serializable()]
//    public class Review
//    {
//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append("Film: ");
//            sb.Append(Film);
//            sb.Append(" / Video: ");
//            sb.Append(Video);
//            sb.Append(" / Audio: ");
//            sb.Append(Audio);
//            sb.Append(" / Extras: ");
//            sb.Append(Extras);
//            return (sb.ToString());
//        }

//        private Int32 filmField;

//        private Int32 videoField;

//        private Int32 audioField;

//        private Int32 extrasField;

//        [XmlAttribute()]
//        public Int32 Film
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return filmField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                filmField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Int32 Video
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return videoField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                videoField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Int32 Audio
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Int32 Extras
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return extrasField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                extrasField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class PurchaseInfo
//    {
//        public PurchaseInfo()
//        {
//            Price = new Price();
//            Place = String.Empty;
//            Type = String.Empty;
//            Website = String.Empty;
//        }

//        public override String ToString()
//        {
//            if (Price != null)
//            {
//                StringBuilder sb;

//                sb = new StringBuilder();
//                sb.Append(Price);
//                if (DateSpecified)
//                {
//                    sb.Append(" at ");
//                    sb.Append(Date.ToShortDateString());
//                }
//                return (sb.ToString());
//            }
//            return (base.ToString());
//        }

//        private Price purchasePriceField;

//        private String purchasePlaceField;

//        private String purchasePlaceTypeField;

//        private String purchasePlaceWebsiteField;

//        private DateTime purchaseDateField;

//        private Boolean purchaseDateFieldSpecified;

//        [XmlElement("PurchasePrice")]
//        public Price Price
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchasePriceField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchasePriceField = value;
//            }
//        }

//        [XmlElement("PurchasePlace")]
//        public String Place
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchasePlaceField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchasePlaceField = value;
//            }
//        }

//        [XmlElement("PurchasePlaceType")]
//        public String Type
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchasePlaceTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchasePlaceTypeField = value;
//            }
//        }

//        [XmlElement("PurchasePlaceWebsite")]
//        public String Website
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchasePlaceWebsiteField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchasePlaceWebsiteField = value;
//            }
//        }

//        [XmlElement("PurchaseDate", DataType = "date")]
//        public DateTime Date
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchaseDateField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchaseDateField = value;
//            }
//        }

//        [XmlIgnore()]
//        public Boolean DateSpecified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return purchaseDateFieldSpecified;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                purchaseDateFieldSpecified = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class Price
//    {
//        public Price()
//        {
//            DenominationType = String.Empty;
//            DenominationDesc = String.Empty;
//            FormattedValue = String.Empty;
//        }

//        public override String ToString()
//        {
//            return (FormattedValue);
//        }

//        private String denominationTypeField;

//        private String denominationDescField;

//        private String formattedValueField;

//        private Single valueField;

//        [XmlAttribute()]
//        public String DenominationType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return denominationTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                denominationTypeField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String DenominationDesc
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return denominationDescField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                denominationDescField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String FormattedValue
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formattedValueField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formattedValueField = value;
//            }
//        }

//        [XmlText()]
//        public Single Value
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return valueField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                valueField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class Disc
//    {
//        public Disc()
//        {
//            DescriptionSideA = String.Empty;
//            DescriptionSideB = String.Empty;
//            DiscIDSideA = String.Empty;
//            DiscIDSideB = String.Empty;
//            LabelSideA = String.Empty;
//            LabelSideB = String.Empty;
//            Location = String.Empty;
//            Slot = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(DescriptionSideA);
//            if (String.IsNullOrEmpty(DescriptionSideB) == false)
//            {
//                sb.Append(" / ");
//                sb.Append(DescriptionSideB);
//            }
//            return (sb.ToString());
//        }

//        private String descriptionSideAField;

//        private String descriptionSideBField;

//        private String discIDSideAField;

//        private String discIDSideBField;

//        private String labelSideAField;

//        private String labelSideBField;

//        private Boolean dualLayeredSideAField;

//        private Boolean dualLayeredSideBField;

//        private Boolean dualSidedField;

//        private String locationField;

//        private String slotField;

//        public String DescriptionSideA
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return descriptionSideAField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                descriptionSideAField = value;
//            }
//        }

//        public String DescriptionSideB
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return descriptionSideBField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                descriptionSideBField = value;
//            }
//        }

//        public String DiscIDSideA
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return discIDSideAField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                discIDSideAField = value;
//            }
//        }

//        public String DiscIDSideB
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return discIDSideBField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                discIDSideBField = value;
//            }
//        }

//        public String LabelSideA
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return labelSideAField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                labelSideAField = value;
//            }
//        }

//        public String LabelSideB
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return labelSideBField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                labelSideBField = value;
//            }
//        }

//        public Boolean DualLayeredSideA
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dualLayeredSideAField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dualLayeredSideAField = value;
//            }
//        }

//        public Boolean DualLayeredSideB
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dualLayeredSideBField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dualLayeredSideBField = value;
//            }
//        }

//        public Boolean DualSided
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dualSidedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dualSidedField = value;
//            }
//        }

//        public String Location
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return locationField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                locationField = value;
//            }
//        }

//        public String Slot
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return slotField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                slotField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class CrewMember : IPerson
//    {
//        public CrewMember()
//        {
//            FirstName = String.Empty;
//            MiddleName = String.Empty;
//            LastName = String.Empty;
//            CreditType = String.Empty;
//            CreditSubtype = String.Empty;
//            CustomRole = String.Empty;
//            CreditedAs = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            if (String.IsNullOrEmpty(FirstName) == false)
//            {
//                sb.Append(FirstName);
//            }
//            if (String.IsNullOrEmpty(MiddleName) == false)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append(MiddleName);
//            }
//            if (String.IsNullOrEmpty(LastName) == false)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append(LastName);
//            }
//            if (BirthYear > 0)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append("(" + BirthYear + ")");
//            }
//            sb.Append(": ");
//            sb.Append(CreditType);
//            sb.Append(" / ");
//            sb.Append(CreditSubtype);
//            if (String.IsNullOrEmpty(CustomRole) == false)
//            {
//                sb.Append(" (");
//                sb.Append(CustomRole);
//                sb.Append(")");
//            }
//            if (String.IsNullOrEmpty(CreditedAs) == false)
//            {
//                sb.Append(" (as ");
//                sb.Append(CreditedAs);
//                sb.Append(")");
//            }
//            return (sb.ToString());
//        }

//        private String firstNameField;

//        private String middleNameField;

//        private String lastNameField;

//        private Int32 birthYearField;

//        private String creditTypeField;

//        private String creditSubtypeField;

//        private String creditedAsField;

//        private String customRoleField;

//        [XmlAttribute()]
//        public String FirstName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return firstNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                firstNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String MiddleName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return middleNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                middleNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String LastName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Int32 BirthYear
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return birthYearField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                birthYearField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String CreditType
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditTypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditTypeField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String CreditSubtype
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditSubtypeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditSubtypeField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String CreditedAs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditedAsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditedAsField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String CustomRole
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return customRoleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                customRoleField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class CastMember : IPerson
//    {
//        public CastMember()
//        {
//            FirstName = String.Empty;
//            MiddleName = String.Empty;
//            LastName = String.Empty;
//            Role = String.Empty;
//            CreditedAs = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            if (String.IsNullOrEmpty(FirstName) == false)
//            {
//                sb.Append(FirstName);
//            }
//            if (String.IsNullOrEmpty(MiddleName) == false)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append(MiddleName);
//            }
//            if (String.IsNullOrEmpty(LastName) == false)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append(LastName);
//            }
//            if (BirthYear > 0)
//            {
//                if (sb.Length != 0)
//                {
//                    sb.Append(" ");
//                }
//                sb.Append("(" + BirthYear + ")");
//            }
//            sb.Append(": ");
//            sb.Append(Role);
//            if (Voice)
//            {
//                sb.Append(" (voice)");
//            }
//            if (Uncredited)
//            {
//                sb.Append(" (uncredited)");
//            }
//            if (String.IsNullOrEmpty(CreditedAs) == false)
//            {
//                sb.Append(" (as ");
//                sb.Append(CreditedAs);
//                sb.Append(")");
//            }
//            return (sb.ToString());
//        }

//        private String firstNameField;

//        private String middleNameField;

//        private String lastNameField;

//        private Int32 birthYearField;

//        private String roleField;

//        private String creditedAsField;

//        private Boolean voiceField;

//        private Boolean uncreditedField;

//        [XmlAttribute()]
//        public String FirstName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return firstNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                firstNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String MiddleName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return middleNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                middleNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String LastName
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return lastNameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                lastNameField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Int32 BirthYear
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return birthYearField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                birthYearField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String Role
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return roleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                roleField = value;
//            }
//        }

//        [XmlAttribute()]
//        public String CreditedAs
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditedAsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditedAsField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Boolean Voice
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return voiceField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                voiceField = value;
//            }
//        }

//        [XmlAttribute()]
//        public Boolean Uncredited
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return uncreditedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                uncreditedField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public class Divider
//    {
//        public Divider()
//        {
//            Caption = String.Empty;
//            Type = DividerType.Episode;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Caption);
//            sb.Append(" (");
//            sb.Append(Type);
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        private String captionField;

//        private DividerType typeField;

//        [XmlAttribute()]
//        public String Caption
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return captionField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                captionField = value;
//            }
//        }

//        [XmlAttribute()]
//        public DividerType Type
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return typeField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                typeField = value;
//            }
//        }

//        [XmlAnyAttribute()]
//        public XmlNode[] OpenAttributes;
//    }

//    [Serializable()]
//    public partial class CrewDivider : Divider
//    {
//        public CrewDivider()
//        {
//            CreditType = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Caption);
//            sb.Append(" (");
//            sb.Append(Type);
//            if (Type != DividerType.Episode)
//            {
//                sb.Append(", ");
//                sb.Append(CreditType);
//            }
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        private String creditTypeField;

//        [XmlAttributeAttribute()]
//        public String CreditType
//        {
//            get
//            {
//                return creditTypeField;
//            }
//            set
//            {
//                creditTypeField = value;
//            }
//        }

//        public Boolean ShouldSerializeCreditType()
//        {
//            return (Type != DividerType.Episode);
//        }
//    }

//    [Serializable()]
//    [XmlType(AnonymousType = true)]
//    public enum DividerType
//    {
//        Episode,

//        Group,

//        EndDiv
//    }

//    [Serializable()]
//    public class AudioTrack
//    {
//        public AudioTrack()
//        {
//            Content = String.Empty;
//            Format = String.Empty;
//            Channels = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Content);
//            sb.Append(" / ");
//            sb.Append(Format);
//            sb.Append(" / ");
//            sb.Append(Channels);
//            return (sb.ToString());
//        }

//        private String audioContentField;

//        private String audioFormatField;

//        private String audioChannelsField;

//        [XmlElement("AudioContent")]
//        public String Content
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioContentField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioContentField = value;
//            }
//        }

//        [XmlElement("AudioFormat")]
//        public String Format
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioFormatField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioFormatField = value;
//            }
//        }

//        [XmlElement("AudioChannels")]
//        public String Channels
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return audioChannelsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                audioChannelsField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class Features
//    {
//        public Features()
//        {
//            OtherFeatures = String.Empty;
//        }

//        private Boolean featureSceneAccessField;

//        private Boolean featureCommentaryField;

//        private Boolean featureTrailerField;

//        private Boolean featurePhotoGalleryField;

//        private Boolean featureDeletedScenesField;

//        private Boolean featureMakingOfField;

//        private Boolean featureProductionNotesField;

//        private Boolean featureGameField;

//        private Boolean featureDVDROMContentField;

//        private Boolean featureMultiAngleField;

//        private Boolean featureMusicVideosField;

//        private Boolean featureInterviewsField;

//        private Boolean featureStoryboardComparisonsField;

//        private Boolean featureOuttakesField;

//        private Boolean featureClosedCaptionedField;

//        private Boolean featureTHXCertifiedField;

//        private Boolean featurePIPField;

//        private Boolean featureBDLiveField;

//        private Boolean featureBonusTrailersField;

//        private Boolean featureDigitalCopyField;

//        private String otherFeaturesField;

//        [XmlElement("FeatureSceneAccess")]
//        public Boolean SceneAccess
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureSceneAccessField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureSceneAccessField = value;
//            }
//        }

//        [XmlElement("FeatureCommentary")]
//        public Boolean Commentary
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureCommentaryField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureCommentaryField = value;
//            }
//        }

//        [XmlElement("FeatureTrailer")]
//        public Boolean Trailer
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureTrailerField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureTrailerField = value;
//            }
//        }

//        [XmlElement("FeaturePhotoGallery")]
//        public Boolean PhotoGallery
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featurePhotoGalleryField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featurePhotoGalleryField = value;
//            }
//        }

//        [XmlElement("FeatureDeletedScenes")]
//        public Boolean DeletedScenes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureDeletedScenesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureDeletedScenesField = value;
//            }
//        }

//        [XmlElement("FeatureMakingOf")]
//        public Boolean MakingOf
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureMakingOfField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureMakingOfField = value;
//            }
//        }

//        [XmlElement("FeatureProductionNotes")]
//        public Boolean ProductionNotes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureProductionNotesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureProductionNotesField = value;
//            }
//        }

//        [XmlElement("FeatureGame")]
//        public Boolean Game
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureGameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureGameField = value;
//            }
//        }

//        [XmlElement("FeatureDVDROMContent")]
//        public Boolean DVDROMContent
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureDVDROMContentField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureDVDROMContentField = value;
//            }
//        }

//        [XmlElement("FeatureMultiAngle")]
//        public Boolean MultiAngle
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureMultiAngleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureMultiAngleField = value;
//            }
//        }

//        [XmlElement("FeatureMusicVideos")]
//        public Boolean MusicVideos
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureMusicVideosField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureMusicVideosField = value;
//            }
//        }

//        [XmlElement("FeatureInterviews")]
//        public Boolean Interviews
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureInterviewsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureInterviewsField = value;
//            }
//        }

//        [XmlElement("FeatureStoryboardComparisons")]
//        public Boolean StoryboardComparisons
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureStoryboardComparisonsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureStoryboardComparisonsField = value;
//            }
//        }

//        [XmlElement("FeatureOuttakes")]
//        public Boolean Outtakes
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureOuttakesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureOuttakesField = value;
//            }
//        }

//        [XmlElement("FeatureClosedCaptioned")]
//        public Boolean ClosedCaptioned
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureClosedCaptionedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureClosedCaptionedField = value;
//            }
//        }

//        [XmlElement("FeatureTHXCertified")]
//        public Boolean THXCertified
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureTHXCertifiedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureTHXCertifiedField = value;
//            }
//        }

//        [XmlElement("FeaturePIP")]
//        public Boolean PIP
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featurePIPField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featurePIPField = value;
//            }
//        }

//        [XmlElement("FeatureBDLive")]
//        public Boolean BDLive
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureBDLiveField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureBDLiveField = value;
//            }
//        }

//        [XmlElement("FeatureBonusTrailers")]
//        public Boolean BonusTrailers
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureBonusTrailersField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureBonusTrailersField = value;
//            }
//        }

//        [XmlElement("FeatureDigitalCopy")]
//        public Boolean DigitalCopy
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return featureDigitalCopyField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                featureDigitalCopyField = value;
//            }
//        }

//        public String OtherFeatures
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return otherFeaturesField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                otherFeaturesField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    public class Format
//    {
//        public Format()
//        {
//            AspectRatio = String.Empty;
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(VideoStandard);
//            sb.Append(" ");
//            sb.Append(AspectRatio);
//            return (sb.ToString());
//        }

//        private String formatAspectRatioField;

//        private VideoStandard formatVideoStandardField;

//        private Boolean formatLetterBoxField;

//        private Boolean formatPanAndScanField;

//        private Boolean formatFullFrameField;

//        private Boolean format16X9Field;

//        private Boolean formatDualSidedField;

//        private Boolean formatDualLayeredField;

//        [XmlElement("FormatAspectRatio")]
//        public String AspectRatio
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatAspectRatioField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatAspectRatioField = value;
//            }
//        }

//        [XmlElement("FormatVideoStandard")]
//        public VideoStandard VideoStandard
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatVideoStandardField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatVideoStandardField = value;
//            }
//        }

//        [XmlElement("FormatLetterBox")]
//        public Boolean LetterBox
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatLetterBoxField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatLetterBoxField = value;
//            }
//        }

//        [XmlElement("FormatPanAndScan")]
//        public Boolean PanAndScan
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatPanAndScanField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatPanAndScanField = value;
//            }
//        }

//        [XmlElement("FormatFullFrame")]
//        public Boolean FullFrame
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatFullFrameField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatFullFrameField = value;
//            }
//        }

//        [XmlElement("Format16X9")]
//        public Boolean Enhanced16X9
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return format16X9Field;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                format16X9Field = value;
//            }
//        }

//        [XmlElement("FormatDualSided")]
//        public Boolean DualSided
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatDualSidedField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatDualSidedField = value;
//            }
//        }

//        [XmlElement("FormatDualLayered")]
//        public Boolean DualLayered
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return formatDualLayeredField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                formatDualLayeredField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    [XmlType(AnonymousType = true)]
//    public enum VideoStandard
//    {
//        NTSC,

//        PAL
//    }

//    [Serializable()]
//    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "Collection")]
//    public class BasicCollection
//    {
//        private static XmlSerializer s_XmlSerializer;

//        [XmlIgnore()]
//        public static XmlSerializer XmlSerializer
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                if (s_XmlSerializer == null)
//                {
//                    s_XmlSerializer = new XmlSerializer(typeof(BasicCollection));
//                }
//                return (s_XmlSerializer);
//            }
//        }

//        public static void Serialize(String fileName, BasicCollection instance)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding(1252)))
//                {
//                    xtw.Formatting = Formatting.Indented;
//                    XmlSerializer.Serialize(xtw, instance);
//                }
//            }
//        }

//        public void Serialize(String fileName)
//        {
//            Serialize(fileName, this);
//        }

//        public static BasicCollection Deserialize(String fileName)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (XmlTextReader xtr = new XmlTextReader(fs))
//                {
//                    BasicCollection instance;

//                    instance = (BasicCollection)(XmlSerializer.Deserialize(xtr));
//                    return (instance);
//                }
//            }
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append("Count: ");
//            if (DVDList != null)
//            {
//                sb.Append(DVDList.Length);
//            }
//            else
//            {
//                sb.Append("none");
//            }
//            return (sb.ToString());
//        }

//        private BasicDVD[] dVDField;

//        [XmlElement("DVD")]
//        public BasicDVD[] DVDList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return dVDField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                dVDField = value;
//            }
//        }
//    }

//    [Serializable()]
//    [XmlRoot(Namespace = "", IsNullable = false)]
//    public class CastInformation
//    {
//        private static XmlSerializer s_XmlSerializer;

//        public CastInformation()
//        {
//            Title = String.Empty;
//            CastList = new Object[0];
//        }

//        [XmlIgnore()]
//        public static XmlSerializer XmlSerializer
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                if (s_XmlSerializer == null)
//                {
//                    s_XmlSerializer = new XmlSerializer(typeof(CastInformation));
//                }
//                return (s_XmlSerializer);
//            }
//        }

//        public static void Serialize(String fileName, CastInformation instance)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
//                {
//                    xtw.Formatting = Formatting.Indented;
//                    XmlSerializer.Serialize(xtw, instance);
//                }
//            }
//        }

//        public void Serialize(String fileName)
//        {
//            Serialize(fileName, this);
//        }

//        public static CastInformation Deserialize(String fileName)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (XmlTextReader xtr = new XmlTextReader(fs))
//                {
//                    CastInformation instance;

//                    instance = (CastInformation)(XmlSerializer.Deserialize(xtr));
//                    return (instance);
//                }
//            }
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Title);
//            sb.Append("(Count: ");
//            if (CastList != null)
//            {
//                sb.Append(CastList.Length);
//            }
//            else
//            {
//                sb.Append("none");
//            }
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        private String titleField;

//        private Object[] actorsField;

//        public String Title
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return titleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                titleField = value;
//            }
//        }

//        [XmlArray("Actors")]
//        [XmlArrayItem("Actor", typeof(CastMember), IsNullable = false)]
//        [XmlArrayItem("Divider", typeof(Divider), IsNullable = false)]
//        public Object[] CastList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return actorsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                actorsField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }

//    [Serializable()]
//    [XmlRoot(Namespace = "", IsNullable = false)]
//    public class CrewInformation
//    {
//        private static XmlSerializer s_XmlSerializer;

//        public CrewInformation()
//        {
//            Title = String.Empty;
//            CrewList = new Object[0];
//        }

//        [XmlIgnore()]
//        public static XmlSerializer XmlSerializer
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                if (s_XmlSerializer == null)
//                {
//                    s_XmlSerializer = new XmlSerializer(typeof(CrewInformation));
//                }
//                return (s_XmlSerializer);
//            }
//        }

//        public static void Serialize(String fileName, CrewInformation instance)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
//                {
//                    xtw.Formatting = Formatting.Indented;
//                    XmlSerializer.Serialize(xtw, instance);
//                }
//            }
//        }

//        public void Serialize(String fileName)
//        {
//            Serialize(fileName, this);
//        }

//        public static CrewInformation Deserialize(String fileName)
//        {
//            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
//            {
//                using (XmlTextReader xtr = new XmlTextReader(fs))
//                {
//                    CrewInformation instance;

//                    instance = (CrewInformation)(XmlSerializer.Deserialize(xtr));
//                    return (instance);
//                }
//            }
//        }

//        public override String ToString()
//        {
//            StringBuilder sb;

//            sb = new StringBuilder();
//            sb.Append(Title);
//            sb.Append("(Count: ");
//            if (CrewList != null)
//            {
//                sb.Append(CrewList.Length);
//            }
//            else
//            {
//                sb.Append("none");
//            }
//            sb.Append(")");
//            return (sb.ToString());
//        }

//        private String titleField;

//        private Object[] creditsField;

//        public String Title
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return titleField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                titleField = value;
//            }
//        }

//        [XmlArray("Credits")]
//        [XmlArrayItem("Credit", typeof(CrewMember), IsNullable = false)]
//        [XmlArrayItem("Divider", typeof(CrewDivider), IsNullable = false)]
//        public Object[] CrewList
//        {
//            [DebuggerStepThrough()]
//            get
//            {
//                return creditsField;
//            }
//            [DebuggerStepThrough()]
//            set
//            {
//                creditsField = value;
//            }
//        }

//        [XmlAnyElement()]
//        public XmlNode[] OpenElements;
//    }
//}