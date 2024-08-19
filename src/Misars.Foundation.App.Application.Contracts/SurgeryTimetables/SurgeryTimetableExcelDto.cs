using System;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableExcelDtoBase
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string? doctorname { get; set; }
        public string? patientname { get; set; }
    }
}