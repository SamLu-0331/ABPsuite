using Volo.Abp.Application.Dtos;
using System;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public DateTime? startdateMin { get; set; }
        public DateTime? startdateMax { get; set; }
        public DateTime? enddateMin { get; set; }
        public DateTime? enddateMax { get; set; }
        public string? doctorname { get; set; }
        public string? patientname { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }

        public SurgeryTimetableExcelDownloadDtoBase()
        {

        }
    }
}