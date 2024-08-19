namespace Misars.Foundation.App.SurgeryTimetables
{
    public static class SurgeryTimetableConsts
    {
        private const string DefaultSorting = "{0}startdate asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SurgeryTimetable." : string.Empty);
        }

        public const int doctornameMinLength = 0;
        public const int doctornameMaxLength = 100;
        public const int patientnameMinLength = 0;
        public const int patientnameMaxLength = 100;
    }
}