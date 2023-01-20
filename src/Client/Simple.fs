module Simple

open System
open Elmish
open Elmish.React
open Fable.Core
open Fable.Import
open Fable.React.Props
open Fulma
open Fable.React
open Feliz


type VideoProvider =
    | Youtube
    | PrimeVideo
    | Showmax
    | Netflix

type Model = VideoProvider option


type Message = VideoProvider

let init () =
    (
        None
    ,   Cmd.Empty
    )


let update (provider) model =
    let url =
        match provider with
        | Youtube -> "https://www.youtube.com/"
        | PrimeVideo -> "https://www.primevideo.com/?ref_=atv_auth_signout"
        | Showmax -> "https://www.showmax.com/join/eng/welcome-showmax/za?utm_source=google_Google_search&utm_medium=paid&utm_campaign=ZA_NUA_AO_BRA_S_Google_search_Showmax_CW18_May_2021_EXACT_Display_Network_Test&utm_content=search_NUA_AO_BRA_S_Showmax_LogIn_CW18_May_2021_EXACT&utm_placement=&utm_creative=Text_Watch_Display_Network_Test&gclid=Cj0KCQiA8aOeBhCWARIsANRFrQH7HahDODZptX8jFcCXfNAevNVqFrRPxqH12vwdVZf1ar6N2ubeoWwaAtChEALw_wcB&gclsrc=aw.ds"
        | Netflix -> "https://www.netflix.com/za/"

    let x =
        Browser.Dom.window.``open``(url, "_self")

    (
        model
    ,   Cmd.Empty
    )

let view (model: Model) (dispatch: Message -> unit) =


    div [] [
        yield str "Bla bla don't abuse the service stuff"

        yield Button.button [ Button.OnClick (fun _ -> dispatch Youtube ) ] [ str "YT" ]
        yield Button.button [ Button.OnClick (fun _ -> dispatch Showmax ) ] [ str "SM" ]

    ]