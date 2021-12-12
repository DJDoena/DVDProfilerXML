namespace DoenaSoft.DVDProfiler.DVDProfilerXML
{
    using System;
    using System.ComponentModel;
    using System.Text;

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

                if (string.IsNullOrEmpty(this.FirstName) == false)
                {
                    name.Append(this.FirstName);
                }

                if (string.IsNullOrEmpty(this.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(this.MiddleName);
                }

                if (string.IsNullOrEmpty(this.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append(this.LastName);
                }

                if (this.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + this.BirthYear + ")");
                }

                return name.ToString();
            }
        }

        public string FormattedNameWithMarkers
        {
            get
            {
                var name = new StringBuilder();

                if (string.IsNullOrEmpty(this.FirstName) == false)
                {
                    name.Append("<" + this.FirstName + ">");
                }

                if (string.IsNullOrEmpty(this.MiddleName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("{" + this.MiddleName + "}");
                }

                if (string.IsNullOrEmpty(this.LastName) == false)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("[" + this.LastName + "]");
                }

                if (this.BirthYear != 0)
                {
                    if (name.Length != 0)
                    {
                        name.Append(" ");
                    }

                    name.Append("(" + this.BirthYear + ")");
                }

                return name.ToString();
            }
        }

        public PersonKey(IPerson person)
        {
            this.LastName = person.LastName ?? string.Empty;
            this.MiddleName = person.MiddleName ?? string.Empty;
            this.FirstName = person.FirstName ?? string.Empty;
            this.BirthYear = person.BirthYear;

            _hashCode = this.LastName.ToLowerInvariant().GetHashCode()
                ^ this.FirstName.ToLowerInvariant().GetHashCode()
                ^ this.MiddleName.ToLowerInvariant().GetHashCode()
                ^ this.BirthYear.GetHashCode();
        }

        public override int GetHashCode() => _hashCode;

        public override bool Equals(object obj) => this.Equals(obj as PersonKey);

        public bool Equals(PersonKey other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = string.Equals(this.LastName, other.LastName, StringComparison.InvariantCultureIgnoreCase)
                 && string.Equals(this.MiddleName, other.MiddleName, StringComparison.InvariantCultureIgnoreCase)
                 && string.Equals(this.FirstName, other.FirstName, StringComparison.InvariantCultureIgnoreCase)
                 && this.BirthYear == other.BirthYear;

            return equals;
        }

        public override string ToString() => this.FormattedNameWithMarkers;
    }
}