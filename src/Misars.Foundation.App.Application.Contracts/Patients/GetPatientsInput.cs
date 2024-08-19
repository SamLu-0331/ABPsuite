using Volo.Abp.Application.Dtos;
using System;

namespace Misars.Foundation.App.Patients
{
    public abstract class GetPatientsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? name { get; set; }
        public DateTime? birthdayMin { get; set; }
        public DateTime? birthdayMax { get; set; }
        public string? phone { get; set; }

        public GetPatientsInputBase()
        {

        }
    }
}