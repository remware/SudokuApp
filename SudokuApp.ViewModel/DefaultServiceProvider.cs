using SudokuApp.Model;
using System.Collections.Generic;
using System.Linq;
using SudokuApp.Domain;
using SudokuApp.Repository;
using System.Data.Entity;

namespace SudokuApp.ViewModel
{
    /// <summary>
    /// Default access provider to sudoku repository
    /// Single responsibility: basic access to context
    /// </summary>
    public class DefaultServiceProvider : IService
    {
        public DefaultServiceProvider(ISudokuRepository repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        private readonly ISudokuRepository _repositoryProvider;

        public DefaultServiceProvider()
        {
            Database.SetInitializer(new SudokuContextDataBaseInitializer());
            _repositoryProvider = new SudokuRepository( new SudokuContext());
        }

        public void DeleteProblem(SudokuProblem problem)
        {
            //
        }

        public List<SudokuProblem> GetProblems(string level, int amount)
        {            
            var defaultProblem = new List<SudokuProblem>
            {
                new SudokuProblem
                {
                    Name = "Easy",
                    Complexity = 7,
                    Level = 5
                }
            };

            if (!ChallengeLevel.Supported.Any(s => s.Contains(level))) return defaultProblem;

            var allAvailable = _repositoryProvider.GetSudokuProblems(level, amount);
            if (allAvailable != null) 
                return allAvailable.Select(p => new SudokuProblem
                {
                    Name = p.Name,
                    Complexity = 7,
                    Level = 5,
                    Challenge = new SudokuData(p.ProblemState)
                }).ToList();

            // default         
            return defaultProblem;
        }
    }
}
