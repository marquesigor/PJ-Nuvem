using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Model;
using PJNuvem.Infra.Data.Contexts;
using PJNuvem.Infra.Data.Repositories.Base;
using System;

namespace PJNuvem.Infra.Data.Repositories
{
    public class RepositoryProcesso : RepositoryBase<Processo, Guid>, IRepositoryProcesso
    {
        protected readonly PJNuvemContext _context;

        public RepositoryProcesso(PJNuvemContext context) : base(context)
        {
            _context = context;
        }
    }
}