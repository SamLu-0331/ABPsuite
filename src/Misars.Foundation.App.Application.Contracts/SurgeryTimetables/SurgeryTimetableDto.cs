using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string? AnesthesiaType { get; set; }
        public string? notes { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}