# SudokuApp
Desktop app for solving provided sudoku games

The Model represents a sudoku problem from "real" world:
- containing name
- number of filled cells per row
- level of complexity
- size of area compartment [3x3]

The View: presentation responsible for formatting text to look pretty on the screen (human readable).
Expected bahvior is to accept input on level and complexity

The View model: adds interacitivity events, data-bindings,  services for maintaining view state with own commands and methods (ex. fetching a list of problems from a remote server) 

The business logic is typically kept as a *service* separated from the model, the view and view-model: 
- validation ( transaction, rules valid),
- auditing (last modified date, modifying user)
- persistency ( a unique identifier ).
- generators (sample data)
- simulators ( problem solver)


**Installation**

The project comes with installer package. Just run the msi program and follow the steps.
You need MySql installed either locally or an url where to contact it with appropriate user credentials.
