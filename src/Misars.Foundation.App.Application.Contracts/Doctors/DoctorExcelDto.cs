using System;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorExcelDtoBase
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? notes { get; set; }
    }
}