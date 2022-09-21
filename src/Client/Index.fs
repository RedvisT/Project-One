module Index

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fulma
open Fable.React
open Validations

type Model = 
    { 
        Input: string
    }

type Msg =
    | SetInput of string

let init () : Model * Cmd<Msg> =
    ( { Input = "" 
    }
    ,Cmd.none
    )

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | SetInput value -> 
        ({ model with Input = value }
        , Cmd.none
        )


let view (model: Model) (dispatch: Msg -> unit) =
    Container.container [] [
        Card.card [ ] [
            Card.header [ ] [
                Card.Header.title [] [ str "Choose Your Streaming" ]
            ]
            Card.content [ ] [
                div [ ] [

                    strong [ ] [str "Do you want to:"]

                    div []
                            [ Field.div [ Field.Props
                                [] ] [
                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props [
                                                // Checked(model.xxx)
                                                // OnClick(fun _ -> SetAction XXX |> dispatch)
                                            ]
                                        ]
                                        str (" YouTube")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props [
                                                // Checked(model.xxx)
                                                // OnClick(fun _ -> SetAction XXX |> dispatch)
                                            ]
                                        ]
                                        str (" Prime Video")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props [
                                                // Checked(model.xxx)
                                                // OnClick(fun _ -> SetAction XXX |> dispatch)
                                            ]
                                        ]
                                        str (" Showmax")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props [
                                                // Checked(model.xxx)
                                                // OnClick(fun _ -> SetAction XXX |> dispatch)
                                            ]
                                        ]
                                        str (" Netflix")
                                        ]
                                    ]
                                ]
                            ]

                            


                    Level.level [] [
                        Level.left [] []
                        Level.right [] [
                            Field.div [ ] [
                                Control.div [] [
                                    Button.button [
                                        // Button.Disabled model. XXX
                                        // Button.IsLoading model. XXX
                                        // Button.Color (if isModelValid model then IsInfo else IsGrey)
                                        // Button.OnClick (fun _ -> dispatch SubmitClick)
                                    ] [
                                        str "Login"
                                    ]

                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]