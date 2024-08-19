using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Misars.Foundation.App.Doctors;

namespace Misars.Foundation.App.Doctors
{
    public class DoctorsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public DoctorsDataSeedContributor(IDoctorRepository doctorRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _doctorRepository = doctorRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _doctorRepository.InsertAsync(new Doctor
            (
                id: Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"),
                name: "5cce9a120b734b0dbf0709490eb77294cd0da1792c234b03bf92dd705aff5a28c803f646a98b4f97b403d6b114efb9213b20",
                email: "404a292cf3fc41feb4bf6e54d9988651e72d20dc175f4e209ee72a452645d56eee5968431edf4b4caba4a6ebe6c8fa84d91a",
                notes: "f26ced2b4bfd4533853689ec3b52a80e79774f1c770043b69c3e1f326207109cb6a7d0278c8d4716a21fbe2e6bd929d64cf8"
            ));

            await _doctorRepository.InsertAsync(new Doctor
            (
                id: Guid.Parse("eeffcaef-db40-4261-84c1-471b1cad59b5"),
                name: "78f39b9ef6434958890ca1f50c07f87b99b62f4d386c4a38a905b969234e2a84e2d1b319a1184b62bf61fe26fc844e7829af",
                email: "5875d9d45d6c42ceb359de8d9838831c96f8cc62c64d4ed88636b7395a8fd4317f67926dc2c245728eeb8bfab8a9aa9b39ed",
                notes: "cdbb7970b69146a295c4daa1074010b42402daadf28d4e769e71a6893b25ef27deda25a694944b5d97b2af6494dbcac3fd0d"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}