using PJNuvem.Infra.Data.Contexts;

namespace PJNuvem.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PJNuvemContext _context;

        public UnitOfWork(PJNuvemContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}