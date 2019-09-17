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

            public string LastName { get; set; }

            public string MiddleName { get; set; }

            public string FirstName { get; set; }

            public int BirthYear { get; set; }

            public string CreditedAs { get; set; }

            #endregion

            internal Person(IPerson person)
            {
                LastName = string.IsNullOrEmpty(person.LastName) == false
                    ? person.LastName
                    : string.Empty;

                MiddleName = string.IsNullOrEmpty(person.MiddleName) == false
                    ? person.MiddleName
                    : string.Empty;

                FirstName = string.IsNullOrEmpty(person.FirstName) == false
                    ? person.FirstName
                    : string.Empty;

                BirthYear = person.BirthYear;

                CreditedAs = string.IsNullOrEmpty(person.CreditedAs) == false
                    ? person.CreditedAs
                    : string.Empty;
            }
        }

        #endregion

        #region Fields

        private readonly Person _keyData;

        private readonly int _hashCode;

        #endregion

        #region Properties

        public IPerson KeyData => new Person(_keyData);

        public string FormattedName
        {
            get
            {
                var name = new StringBuilder();

                if (string.IsNullOrEmpty(_keyData.FirstName) == false)
                {
                    name.Append(_keyData.FirstName);
                }

                if (string.IsNullOrEmpty(_keyData.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(_keyData.MiddleName);
                }

                if (string.IsNullOrEmpty(_keyData.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(_keyData.LastName);
                }

                if (_keyData.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + _keyData.BirthYear + ")");
                }

                return name.ToString();
            }
        }

        public string FormattedNameWithMarkers
        {
            get
            {
                var name = new StringBuilder();

                if (string.IsNullOrEmpty(_keyData.FirstName) == false)
                {
                    name.Append("<" + _keyData.FirstName + ">");
                }

                if (string.IsNullOrEmpty(_keyData.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("{" + _keyData.MiddleName + "}");
                }

                if (string.IsNullOrEmpty(_keyData.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("[" + _keyData.LastName + "]");
                }

                if (_keyData.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + _keyData.BirthYear + ")");
                }

                return name.ToString();
            }
        }

        #endregion

        #region Constructor

        public PersonKey(IPerson person)
        {
            _keyData = new Person(person);

            _hashCode = GetHashCode(_keyData.LastName) ^ GetHashCode(_keyData.FirstName) ^ GetHashCode(_keyData.MiddleName) ^ _keyData.BirthYear.GetHashCode();
        }

        #endregion

        #region Methods

        public override int GetHashCode() => _hashCode;

        public override bool Equals(object obj)
        {
            if (!(obj is PersonKey other))
            {
                return false;
            }
            else
            {
                var result = string.Equals(_keyData.LastName, other._keyData.LastName, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(_keyData.MiddleName, other._keyData.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(_keyData.FirstName, other._keyData.FirstName, StringComparison.InvariantCultureIgnoreCase)
                    && _keyData.BirthYear == other._keyData.BirthYear;

                return result;
            }
        }

        public override string ToString() => FormattedNameWithMarkers;

        #endregion

        private static int GetHashCode(string namePart)
        {
            var result = (namePart ?? string.Empty).ToLowerInvariant().GetHashCode();

            return result;
        }
    }
}