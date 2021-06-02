namespace ppedv.Cooky.Model.Contracts
{
    public interface IUnitOfWork
    {
        public IRezeptRepository RezeptRepository { get; }

        IBaseRepository<T> GetRepo<T>() where T : Entity;


        void SaveAll();
    }
}
