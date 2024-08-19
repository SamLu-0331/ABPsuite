using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Misars.Foundation.App.Patients
{
    public partial interface IPatientRepository : IRepository<Patient, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null,
            CancellationToken cancellationToken = default);
        Task<List<Patient>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    DateTime? birthdayMin = null,
                    DateTime? birthdayMax = null,
                    string? phone = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null,
            CancellationToken cancellationToken = default);
    }
}