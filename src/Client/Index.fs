module Index

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fulma
open Fable.React

    module StreamingView =
        type Model = 
            { 
                Input: string
            }

        type Message =
            | SetInput of string

        let init () : Model * Cmd<Message> =
            ( { Input = "" 
            }
            ,Cmd.none
            )

        let update (message: Message) (model: Model) : Model * Cmd<Message> =
            match message with
            | SetInput value -> 
                ({ model with Input = value }
                , Cmd.none
                )


        let view (model: Model) (dispatch: Message -> unit) =
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

type SubViewModel =
    | NoSubView
    | StreamingView of StreamingView.Model
            
type Model = 
    {
        Name: string
        SubViewModel: SubViewModel 
    }

type Message =
    | SetName of string
    | StreamingViewMessage of StreamingView.Message


let init () : Model * Cmd<Message> =
    ( { Name = "" 
        SubViewModel = NoSubView
      }
    ,Cmd.none
    ) 

let update (message: Message) (model: Model) : Model * Cmd<Message> =
    match message with
        | SetName (value) -> 
            ({ model with Name = value }
            , Cmd.none
            )
        | StreamingViewMessage(_) -> failwith "Not Implemented"

let view (model: Model) (dispatch: Message -> unit) =
    Field.div [] [ 
        Field.body [] [
            str "Welcome To Your One Click Streaming Menu"
            ]

        Field.body [] [
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

