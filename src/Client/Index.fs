module Index

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fulma
open Fable.React
open Feliz



(* Links *)
let YouTube = [ "https://www.youtube.com/" ]
let PrimeVideo = [ "https://www.primevideo.com/?ref_=atv_auth_signout" ]
let Showmax = [ "https://www.showmax.com/join/eng/welcome-showmax/za?utm_source=google_Google_search&utm_medium=paid&utm_campaign=ZA_NUA_AO_BRA_S_Google_search_Showmax_CW18_May_2021_EXACT_Display_Network_Test&utm_content=search_NUA_AO_BRA_S_Showmax_LogIn_CW18_May_2021_EXACT&utm_placement=&utm_creative=Text_Watch_Display_Network_Test&gclid=Cj0KCQiA8aOeBhCWARIsANRFrQH7HahDODZptX8jFcCXfNAevNVqFrRPxqH12vwdVZf1ar6N2ubeoWwaAtChEALw_wcB&gclsrc=aw.ds" ]
let Netflix = [ "https://www.netflix.com/za/" ]


(* Child *)
module StreamingOptionsView =


    type Model = Streaming

    type Message =
        | YouTube
        | PrimeVideo
        | Showmax
        | Netflix

        | GoToChoiceClick
        | CancelClick

    type Intent =
        | Cancel
        | GoToChoice

    let init () =
        ( Model.Streaming
        , Cmd.none
        )

    let update (message:Message)(model:Model) =
        match message with
            | CancelClick ->
                ( model
                , Cmd.none
                , Some Cancel
                )

            | YouTube ->
                Browser.Dom.window.``open``("https://www.youtube.com/", "_self") |> ignore

                ( model
                , Cmd.none
                , None
                )

            | PrimeVideo ->
                Browser.Dom.window.``open``("https://www.primevideo.com/?ref_=atv_auth_signout", "_self") |> ignore

                ( model
                , Cmd.none
                , None
                )

            | Showmax ->
                Browser.Dom.window.``open``("https://www.showmax.com/join/eng/welcome-showmax/za?utm_source=google_Google_search&utm_medium=paid&utm_campaign=ZA_NUA_AO_BRA_S_Google_search_Showmax_CW18_May_2021_EXACT_Display_Network_Test&utm_content=search_NUA_AO_BRA_S_Showmax_LogIn_CW18_May_2021_EXACT&utm_placement=&utm_creative=Text_Watch_Display_Network_Test&gclid=Cj0KCQiA8aOeBhCWARIsANRFrQH7HahDODZptX8jFcCXfNAevNVqFrRPxqH12vwdVZf1ar6N2ubeoWwaAtChEALw_wcB&gclsrc=aw.ds") |> ignore

                ( model
                , Cmd.none
                , None
                )

            | Netflix ->
                Browser.Dom.window.``open``("https://www.netflix.com/za/", "_self") |> ignore

                ( model
                , Cmd.none
                , None
                )

            | GoToChoiceClick ->
                ( model
                , Cmd.none
                , Some GoToChoice
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
                                            Radio.Input.Props []
                                        ]
                                        str (" YouTube")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props []
                                        ]
                                        str (" Prime Video")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props []
                                        ]
                                        str (" Showmax")
                                        ]
                                    ]

                                Control.div [] [
                                    Radio.radio [ ] [
                                        Radio.input [
                                            Radio.Input.Name "streaming"
                                            Radio.Input.Props []
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
                        Button.OnClick(fun _ -> dispatch GoToChoiceClick)
                    ] [
                        str "Go To Stream"
                    ]

                    Button.button [
                        Button.Color IsDanger
                        Button.OnClick(fun _ -> dispatch CancelClick)
                    ] [
                        str "Cancel"
                    ]
                ]
        ]




(* Parent *)
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

type Intent =
    | Cancel

let init () =
    ( {
        SubViewModel = NoSubView
      }
    , Cmd.none
    )

let update (message: Message) (model: Model)  =
    match message with
    | StreamingOptionsViewMessage subViewMessage ->
        match model.SubViewModel with
        | NoSubView ->
            ( model
            , Cmd.none
            )

        | StreamingOptionsViewModel subViewModel ->
            let (nextSubViewModel, nextSubViewCommand, anyIntent) = StreamingOptionsView.update subViewMessage subViewModel
            match anyIntent with
            | None ->
                ( { model with SubViewModel = StreamingOptionsViewModel(subViewModel) }
                , Cmd.none
                )

            | Some (StreamingOptionsView.Cancel)->
                ( { model with SubViewModel = NoSubView }
                , Cmd.none
                )

            | Some (StreamingOptionsView.GoToChoice)->
                ( { model with SubViewModel = NoSubView }
                , Cmd.none
                )


    | ContinueClick ->
        let (subViewModel, subViewCommand) = StreamingOptionsView.init ()
        ( { model with SubViewModel = StreamingOptionsViewModel(subViewModel) }
        , Cmd.map StreamingOptionsViewMessage subViewCommand
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


