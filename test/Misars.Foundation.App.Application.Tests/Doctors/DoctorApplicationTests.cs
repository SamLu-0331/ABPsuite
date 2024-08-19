using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Misars.Foundation.App.Doctors
{
    public abstract class DoctorsAppServiceTests<TStartupModule> : AppApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IDoctorsAppService _doctorsAppService;
        private readonly IRepository<Doctor, Guid> _doctorRepository;

        public DoctorsAppServiceTests()
        {
            _doctorsAppService = GetRequiredService<IDoctorsAppService>();
            _doctorRepository = GetRequiredService<IRepository<Doctor, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _doctorsAppService.GetListAsync(new GetDoctorsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("eeffcaef-db40-4261-84c1-471b1cad59b5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _doctorsAppService.GetAsync(Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new DoctorCreateDto
            {
                name = "9f8f323b41434befb96d5f84c3c4ccfe1227d9bd38d140dfafb2cb49aa67309558fec0b7caed4d03bd8deef4c48379358e22",
                email = "2be40c246c824f7f90e7ce59436d781a3df0d55575c14871962e6f1864df5675ec1f2e802f524c6a97758e93539bd11a3a21",
                notes = "cbbd57ecfe564501814eeb0cf564527b49028bd9dd24485fae12ddf9fc6bff5f9b85541b7dfb49f9aa3840c0c5e08d567256"
            };

            // Act
            var serviceResult = await _doctorsAppService.CreateAsync(input);

            // Assert
            var result = await _doctorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("9f8f323b41434befb96d5f84c3c4ccfe1227d9bd38d140dfafb2cb49aa67309558fec0b7caed4d03bd8deef4c48379358e22");
            result.email.ShouldBe("2be40c246c824f7f90e7ce59436d781a3df0d55575c14871962e6f1864df5675ec1f2e802f524c6a97758e93539bd11a3a21");
            result.notes.ShouldBe("cbbd57ecfe564501814eeb0cf564527b49028bd9dd24485fae12ddf9fc6bff5f9b85541b7dfb49f9aa3840c0c5e08d567256");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new DoctorUpdateDto()
            {
                name = "5fbe81db7d3c4abab6485704e38f469f4cd50797d309433d8faf176d2af67294f841f7ab3e6b443f9e5df5e4b146a711425e",
                email = "436e2885ea8741eda229ab959c64c4014afbe6513f9a47de9b1963fc971340380105203cfde84cae8a48b124b0806bda1ff7",
                notes = "f0dc72f0d7764bb7b555116a8cb8a22a7765577f50604cfebfc898ada0cb27bf29a804f489be43528a563b65a86da895ad88"
            };

            // Act
            var serviceResult = await _doctorsAppService.UpdateAsync(Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"), input);

            // Assert
            var result = await _doctorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("5fbe81db7d3c4abab6485704e38f469f4cd50797d309433d8faf176d2af67294f841f7ab3e6b443f9e5df5e4b146a711425e");
            result.email.ShouldBe("436e2885ea8741eda229ab959c64c4014afbe6513f9a47de9b1963fc971340380105203cfde84cae8a48b124b0806bda1ff7");
            result.notes.ShouldBe("f0dc72f0d7764bb7b555116a8cb8a22a7765577f50604cfebfc898ada0cb27bf29a804f489be43528a563b65a86da895ad88");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _doctorsAppService.DeleteAsync(Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"));

            // Assert
            var result = await _doctorRepository.FindAsync(c => c.Id == Guid.Parse("58087dcb-7e6a-4126-983f-a506dad4105b"));

            result.ShouldBeNull();
        }
    }
}