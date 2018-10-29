namespace PJNuvem.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
