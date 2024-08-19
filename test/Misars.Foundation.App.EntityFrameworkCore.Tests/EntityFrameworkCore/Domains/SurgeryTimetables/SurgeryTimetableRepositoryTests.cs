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
                    anesthesiaType: "20368bd0c510451788896368a8a01a5b78edaac5d856487d82611b74435b021b6cc418c108954f56ba8f8292a9ec5d894cce",
                    notes: "b9a35cbb72344740b3be69cb8169867fccfba313b37146b8aa0c4d8c3d3ea05b9dbd61e751b14672bbcd0af32050282326aa"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"));
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
                    anesthesiaType: "7ad6db70cb1b4f99b6c038f46e8767010c6ca1dbbaab437da6b6470376d2552e18c3bd12e7af4b9bb67f054830858c07098a",
                    notes: "06274bb652684037a8f81755192a98ad6cdd6e9c3af6478bb095bc4c66671c92274e738c97b6443d8f7ea1aa8d4d4429e9a2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}