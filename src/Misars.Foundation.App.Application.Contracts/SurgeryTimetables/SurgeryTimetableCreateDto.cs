using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableCreateDtoBase
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        [StringLength(SurgeryTimetableConsts.AnesthesiaTypeMaxLength)]
        public string? AnesthesiaType { get; set; }
        [StringLength(SurgeryTimetableConsts.notesMaxLength)]
        public string? notes { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }
    }
}