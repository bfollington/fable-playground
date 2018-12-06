module App.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Model
open Fable.Import.React

let view (model:Model) dispatch =

  let onUpdateText (e:FormEvent) = dispatch (UpdateText e.Value)
    

  div []  [
      div [] [
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
        div [] [ str (string model.count) ]
        button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
      ]
      div [] [
        input [ Value model.message; OnChange onUpdateText]
      ]          
      div [] [
        button [ OnClick (fun _ -> dispatch FetchGithubData) ] [ str "Fetch" ]        
      ]          

      div [] (
        match model.githubData with
          | Some data -> 
            data.items |> List.map  (fun item -> 
              li [] [str item.name]
            )
          | None _ -> []
      )
    ]