using Misars.Foundation.App.Doctors;
using Volo.Abp.AutoMapper;
using Misars.Foundation.App.Patients;
using AutoMapper;

namespace Misars.Foundation.App.Blazor.Client;

public class AppBlazorAutoMapperProfile : Profile
{
    public AppBlazorAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Blazor project.

        CreateMap<PatientDto, PatientUpdateDto>();

        CreateMap<DoctorDto, DoctorUpdateDto>();
    }
}