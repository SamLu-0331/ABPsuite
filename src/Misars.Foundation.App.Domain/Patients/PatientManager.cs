using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientManagerBase : DomainService
    {
        protected IPatientRepository _patientRepository;

        public PatientManagerBase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public virtual async Task<Patient> CreateAsync(
        DateTime birthday, string? name = null, string? phone = null)
        {
            Check.NotNull(birthday, nameof(birthday));
            Check.Length(name, nameof(name), PatientConsts.nameMaxLength, PatientConsts.nameMinLength);
            Check.Length(phone, nameof(phone), PatientConsts.phoneMaxLength, PatientConsts.phoneMinLength);

            var patient = new Patient(
             GuidGenerator.Create(),
             birthday, name, phone
             );

            return await _patientRepository.InsertAsync(patient);
        }

        public virtual async Task<Patient> UpdateAsync(
            Guid id,
            DateTime birthday, string? name = null, string? phone = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(birthday, nameof(birthday));
            Check.Length(name, nameof(name), PatientConsts.nameMaxLength, PatientConsts.nameMinLength);
            Check.Length(phone, nameof(phone), PatientConsts.phoneMaxLength, PatientConsts.phoneMinLength);

            var patient = await _patientRepository.GetAsync(id);

            patient.birthday = birthday;
            patient.name = name;
            patient.phone = phone;

            patient.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _patientRepository.UpdateAsync(patient);
        }

    }
}