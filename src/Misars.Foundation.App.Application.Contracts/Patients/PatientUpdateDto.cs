using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientUpdateDtoBase : IHasConcurrencyStamp
    {
        [StringLength(PatientConsts.nameMaxLength, MinimumLength = PatientConsts.nameMinLength)]
        public string? name { get; set; }
        public DateTime birthday { get; set; }
        [StringLength(PatientConsts.phoneMaxLength, MinimumLength = PatientConsts.phoneMinLength)]
        public string? phone { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}