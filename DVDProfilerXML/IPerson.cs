using System;

namespace DoenaSoft.DVDProfiler.DVDProfilerXML
{
    public interface IPerson
    {
        String LastName { get; set; }

        String MiddleName { get; set; }

        String FirstName { get; set; }

        Int32 BirthYear { get; set; }

        String CreditedAs { get; set; }
    }
}