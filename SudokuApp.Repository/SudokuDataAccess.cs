using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudokuApp.Repository
{
    [Table("SudokuProblems")]
    public class SudokuDataAccess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_problem")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        [Required]
        public string ProblemState { get; set; }
        public bool Solved { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
