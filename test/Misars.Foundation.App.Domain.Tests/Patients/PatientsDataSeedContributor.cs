using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Misars.Foundation.App.Patients;

namespace Misars.Foundation.App.Patients
{
    public class PatientsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PatientsDataSeedContributor(IPatientRepository patientRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _patientRepository = patientRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _patientRepository.InsertAsync(new Patient
            (
                id: Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"),
                name: "7f0f662de07f4ff9a9159245c47547aed81e6aae1e85491da2d8ee6a6a3369e4041f7b0c0a154e8bb3f159becdf0a14fce03",
                birthday: new DateTime(2001, 4, 6),
                phone: "ff907b8459b047c18b8be1cbfbba054fb1bf2a23b2034f0d89c4925f332d7762e45b4becb74040f19852a7a976f19d0392ea"
            ));

            await _patientRepository.InsertAsync(new Patient
            (
                id: Guid.Parse("6d3a0f58-186f-434e-bc5b-f16d91888fad"),
                name: "54b1267bc9c348368c81813b8fb24966561a73b11ed347098640b7a5616b6d1fcc5ffb1e675e49c6b9bbab8c5992ee15f274",
                birthday: new DateTime(2001, 3, 16),
                phone: "dc410a6e9993484f9252254b04992f5b69db39712612487080ce71e1c99d12b2022dc3d2558145869777394b0d170cda328f"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}