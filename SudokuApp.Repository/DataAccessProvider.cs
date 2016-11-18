namespace SudokuApp.Repository
{
    public class DataAccessProvider<TDataAccess> : IDataAccessProvider<TDataAccess>
        where TDataAccess : IDataAccess, new()
    {
        public TDataAccess NewDataAccess()
        {
            return new TDataAccess();
        }
    }
}
