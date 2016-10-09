using System;

namespace SudokuApp.Repository
{
    public class SudokuDataAccess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ProblemState { get; set; }
        public bool Solved { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
