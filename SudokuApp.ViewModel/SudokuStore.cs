using System;
using System.Linq;
using System.Threading.Tasks;
using SudokuApp.Domain;
using SudokuApp.Repository;

namespace SudokuApp.ViewModel
{
    public class SudokuStore : IStorage
    {
        public Task<SudokuData> LoadAsync(string name)
        {

            SudokuData problemData = null;
            using (var unitOfWork = new UnitOfWork(new SudokuContext()))
            {
                // from  SudokuRepo
                var easyProblem = unitOfWork.Sudokus.GetSudokuProblems(name, 10).FirstOrDefault(s => s.Name.Equals(name));
                if (easyProblem != null)
                {
                    problemData = new SudokuData(easyProblem.ProblemState);
                }
                return Task.FromResult(problemData);
            }

        }

        public Task SaveAsync(string name, SudokuData data)
        {
            using (var unitOfWork = new UnitOfWork(new SudokuContext()))
            {
                // check notexists
                var easyProblem = unitOfWork.Sudokus.GetAll().FirstOrDefault(s => s.Name.Equals("Easy"));
                if (easyProblem != null)
                {
                    // unique: remove existing before add?
                    unitOfWork.Sudokus.Add(
                        new SudokuDataAccess
                        {
                            Name = "Easy",
                            Author = "Rem",
                            Solved = true,
                            ProblemState = data.State(),
                            UpdatedDate = DateTime.Today
                        });
                }
                unitOfWork.Complete();

            }
            return Task.FromResult(true);
        }
    }
}
