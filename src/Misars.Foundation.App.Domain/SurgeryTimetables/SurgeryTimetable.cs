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
        public virtual string? doctorname { get; set; }

        [CanBeNull]
        public virtual string? patientname { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }

        protected SurgeryTimetableBase()
        {

        }

        public SurgeryTimetableBase(Guid id, Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? doctorname = null, string? patientname = null)
        {

            Id = id;
            Check.Length(doctorname, nameof(doctorname), SurgeryTimetableConsts.doctornameMaxLength, SurgeryTimetableConsts.doctornameMinLength);
            Check.Length(patientname, nameof(patientname), SurgeryTimetableConsts.patientnameMaxLength, SurgeryTimetableConsts.patientnameMinLength);
            this.startdate = startdate;
            this.enddate = enddate;
            this.doctorname = doctorname;
            this.patientname = patientname;
            DoctorId = doctorId;
            PatientId = patientId;
        }

    }
}