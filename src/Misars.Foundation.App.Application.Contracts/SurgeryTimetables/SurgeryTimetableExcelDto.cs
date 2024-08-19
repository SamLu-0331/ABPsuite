using System;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableExcelDtoBase
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string? AnesthesiaType { get; set; }
        public string? notes { get; set; }
    }
}