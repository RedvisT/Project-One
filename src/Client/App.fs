module App

open Elmish
open Elmish.React
open Index

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif


Program.mkProgram StreamingOptionsView.init StreamingOptionsView.update StreamingOptionsView.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run

Program.mkProgram Index.init Index.update Index.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run