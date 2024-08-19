using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Misars.Foundation.App.Patients
{
    public abstract class PatientsAppServiceTests<TStartupModule> : AppApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IPatientsAppService _patientsAppService;
        private readonly IRepository<Patient, Guid> _patientRepository;

        public PatientsAppServiceTests()
        {
            _patientsAppService = GetRequiredService<IPatientsAppService>();
            _patientRepository = GetRequiredService<IRepository<Patient, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _patientsAppService.GetListAsync(new GetPatientsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6d3a0f58-186f-434e-bc5b-f16d91888fad")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _patientsAppService.GetAsync(Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PatientCreateDto
            {
                name = "5bece5ce592a4c6995ce9d8a52bc55e72f0ff5b9a152486d8a3264705d2f53e347d565b0d56e4cb0b35929aa7dce2ecceb55",
                birthday = new DateTime(2003, 11, 4),
                phone = "d0e341ade0f441e39f2948d0984eb1350161ff07222a4e4289a09906e0739e92b0d717413408423da9e0cc55528aa5635a31"
            };

            // Act
            var serviceResult = await _patientsAppService.CreateAsync(input);

            // Assert
            var result = await _patientRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("5bece5ce592a4c6995ce9d8a52bc55e72f0ff5b9a152486d8a3264705d2f53e347d565b0d56e4cb0b35929aa7dce2ecceb55");
            result.birthday.ShouldBe(new DateTime(2003, 11, 4));
            result.phone.ShouldBe("d0e341ade0f441e39f2948d0984eb1350161ff07222a4e4289a09906e0739e92b0d717413408423da9e0cc55528aa5635a31");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PatientUpdateDto()
            {
                name = "ec992dda9a4a4048ba6a3c27475b21c7d82173da4f434660967daf3283f1516a863044c2fac74fd9ac790e15ff20d10997b4",
                birthday = new DateTime(2022, 9, 21),
                phone = "27911471b0834f63b3c4c19271b9e4ce53dd5c42005143c78a67a117a006d303d8fe7967748742b9b5c05282d3937eb4aab4"
            };

            // Act
            var serviceResult = await _patientsAppService.UpdateAsync(Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"), input);

            // Assert
            var result = await _patientRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("ec992dda9a4a4048ba6a3c27475b21c7d82173da4f434660967daf3283f1516a863044c2fac74fd9ac790e15ff20d10997b4");
            result.birthday.ShouldBe(new DateTime(2022, 9, 21));
            result.phone.ShouldBe("27911471b0834f63b3c4c19271b9e4ce53dd5c42005143c78a67a117a006d303d8fe7967748742b9b5c05282d3937eb4aab4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _patientsAppService.DeleteAsync(Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"));

            // Assert
            var result = await _patientRepository.FindAsync(c => c.Id == Guid.Parse("51f07d8f-ec8f-43e2-b2f9-61fce6522ac5"));

            result.ShouldBeNull();
        }
    }
}