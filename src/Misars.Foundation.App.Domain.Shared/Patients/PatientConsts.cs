namespace Misars.Foundation.App.Patients
{
    public static class PatientConsts
    {
        private const string DefaultSorting = "{0}name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Patient." : string.Empty);
        }

        public const int nameMinLength = 0;
        public const int nameMaxLength = 100;
        public const int phoneMinLength = 0;
        public const int phoneMaxLength = 100;
    }
}