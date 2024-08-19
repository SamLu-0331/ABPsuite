using Misars.Foundation.App.Doctors;
using System;
using Misars.Foundation.App.Shared;
using Volo.Abp.AutoMapper;
using Misars.Foundation.App.Patients;
using AutoMapper;

namespace Misars.Foundation.App;

public class AppApplicationAutoMapperProfile : Profile
{
    public AppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Patient, PatientDto>();
        CreateMap<Patient, PatientExcelDto>();

        CreateMap<Doctor, DoctorDto>();
        CreateMap<Doctor, DoctorExcelDto>();
    }
}