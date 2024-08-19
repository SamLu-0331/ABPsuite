namespace Misars.Foundation.App.Doctors
{
    public static class DoctorConsts
    {
        private const string DefaultSorting = "{0}name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Doctor." : string.Empty);
        }

        public const int nameMinLength = 0;
        public const int nameMaxLength = 100;
        public const int emailMinLength = 0;
        public const int emailMaxLength = 100;
        public const int notesMinLength = 0;
        public const int notesMaxLength = 100;
    }
}