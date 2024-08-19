using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? name { get; set; }

        [CanBeNull]
        public virtual string? email { get; set; }

        [CanBeNull]
        public virtual string? notes { get; set; }

        protected DoctorBase()
        {

        }

        public DoctorBase(Guid id, string? name = null, string? email = null, string? notes = null)
        {

            Id = id;
            Check.Length(name, nameof(name), DoctorConsts.nameMaxLength, DoctorConsts.nameMinLength);
            Check.Length(email, nameof(email), DoctorConsts.emailMaxLength, DoctorConsts.emailMinLength);
            Check.Length(notes, nameof(notes), DoctorConsts.notesMaxLength, DoctorConsts.notesMinLength);
            this.name = name;
            this.email = email;
            this.notes = notes;
        }

    }
}