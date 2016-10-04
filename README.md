# SudokuApp
Desktop app for solving provided sudoku games

The Model, a sudoku problem data

- containing name
- number of filled cells per row
- level of complexity
- size of area compartment [3x3]

The View: presentation responsible for formatting text to look pretty on the screen (human readable).
Expected bahvior is to accept input on level and complexity

The View model: adds interacitivity events, data-bindings,  services for maintaining view state with own commands and methods (ex. fetching a list of problems from a remote server) 

The domain (Business) logic is typically kept separate from the model, the view and view-model: 

- validation ( transaction, rules valid),
- auditing (last modified date, modifying user)
- persistency ( a unique identifier ).
- generators (sample data)
- simulators ( problem solver)


