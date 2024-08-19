using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? name { get; set; }

        public virtual DateTime birthday { get; set; }

        [CanBeNull]
        public virtual string? phone { get; set; }

        protected PatientBase()
        {

        }

        public PatientBase(Guid id, DateTime birthday, string? name = null, string? phone = null)
        {

            Id = id;
            Check.Length(name, nameof(name), PatientConsts.nameMaxLength, PatientConsts.nameMinLength);
            Check.Length(phone, nameof(phone), PatientConsts.phoneMaxLength, PatientConsts.phoneMinLength);
            this.birthday = birthday;
            this.name = name;
            this.phone = phone;
        }

    }
}