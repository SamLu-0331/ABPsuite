using Misars.Foundation.App.Patients;
using Misars.Foundation.App.Doctors;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Misars.Foundation.App.SurgeryTimetables;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public class SurgeryTimetablesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISurgeryTimetableRepository _surgeryTimetableRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly DoctorsDataSeedContributor _doctorsDataSeedContributor;

        private readonly PatientsDataSeedContributor _patientsDataSeedContributor;

        public SurgeryTimetablesDataSeedContributor(ISurgeryTimetableRepository surgeryTimetableRepository, IUnitOfWorkManager unitOfWorkManager, DoctorsDataSeedContributor doctorsDataSeedContributor, PatientsDataSeedContributor patientsDataSeedContributor)
        {
            _surgeryTimetableRepository = surgeryTimetableRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _doctorsDataSeedContributor = doctorsDataSeedContributor; _patientsDataSeedContributor = patientsDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _doctorsDataSeedContributor.SeedAsync(context);
            await _patientsDataSeedContributor.SeedAsync(context);

            await _surgeryTimetableRepository.InsertAsync(new SurgeryTimetable
            (
                id: Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"),
                startdate: new DateTime(2009, 3, 5),
                enddate: new DateTime(2021, 11, 18),
                anesthesiaType: "20368bd0c510451788896368a8a01a5b78edaac5d856487d82611b74435b021b6cc418c108954f56ba8f8292a9ec5d894cce",
                notes: "b9a35cbb72344740b3be69cb8169867fccfba313b37146b8aa0c4d8c3d3ea05b9dbd61e751b14672bbcd0af32050282326aa",
                doctorId: null,
                patientId: null
            ));

            await _surgeryTimetableRepository.InsertAsync(new SurgeryTimetable
            (
                id: Guid.Parse("e3fe42a8-ec98-4bb6-9139-e0901e080c05"),
                startdate: new DateTime(2019, 6, 26),
                enddate: new DateTime(2001, 5, 12),
                anesthesiaType: "7ad6db70cb1b4f99b6c038f46e8767010c6ca1dbbaab437da6b6470376d2552e18c3bd12e7af4b9bb67f054830858c07098a",
                notes: "06274bb652684037a8f81755192a98ad6cdd6e9c3af6478bb095bc4c66671c92274e738c97b6443d8f7ea1aa8d4d4429e9a2",
                doctorId: null,
                patientId: null
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}