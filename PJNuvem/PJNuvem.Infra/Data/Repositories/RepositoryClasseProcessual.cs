using PJNuvem.Domain.Interfaces.Repositories;
using PJNuvem.Domain.Model;
using PJNuvem.Infra.Data.Contexts;
using PJNuvem.Infra.Data.Repositories.Base;
using System;

namespace PJNuvem.Infra.Data.Repositories
{
    public class RepositoryClasseProcessual : RepositoryBase<ClasseProcessual, Guid>, IRepositoryClasseProcessual
    {
        protected readonly PJNuvemContext _context;

        public RepositoryClasseProcessual(PJNuvemContext context) : base(context)
        {
            _context = context;
        }
    }
}