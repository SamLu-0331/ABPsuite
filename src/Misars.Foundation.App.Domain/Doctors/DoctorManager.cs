using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorManagerBase : DomainService
    {
        protected IDoctorRepository _doctorRepository;

        public DoctorManagerBase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public virtual async Task<Doctor> CreateAsync(
        string? name = null, string? email = null, string? notes = null)
        {
            Check.Length(name, nameof(name), DoctorConsts.nameMaxLength, DoctorConsts.nameMinLength);
            Check.Length(email, nameof(email), DoctorConsts.emailMaxLength, DoctorConsts.emailMinLength);
            Check.Length(notes, nameof(notes), DoctorConsts.notesMaxLength, DoctorConsts.notesMinLength);

            var doctor = new Doctor(
             GuidGenerator.Create(),
             name, email, notes
             );

            return await _doctorRepository.InsertAsync(doctor);
        }

        public virtual async Task<Doctor> UpdateAsync(
            Guid id,
            string? name = null, string? email = null, string? notes = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.Length(name, nameof(name), DoctorConsts.nameMaxLength, DoctorConsts.nameMinLength);
            Check.Length(email, nameof(email), DoctorConsts.emailMaxLength, DoctorConsts.emailMinLength);
            Check.Length(notes, nameof(notes), DoctorConsts.notesMaxLength, DoctorConsts.notesMinLength);

            var doctor = await _doctorRepository.GetAsync(id);

            doctor.name = name;
            doctor.email = email;
            doctor.notes = notes;

            doctor.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _doctorRepository.UpdateAsync(doctor);
        }

    }
}