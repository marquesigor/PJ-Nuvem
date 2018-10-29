using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Model;
using PJNuvem.Infra.Data.Contexts;
using PJNuvem.Infra.Data.Repositories.Base;
using System;

namespace PJNuvem.Infra.Data.Repositories
{
    public class RepositoryComarca : RepositoryBase<Comarca, Guid>, IRepositoryComarca
    {
        protected readonly PJNuvemContext _context;

        public RepositoryComarca(PJNuvemContext context) : base(context)
        {
            _context = context;
        }
    }
}