using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? notes { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}