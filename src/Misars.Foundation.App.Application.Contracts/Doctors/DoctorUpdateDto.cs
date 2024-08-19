using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorUpdateDtoBase : IHasConcurrencyStamp
    {
        [StringLength(DoctorConsts.nameMaxLength, MinimumLength = DoctorConsts.nameMinLength)]
        public string? name { get; set; }
        [StringLength(DoctorConsts.emailMaxLength, MinimumLength = DoctorConsts.emailMinLength)]
        public string? email { get; set; }
        [StringLength(DoctorConsts.notesMaxLength, MinimumLength = DoctorConsts.notesMinLength)]
        public string? notes { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}