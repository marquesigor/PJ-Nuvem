using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Model;
using PJNuvem.Infra.Data.Contexts;
using PJNuvem.Infra.Data.Repositories.Base;
using System;

namespace PJNuvem.Infra.Data.Repositories
{
    public class RepositoryVara : RepositoryBase<Vara, Guid>, IRepositoryVara
    {
        protected readonly PJNuvemContext _context;

        public RepositoryVara(PJNuvemContext context) : base(context)
        {
            _context = context;
        }
    }
}
