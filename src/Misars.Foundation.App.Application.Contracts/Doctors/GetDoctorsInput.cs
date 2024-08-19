using Volo.Abp.Application.Dtos;
using System;

namespace Misars.Foundation.App.Doctors
{
    public abstract class GetDoctorsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public string? notes { get; set; }

        public GetDoctorsInputBase()
        {

        }
    }
}