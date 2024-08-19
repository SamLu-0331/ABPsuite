using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorCreateDtoBase
    {
        [StringLength(DoctorConsts.nameMaxLength, MinimumLength = DoctorConsts.nameMinLength)]
        public string? name { get; set; }
        [StringLength(DoctorConsts.emailMaxLength, MinimumLength = DoctorConsts.emailMinLength)]
        public string? email { get; set; }
        [StringLength(DoctorConsts.notesMaxLength, MinimumLength = DoctorConsts.notesMinLength)]
        public string? notes { get; set; }
    }
}