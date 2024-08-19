using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Misars.Foundation.App.SurgeryTimetables;
using Misars.Foundation.App.EntityFrameworkCore;
using Xunit;

namespace Misars.Foundation.App.EntityFrameworkCore.Domains.SurgeryTimetables
{
    public class SurgeryTimetableRepositoryTests : AppEntityFrameworkCoreTestBase
    {
        private readonly ISurgeryTimetableRepository _surgeryTimetableRepository;

        public SurgeryTimetableRepositoryTests()
        {
            _surgeryTimetableRepository = GetRequiredService<ISurgeryTimetableRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _surgeryTimetableRepository.GetListAsync(
                    doctorname: "daa1ca0ccb36441a81b001f062d102c32d13dd31939142d2af617ad10f9bd5583f40ca6a9fa94c8893d7ed50531253e07e6e",
                    patientname: "f2006bbf7616481aa37ae04ea4ddcbcee75b42af0b2a4cb0a2ded21038c984a7f0303d57193d45e9ac40e7e53f03eb47bb83"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _surgeryTimetableRepository.GetCountAsync(
                    doctorname: "6d15efd2516c4b199c44e4ddd87c386776a90bbf654e4c95b7785e2b5e15717b3e11736223224a148484778deced97141b50",
                    patientname: "6553566f854748709a593208f38a9550ac2b599eed874315b703f1d614c5cd16d8cf6c3f637c4d0e8a437419d1c429211a58"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}