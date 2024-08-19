using System;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientExcelDtoBase
    {
        public string? name { get; set; }
        public DateTime birthday { get; set; }
        public string? phone { get; set; }
    }
}