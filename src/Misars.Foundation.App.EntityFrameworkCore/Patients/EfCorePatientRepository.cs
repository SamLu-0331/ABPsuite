using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Misars.Foundation.App.EntityFrameworkCore;

namespace Misars.Foundation.App.Patients
{
    public abstract class EfCorePatientRepositoryBase : EfCoreRepository<AppDbContext, Patient, Guid>
    {
        public EfCorePatientRepositoryBase(IDbContextProvider<AppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, name, birthdayMin, birthdayMax, phone);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Patient>> GetListAsync(
            string? filterText = null,
            string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, birthdayMin, birthdayMax, phone);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PatientConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, birthdayMin, birthdayMax, phone);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Patient> ApplyFilter(
            IQueryable<Patient> query,
            string? filterText = null,
            string? name = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string? phone = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.name!.Contains(filterText!) || e.phone!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.name.Contains(name))
                    .WhereIf(birthdayMin.HasValue, e => e.birthday >= birthdayMin!.Value)
                    .WhereIf(birthdayMax.HasValue, e => e.birthday <= birthdayMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.phone.Contains(phone));
        }
    }
}