using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudokuApp.Repository
{
    [Table("SudokuProblem")]
    public class SudokuDataAccess
    {
        [Key]
        [Column("id_problem")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ProblemState { get; set; }
        public bool Solved { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
