using SudokuApp.Domain;
using System.Threading.Tasks;

namespace SudokuApp.ViewModel
{
    public interface IStorage
    {
       
		/// <summary>
		/// Loads data from repository storage
		/// </summary>
		/// <typeparam name="T">The type of data to load.</typeparam>
		/// <param name="name">The name of problem.</param>
		/// <returns>Returns the sudoku data.</returns>
		Task<T> LoadAsync<T>(string name);

        /// <summary>
        /// Saves data to repository storage.
        /// </summary>
        /// <param name="name">The name of  the problem.</param>
        /// <param name="data">The sudoku data to be saved.</param>
        /// <returns></returns>
        Task SaveAsync(string name, SudokuData data);
    }
}
