using Misars.Foundation.App.Doctors;
using Misars.Foundation.App.Patients;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableBase : FullAuditedAggregateRoot<Guid>
    {
        public virtual DateTime startdate { get; set; }

        public virtual DateTime enddate { get; set; }

        [CanBeNull]
        public virtual string? AnesthesiaType { get; set; }

        [CanBeNull]
        public virtual string? notes { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }

        protected SurgeryTimetableBase()
        {

        }

        public SurgeryTimetableBase(Guid id, Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? anesthesiaType = null, string? notes = null)
        {

            Id = id;
            Check.Length(anesthesiaType, nameof(anesthesiaType), SurgeryTimetableConsts.AnesthesiaTypeMaxLength, 0);
            Check.Length(notes, nameof(notes), SurgeryTimetableConsts.notesMaxLength, 0);
            this.startdate = startdate;
            this.enddate = enddate;
            AnesthesiaType = anesthesiaType;
            this.notes = notes;
            DoctorId = doctorId;
            PatientId = patientId;
        }

    }
}