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
        | YouTube
            | PrimeVideo
            | Showmax
            | Netflix

            | GoToChoiceClick
            | CancelClick

    type Intent =
        | Cancel

    let init () =
        ( {
            WelcomeMessage = ""
          }
        , Cmd.none
        )

    let update (message:Message)(model:Model) =
        match message with
            | CancelClick ->
                ( model
                , Cmd.none
                )

            | YouTube ->
                ( model
                , Cmd.none
                )

            | PrimeVideo ->
               ( model
                , Cmd.none
                )

            | Showmax ->
                ( model
                , Cmd.none
                )

            | Netflix ->
                ( model
                , Cmd.none
                )

            | GoToChoiceClick ->
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
            Modal.Card.foot [ ] [
                    Button.button [
                        Button.Color IsInfo
                        // Button.OnClick(fun _ -> dispatch Proceed)
                    ] [
                        str "Go To Stream"
                    ]

                    Button.button [
                        Button.Color IsDanger
                        // Button.OnClick(fun _ -> dispatch Cancel)
                    ] [
                        str "Cancel"
                    ]
                ]
        ]





type SubViewModel =
    | NoSubView
    | StreamingOptionsViewModel of StreamingOptionsView.Model

type Model =
    {
        SubViewModel: SubViewModel
    }

type Message =
    | StreamingOptionsViewMessage of StreamingOptionsView.Message
    | ContinueClick
    | Cancel


let init () =
    ( {
        SubViewModel = NoSubView
      }
    , Cmd.none
    )

let update (message: Message) (model: Model) =
    match message with
    | StreamingOptionsViewMessage subViewMessage ->
        match model.SubViewModel with
        | NoSubView ->
            ( model
            , Cmd.none
            )

        | StreamingOptionsViewModel subViewModel ->
            let (nextSubViewModel, nextSubViewCommand) = StreamingOptionsView.update subViewMessage subViewModel

            ( { model with SubViewModel = StreamingOptionsViewModel(nextSubViewModel) }
            , Cmd.map StreamingOptionsViewMessage nextSubViewCommand
            )

    | ContinueClick  ->
        let (subViewModel, subViewCommand) = StreamingOptionsView.init ()
        ( { model with SubViewModel = StreamingOptionsViewModel(subViewModel) }
        , Cmd.map StreamingOptionsViewMessage subViewCommand
        // , None

        )

    | Cancel ->
        ( model
        , Cmd.none
        )

let view (model: Model) (dispatch: Message -> unit) =
    match model.SubViewModel with
    | NoSubView ->
        Container.container [ Container.IsFluid] [
            Card.card [ ] [
                Card.header [ ] [
                    Card.Header.title [] [
                         Field.div [ Field.IsHorizontal ] [
                            Field.body [] [ Notification.notification [ Notification.Color IsGreyLighter ] [
                                Card.Header.title [] [str "Welcome To Your One Click Streaming Menu "]
                                ]
                            ]
                        ]
                    ]
                ]
                Card.content [] [ Field.body [] [ Notification.notification [ Notification.Color IsLight] [
                                    p [] [str "Click to get Streaming Menu "]
                                    ]
                                ]
                            ]
                Modal.Card.foot [] [
                    Field.div [] [
                            Level.level [] [
                                Level.left [] []
                                Level.right [] [
                                    Field.div [ ] [
                                        Control.div [] [
                                            Button.button [
                                                Button.Color IsInfo
                                                Button.OnClick (fun _ -> dispatch ContinueClick)
                                            ] [
                                                str "Click"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
               ]
            ]


    | StreamingOptionsViewModel subViewModel ->
        StreamingOptionsView.view subViewModel (StreamingOptionsViewMessage >> dispatch)


