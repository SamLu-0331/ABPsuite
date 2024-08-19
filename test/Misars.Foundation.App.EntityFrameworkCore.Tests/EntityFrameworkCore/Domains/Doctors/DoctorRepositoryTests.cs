using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Misars.Foundation.App.Doctors;
using Misars.Foundation.App.EntityFrameworkCore;
using Xunit;

namespace Misars.Foundation.App.EntityFrameworkCore.Domains.Doctors
{
    public class DoctorRepositoryTests : AppEntityFrameworkCoreTestBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorRepositoryTests()
        {
            _doctorRepository = GetRequiredService<IDoctorRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _doctorRepository.GetListAsync(
                    name: "5cce9a120b734b0dbf0709490eb77294cd0da1792c234b03bf92dd705aff5a28c803f646a98b4f97b403d6b114efb9213b20",
                    email: "404a292cf3fc41feb4bf6e54d9988651e72d20dc175f4e209ee72a452645d56eee5968431edf4b4caba4a6ebe6c8fa84d91a",
                    notes: "f26ced2b4bfd4533853689ec3b52a80e79774f1c770043b69c3e1f326207109cb6a7d0278c8d4716a21fbe2e6bd929d64cf8"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _doctorRepository.GetCountAsync(
                    name: "78f39b9ef6434958890ca1f50c07f87b99b62f4d386c4a38a905b969234e2a84e2d1b319a1184b62bf61fe26fc844e7829af",
                    email: "5875d9d45d6c42ceb359de8d9838831c96f8cc62c64d4ed88636b7395a8fd4317f67926dc2c245728eeb8bfab8a9aa9b39ed",
                    notes: "cdbb7970b69146a295c4daa1074010b42402daadf28d4e769e71a6893b25ef27deda25a694944b5d97b2af6494dbcac3fd0d"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}