namespace DAL.Interfaces
{
    public interface IUOW
    {
        //save pending changes to the data store

        IOwnerRepository Owners { get; }
        IPetRepository Pets { get; }
        void Commit();
    }
}