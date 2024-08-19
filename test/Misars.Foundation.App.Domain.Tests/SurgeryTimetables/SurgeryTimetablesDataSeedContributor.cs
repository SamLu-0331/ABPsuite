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
                id: Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"),
                startdate: new DateTime(2022, 5, 13),
                enddate: new DateTime(2005, 6, 15),
                doctorname: "daa1ca0ccb36441a81b001f062d102c32d13dd31939142d2af617ad10f9bd5583f40ca6a9fa94c8893d7ed50531253e07e6e",
                patientname: "f2006bbf7616481aa37ae04ea4ddcbcee75b42af0b2a4cb0a2ded21038c984a7f0303d57193d45e9ac40e7e53f03eb47bb83",
                doctorId: null,
                patientId: null
            ));

            await _surgeryTimetableRepository.InsertAsync(new SurgeryTimetable
            (
                id: Guid.Parse("708b2265-ddda-407f-9d8c-cfe38a86ddb7"),
                startdate: new DateTime(2011, 10, 10),
                enddate: new DateTime(2017, 1, 13),
                doctorname: "6d15efd2516c4b199c44e4ddd87c386776a90bbf654e4c95b7785e2b5e15717b3e11736223224a148484778deced97141b50",
                patientname: "6553566f854748709a593208f38a9550ac2b599eed874315b703f1d614c5cd16d8cf6c3f637c4d0e8a437419d1c429211a58",
                doctorId: null,
                patientId: null
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}