using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? name { get; set; }
        public DateTime birthday { get; set; }
        public string? phone { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}