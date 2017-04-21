using System;
using System.ComponentModel;
using System.Text;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML
{
    /// <summary>
    /// This object can be used as key in hashtables and dictionaries.
    /// </summary>
    [ImmutableObject(true)]
    public sealed class PersonKey
    {
        #region Private Class

        private sealed class Person : IPerson
        {
            #region IPerson 

            public String LastName { get; set; }

            public String MiddleName { get; set; }

            public String FirstName { get; set; }

            public Int32 BirthYear { get; set; }

            public String CreditedAs { get; set; }

            #endregion

            internal Person(IPerson person)
            {
                if (String.IsNullOrEmpty(person.LastName) == false)
                {
                    LastName = person.LastName;
                }
                else
                {
                    LastName = String.Empty;
                }
                if (String.IsNullOrEmpty(person.MiddleName) == false)
                {
                    MiddleName = person.MiddleName;
                }
                else
                {
                    MiddleName = String.Empty;
                }
                if (String.IsNullOrEmpty(person.FirstName) == false)
                {
                    FirstName = person.FirstName;
                }
                else
                {
                    FirstName = String.Empty;
                }
                BirthYear = person.BirthYear;
                if (String.IsNullOrEmpty(person.CreditedAs) == false)
                {
                    CreditedAs = person.CreditedAs;
                }
                else
                {
                    CreditedAs = String.Empty;
                }
            }
        }

        #endregion

        #region Fields

        private Person m_KeyData;

        private Int32 m_HashCode;

        #endregion

        #region Properties

        public IPerson KeyData
            => (new Person(m_KeyData));

        public String FormattedName
        {
            get
            {
                StringBuilder name = new StringBuilder();

                if (String.IsNullOrEmpty(m_KeyData.FirstName) == false)
                {
                    name.Append(m_KeyData.FirstName);
                }

                if (String.IsNullOrEmpty(m_KeyData.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(m_KeyData.MiddleName);
                }

                if (String.IsNullOrEmpty(m_KeyData.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(m_KeyData.LastName);
                }

                if (m_KeyData.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + m_KeyData.BirthYear + ")");
                }

                return (name.ToString());
            }
        }

        public String FormattedNameWithMarkers
        {
            get
            {
                StringBuilder name = new StringBuilder();

                if (String.IsNullOrEmpty(m_KeyData.FirstName) == false)
                {
                    name.Append("<" + m_KeyData.FirstName + ">");
                }

                if (String.IsNullOrEmpty(m_KeyData.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("{" + m_KeyData.MiddleName + "}");
                }

                if (String.IsNullOrEmpty(m_KeyData.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("[" + m_KeyData.LastName + "]");
                }

                if (m_KeyData.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + m_KeyData.BirthYear + ")");
                }

                return (name.ToString());
            }
        }

        #endregion

        #region Constructor

        public PersonKey(IPerson person)
        {
            m_KeyData = new Person(person);
            m_HashCode = m_KeyData.LastName.GetHashCode() / 4
                + m_KeyData.FirstName.GetHashCode() / 4
                + m_KeyData.MiddleName.GetHashCode() / 4
                + m_KeyData.BirthYear.GetHashCode() / 4;
        }

        #endregion

        #region Methods

        public override Int32 GetHashCode()
            => (m_HashCode);

        public override Boolean Equals(Object obj)
        {
            PersonKey other = obj as PersonKey;

            if (other == null)
            {
                return (false);
            }
            else
            {
                return ((m_KeyData.LastName == other.m_KeyData.LastName)
                    && (m_KeyData.FirstName == other.m_KeyData.FirstName)
                    && (m_KeyData.MiddleName == other.m_KeyData.MiddleName)
                    && (m_KeyData.BirthYear == other.m_KeyData.BirthYear));
            }
        }

        public override String ToString()
            => (FormattedNameWithMarkers);

        #endregion
    }
}