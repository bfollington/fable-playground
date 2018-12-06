module App.Model
open Elmish
open System
open App.Api

type Model = {
  count: int
  message: string
  githubData: GithubResponse option
}

type Msg =
| Increment
| Decrement
| UpdateText of string
| FetchGithubData
| ReceivedGithubData of GithubResponse
| Error of string

let init() =
  { count = 0
    message = ""
    githubData = None },
  Cmd.none

let update (msg:Msg) (model:Model): Model * Cmd<Msg> =
    match msg with
    | Increment -> { model with count = model.count + 1 }, Cmd.none
    | Decrement -> { model with count = model.count - 1 }, Cmd.none
    | UpdateText text -> { model with message = text }, Cmd.none
    | FetchGithubData -> model, Cmd.ofPromise
                                  fetchGithubResponse
                                  ()
                                  (fun a -> 
                                    Console.WriteLine(a)
                                    ReceivedGithubData a
                                  )
                                  (fun e -> Error e.Message)
    | ReceivedGithubData data -> { model with githubData = Some data }, Cmd.none                              
    | Error _ -> model, Cmd.none                            