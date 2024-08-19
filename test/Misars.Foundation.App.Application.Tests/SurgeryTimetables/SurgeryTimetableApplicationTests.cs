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
            result.Items.Any(x => x.SurgeryTimetable.Id == Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01")).ShouldBe(true);
            result.Items.Any(x => x.SurgeryTimetable.Id == Guid.Parse("e3fe42a8-ec98-4bb6-9139-e0901e080c05")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _surgeryTimetablesAppService.GetAsync(Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SurgeryTimetableCreateDto
            {
                startdate = new DateTime(2010, 11, 22),
                enddate = new DateTime(2003, 1, 15),
                AnesthesiaType = "e4da83855d6e46f7b221cce43677bf39fbb5a3e9d2e842c0943f8758903b6c0407db2da3d1be4bc3b953178f4fa0d9691a21",
                notes = "50e5bb6e72f545758a23a9d8cb64ab364780e594b85a4ce4983010370496bb773c11048c972f42d6aa7f543726d6d661e6fb"
            };

            // Act
            var serviceResult = await _surgeryTimetablesAppService.CreateAsync(input);

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.startdate.ShouldBe(new DateTime(2010, 11, 22));
            result.enddate.ShouldBe(new DateTime(2003, 1, 15));
            result.AnesthesiaType.ShouldBe("e4da83855d6e46f7b221cce43677bf39fbb5a3e9d2e842c0943f8758903b6c0407db2da3d1be4bc3b953178f4fa0d9691a21");
            result.notes.ShouldBe("50e5bb6e72f545758a23a9d8cb64ab364780e594b85a4ce4983010370496bb773c11048c972f42d6aa7f543726d6d661e6fb");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SurgeryTimetableUpdateDto()
            {
                startdate = new DateTime(2007, 1, 5),
                enddate = new DateTime(2008, 5, 19),
                AnesthesiaType = "0d5113c9ba894f09b3bf2c59eef814937ddd729044324b8793cd0255171bc3e0fe6e6a0d491e4550b7b3a1fe92d61132fdbf",
                notes = "bacdbe26dc5d433aae6f9135b2b3ab3b20626503ae804c01969b00385856bae0a2d80542ad9844d4a87d0e029557f58293b0"
            };

            // Act
            var serviceResult = await _surgeryTimetablesAppService.UpdateAsync(Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"), input);

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.startdate.ShouldBe(new DateTime(2007, 1, 5));
            result.enddate.ShouldBe(new DateTime(2008, 5, 19));
            result.AnesthesiaType.ShouldBe("0d5113c9ba894f09b3bf2c59eef814937ddd729044324b8793cd0255171bc3e0fe6e6a0d491e4550b7b3a1fe92d61132fdbf");
            result.notes.ShouldBe("bacdbe26dc5d433aae6f9135b2b3ab3b20626503ae804c01969b00385856bae0a2d80542ad9844d4a87d0e029557f58293b0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _surgeryTimetablesAppService.DeleteAsync(Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"));

            // Assert
            var result = await _surgeryTimetableRepository.FindAsync(c => c.Id == Guid.Parse("5db65882-50eb-4b20-8dab-8ebfe0941f01"));

            result.ShouldBeNull();
        }
    }
}