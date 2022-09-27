module Index

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fulma
open Fable.React
open Feliz

   
module StreamingOptionsView =
    type Model = 
        {
            WelcomeMessage: string 
        }

    type Message =
        | Click


    let init () : Model * Cmd<Message> =
        ( { 
            WelcomeMessage = ""
        }
        ,Cmd.none
        ) 

    let update (message: Message) (model: Model) : Model * Cmd<Message> =
        match message with

            | Click  -> 
                ( model
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
    | StreamingOptionsViewMessage of StreamingOptionsView.Message


let init () : Model * Cmd<Message> =
    ( { 
        SubViewModel = NoSubView
      }
    ,Cmd.none
    ) 

let update (message: Message) (model: Model) : Model * Cmd<Message> =
    match message with

        | StreamingOptionsViewMessage subViewmodel ->
            let subViewModel = StreamingOptionsView.init 
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


