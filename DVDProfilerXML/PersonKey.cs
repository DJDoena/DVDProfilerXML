using System;
using System.ComponentModel;
using System.Text;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML
{
    /// <summary>
    /// This object can be used as key in hashtables and dictionaries.
    /// </summary>
    [ImmutableObject(true)]
    public sealed class PersonKey : IEquatable<PersonKey>
    {
        private readonly int _hashCode;

        public string LastName { get; }

        public string MiddleName { get; }

        public string FirstName { get; }

        public int BirthYear { get; }

        public string FormattedName
        {
            get
            {
                var name = new StringBuilder();

                if (string.IsNullOrEmpty(FirstName) == false)
                {
                    name.Append(FirstName);
                }

                if (string.IsNullOrEmpty(MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(MiddleName);
                }

                if (string.IsNullOrEmpty(LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(LastName);
                }

                if (BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + BirthYear + ")");
                }

                return name.ToString();
            }
        }

        public string FormattedNameWithMarkers
        {
            get
            {
                var name = new StringBuilder();

                if (string.IsNullOrEmpty(FirstName) == false)
                {
                    name.Append("<" + FirstName + ">");
                }

                if (string.IsNullOrEmpty(MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("{" + MiddleName + "}");
                }

                if (string.IsNullOrEmpty(LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("[" + LastName + "]");
                }

                if (BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + BirthYear + ")");
                }

                return name.ToString();
            }
        }

        public PersonKey(IPerson person)
        {
            LastName = person.LastName ?? string.Empty;
            MiddleName = person.MiddleName ?? string.Empty;
            FirstName = person.FirstName ?? string.Empty;
            BirthYear = person.BirthYear;

            _hashCode = LastName.ToLowerInvariant().GetHashCode()
                ^ FirstName.ToLowerInvariant().GetHashCode()
                ^ MiddleName.ToLowerInvariant().GetHashCode()
                ^ BirthYear.GetHashCode();
        }

        public override int GetHashCode() => _hashCode;

        public override bool Equals(object obj) => Equals(obj as PersonKey);

        public bool Equals(PersonKey other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = string.Equals(LastName, other.LastName, StringComparison.InvariantCultureIgnoreCase)
                 && string.Equals(MiddleName, other.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                 && string.Equals(FirstName, other.FirstName, StringComparison.InvariantCultureIgnoreCase)
                 && BirthYear == other.BirthYear;

            return equals;
        }

        public override string ToString() => FormattedNameWithMarkers;
    }
}