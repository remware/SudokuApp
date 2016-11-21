namespace SudokuApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SudokuProblem",
                c => new
                    {
                        id_problem = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        ProblemState = c.String(nullable: false, unicode: false),
                        Solved = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id_problem);
            
            CreateStoredProcedure(
                "dbo.SudokuDataAccess_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 1073741823, unicode: false),
                        Author = p.String(maxLength: 1073741823, unicode: false),
                        ProblemState = p.String(maxLength: 1073741823, unicode: false),
                        Solved = p.Boolean(),
                        UpdatedDate = p.DateTime(),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `SudokuProblem`(
                      `Name`, 
                      `Author`, 
                      `ProblemState`, 
                      `Solved`, 
                      `UpdatedDate`) VALUES (
                      @Name, 
                      @Author, 
                      @ProblemState, 
                      @Solved, 
                      @UpdatedDate);
                      SELECT
                      `id_problem`
                      FROM `SudokuProblem`
                       WHERE  row_count() > 0 AND `id_problem`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.SudokuDataAccess_Update",
                p => new
                    {
                        id_problem = p.Int(),
                        Name = p.String(maxLength: 1073741823, unicode: false),
                        Author = p.String(maxLength: 1073741823, unicode: false),
                        ProblemState = p.String(maxLength: 1073741823, unicode: false),
                        Solved = p.Boolean(),
                        UpdatedDate = p.DateTime(),
                    },
                body:
                    @"UPDATE `SudokuProblem` SET `Name`=@Name, `Author`=@Author, `ProblemState`=@ProblemState, `Solved`=@Solved, `UpdatedDate`=@UpdatedDate WHERE `id_problem` = @id_problem;"
            );
            
            CreateStoredProcedure(
                "dbo.SudokuDataAccess_Delete",
                p => new
                    {
                        id_problem = p.Int(),
                    },
                body:
                    @"DELETE FROM `SudokuProblem` WHERE `id_problem` = @id_problem;"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SudokuDataAccess_Delete");
            DropStoredProcedure("dbo.SudokuDataAccess_Update");
            DropStoredProcedure("dbo.SudokuDataAccess_Insert");
            DropTable("dbo.SudokuProblem");
        }
    }
}
