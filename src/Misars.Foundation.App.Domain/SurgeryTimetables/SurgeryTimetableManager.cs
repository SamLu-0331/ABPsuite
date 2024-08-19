using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetableManagerBase : DomainService
    {
        protected ISurgeryTimetableRepository _surgeryTimetableRepository;

        public SurgeryTimetableManagerBase(ISurgeryTimetableRepository surgeryTimetableRepository)
        {
            _surgeryTimetableRepository = surgeryTimetableRepository;
        }

        public virtual async Task<SurgeryTimetable> CreateAsync(
        Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? doctorname = null, string? patientname = null)
        {
            Check.NotNull(startdate, nameof(startdate));
            Check.NotNull(enddate, nameof(enddate));
            Check.Length(doctorname, nameof(doctorname), SurgeryTimetableConsts.doctornameMaxLength, SurgeryTimetableConsts.doctornameMinLength);
            Check.Length(patientname, nameof(patientname), SurgeryTimetableConsts.patientnameMaxLength, SurgeryTimetableConsts.patientnameMinLength);

            var surgeryTimetable = new SurgeryTimetable(
             GuidGenerator.Create(),
             doctorId, patientId, startdate, enddate, doctorname, patientname
             );

            return await _surgeryTimetableRepository.InsertAsync(surgeryTimetable);
        }

        public virtual async Task<SurgeryTimetable> UpdateAsync(
            Guid id,
            Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? doctorname = null, string? patientname = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(startdate, nameof(startdate));
            Check.NotNull(enddate, nameof(enddate));
            Check.Length(doctorname, nameof(doctorname), SurgeryTimetableConsts.doctornameMaxLength, SurgeryTimetableConsts.doctornameMinLength);
            Check.Length(patientname, nameof(patientname), SurgeryTimetableConsts.patientnameMaxLength, SurgeryTimetableConsts.patientnameMinLength);

            var surgeryTimetable = await _surgeryTimetableRepository.GetAsync(id);

            surgeryTimetable.DoctorId = doctorId;
            surgeryTimetable.PatientId = patientId;
            surgeryTimetable.startdate = startdate;
            surgeryTimetable.enddate = enddate;
            surgeryTimetable.doctorname = doctorname;
            surgeryTimetable.patientname = patientname;

            surgeryTimetable.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _surgeryTimetableRepository.UpdateAsync(surgeryTimetable);
        }

    }
}