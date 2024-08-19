using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Misars.Foundation.App.Patients;
using Misars.Foundation.App.EntityFrameworkCore;
using Xunit;

namespace Misars.Foundation.App.EntityFrameworkCore.Domains.Patients
{
    public class PatientRepositoryTests : AppEntityFrameworkCoreTestBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientRepositoryTests()
        {
            _patientRepository = GetRequiredService<IPatientRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _patientRepository.GetListAsync(
                    name: "7f0f662de07f4ff9a9159245c47547aed81e6aae1e85491da2d8ee6a6a3369e4041f7b0c0a154e8bb3f159becdf0a14fce03",
                    phone: "ff907b8459b047c18b8be1cbfbba054fb1bf2a23b2034f0d89c4925f332d7762e45b4becb74040f19852a7a976f19d0392ea"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _patientRepository.GetCountAsync(
                    name: "54b1267bc9c348368c81813b8fb24966561a73b11ed347098640b7a5616b6d1fcc5ffb1e675e49c6b9bbab8c5992ee15f274",
                    phone: "dc410a6e9993484f9252254b04992f5b69db39712612487080ce71e1c99d12b2022dc3d2558145869777394b0d170cda328f"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}