using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientCreateDtoBase
    {
        [StringLength(PatientConsts.nameMaxLength, MinimumLength = PatientConsts.nameMinLength)]
        public string? name { get; set; }
        public DateTime birthday { get; set; }
        [StringLength(PatientConsts.phoneMaxLength, MinimumLength = PatientConsts.phoneMinLength)]
        public string? phone { get; set; }
    }
}