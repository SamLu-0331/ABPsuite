namespace Misars.Foundation.App.SurgeryTimetables
{
    public static class SurgeryTimetableConsts
    {
        private const string DefaultSorting = "{0}startdate asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SurgeryTimetable." : string.Empty);
        }

        public const int AnesthesiaTypeMaxLength = 100;
        public const int notesMaxLength = 100;
    }
}