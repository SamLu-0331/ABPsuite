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
        Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? anesthesiaType = null, string? notes = null)
        {
            Check.NotNull(startdate, nameof(startdate));
            Check.NotNull(enddate, nameof(enddate));
            Check.Length(anesthesiaType, nameof(anesthesiaType), SurgeryTimetableConsts.AnesthesiaTypeMaxLength);
            Check.Length(notes, nameof(notes), SurgeryTimetableConsts.notesMaxLength);

            var surgeryTimetable = new SurgeryTimetable(
             GuidGenerator.Create(),
             doctorId, patientId, startdate, enddate, anesthesiaType, notes
             );

            return await _surgeryTimetableRepository.InsertAsync(surgeryTimetable);
        }

        public virtual async Task<SurgeryTimetable> UpdateAsync(
            Guid id,
            Guid? doctorId, Guid? patientId, DateTime startdate, DateTime enddate, string? anesthesiaType = null, string? notes = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(startdate, nameof(startdate));
            Check.NotNull(enddate, nameof(enddate));
            Check.Length(anesthesiaType, nameof(anesthesiaType), SurgeryTimetableConsts.AnesthesiaTypeMaxLength);
            Check.Length(notes, nameof(notes), SurgeryTimetableConsts.notesMaxLength);

            var surgeryTimetable = await _surgeryTimetableRepository.GetAsync(id);

            surgeryTimetable.DoctorId = doctorId;
            surgeryTimetable.PatientId = patientId;
            surgeryTimetable.startdate = startdate;
            surgeryTimetable.enddate = enddate;
            surgeryTimetable.AnesthesiaType = anesthesiaType;
            surgeryTimetable.notes = notes;

            surgeryTimetable.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _surgeryTimetableRepository.UpdateAsync(surgeryTimetable);
        }

    }
}