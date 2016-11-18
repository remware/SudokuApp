namespace SudokuApp.Repository
{
    public interface IDataAccessProvider<TDataAccess> where TDataAccess : IDataAccess, new()
    {
    }
}