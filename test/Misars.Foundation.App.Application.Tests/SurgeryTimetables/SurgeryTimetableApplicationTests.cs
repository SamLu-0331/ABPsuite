using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Misars.Foundation.App.SurgeryTimetables
{
    public abstract class SurgeryTimetablesAppServiceTests<TStartupModule> : AppApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ISurgeryTimetablesAppService _surgeryTimetablesAppService;
        private readonly IRepository<SurgeryTimetable, Guid> _surgeryTimetableRepository;

        public SurgeryTimetablesAppServiceTests()
        {
            _surgeryTimetablesAppService = GetRequiredService<ISurgeryTimetablesAppService>();
            _surgeryTimetableRepository = GetRequiredService<IRepository<SurgeryTimetable, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _surgeryTimetablesAppService.GetListAsync(new GetSurgeryTimetablesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.SurgeryTimetable.Id == Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc")).ShouldBe(true);
            result.Items.Any(x => x.SurgeryTimetable.Id == Guid.Parse("708b2265-ddda-407f-9d8c-cfe38a86ddb7")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _surgeryTimetablesAppService.GetAsync(Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SurgeryTimetableCreateDto
            {
                startdate = new DateTime(2012, 11, 1),
                enddate = new DateTime(2022, 11, 18),
                doctorname = "21f416631d50443eadeadab234cff18838265047bf0c485fb94b30f84690c82f800b9fb426fa489baf999d45d4f140a4e390",
                patientname = "391c9bec85664ce694c7fa33364af74197fdd5da091c47c5937fa096657ecd5919c1c8ffe86f46d1baea7ea77dc5b583ecae"
            };

            // Act
            var serviceResult = await _surgeryTimetablesAppService.CreateAsync(input);

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.startdate.ShouldBe(new DateTime(2012, 11, 1));
            result.enddate.ShouldBe(new DateTime(2022, 11, 18));
            result.doctorname.ShouldBe("21f416631d50443eadeadab234cff18838265047bf0c485fb94b30f84690c82f800b9fb426fa489baf999d45d4f140a4e390");
            result.patientname.ShouldBe("391c9bec85664ce694c7fa33364af74197fdd5da091c47c5937fa096657ecd5919c1c8ffe86f46d1baea7ea77dc5b583ecae");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SurgeryTimetableUpdateDto()
            {
                startdate = new DateTime(2007, 11, 22),
                enddate = new DateTime(2009, 8, 1),
                doctorname = "527aded29f9c44fdac2317e0c75734779b05b6d4537c4905aa9d477166c0102c744e491dfeac466ea95e60c52cefd2d35901",
                patientname = "f34ac9ff3c8f4e86b64742e8721be5c67dcbfe1f032944a19ca02234cc2ace4c8b850d1f610949348abac0d3d101ddda68c9"
            };

            // Act
            var serviceResult = await _surgeryTimetablesAppService.UpdateAsync(Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"), input);

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.startdate.ShouldBe(new DateTime(2007, 11, 22));
            result.enddate.ShouldBe(new DateTime(2009, 8, 1));
            result.doctorname.ShouldBe("527aded29f9c44fdac2317e0c75734779b05b6d4537c4905aa9d477166c0102c744e491dfeac466ea95e60c52cefd2d35901");
            result.patientname.ShouldBe("f34ac9ff3c8f4e86b64742e8721be5c67dcbfe1f032944a19ca02234cc2ace4c8b850d1f610949348abac0d3d101ddda68c9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _surgeryTimetablesAppService.DeleteAsync(Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"));

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == Guid.Parse("26db1a48-1ead-473a-a4a8-6b990127c0fc"));

            result.ShouldBeNull();
        }
    }
}