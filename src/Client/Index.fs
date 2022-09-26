module Index

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fulma
open Fable.React
open Feliz

    module StreamingView =

        type Model = unit
           
        type Message =
            | YouTube
            | PrimeVideo
            | Showmax
            | Netflix

            | GoToChoiceClick
            | CancelClick

        type Intent =
        | Cancel

        let init () : Cmd<Message> =
            ( 
             Cmd.none
            )

        let update (message: Message) :  Cmd<Message> * Intent option =
            match message with
            | CancelClick ->
                ( Cmd.none
                , Some Cancel
                )

            | YouTube -> 
                ( Cmd.none
                , None
                )
                
            | PrimeVideo -> 
                ( Cmd.none
                , None
                )

            | Showmax -> 
                ( Cmd.none
                , None
                )

            | Netflix -> 
                ( Cmd.none
                , None
                )

            | GoToChoiceClick -> 
                ( Cmd.none
                , None
                )


        let view (dispatch: Message -> unit) =
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
            
type Model = 
    {
        SubViewModel: SubViewModel 
    }

type Message =
    | StreamingViewMessage of StreamingView.Message


let init () : Model * Cmd<Message> =
    ( { 
        SubViewModel = NoSubView
      }
    ,Cmd.none
    ) 

let update (message: Message) (model: Model) : Model * Cmd<Message> =
    match message with

        | StreamingViewMessage subViewmodel ->
            let subViewModel = StreamingView.init 
            ( model
            , Cmd.none
            )

let view (model: Model) (dispatch: Message -> unit) =
    Field.div [] [
        Field.div [ Field.IsHorizontal ] [ 
            Field.body [] [ Notification.notification [ Notification.Color IsSuccess ] [
                strong [] [str "Welcome To Your One Click Streaming Menu "] 
                p [] [ str " Click To Continue" ]
                ]
            ]
        ] 
        Field.div [] [        
            Level.level [] [
                Level.left [] []
                Level.right [] [
                    Field.div [ ] [
                        Control.div [] [
                            Button.button [
                                Button.Color IsInfo 
                                // Button.OnClick (fun _ -> dispatch SubmitClick)
                            ] [
                                str "Click"
                            ]

                        ]
                    ]
                ]
            ]
        ]
    ]


