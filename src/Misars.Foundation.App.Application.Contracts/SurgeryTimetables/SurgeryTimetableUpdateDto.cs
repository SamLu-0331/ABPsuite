using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableUpdateDtoBase : IHasConcurrencyStamp
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        [StringLength(SurgeryTimetableConsts.doctornameMaxLength, MinimumLength = SurgeryTimetableConsts.doctornameMinLength)]
        public string? doctorname { get; set; }
        [StringLength(SurgeryTimetableConsts.patientnameMaxLength, MinimumLength = SurgeryTimetableConsts.patientnameMinLength)]
        public string? patientname { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}