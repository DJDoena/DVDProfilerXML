namespace DoenaSoft.DVDProfiler.DVDProfilerXML
{
    public interface IPerson
    {
        string LastName { get; set; }

        string MiddleName { get; set; }

        string FirstName { get; set; }

        int BirthYear { get; set; }

        string CreditedAs { get; set; }
    }
}