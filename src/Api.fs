module App.Api
open Thoth.Json
open Fable.PowerPack

let url = "https://api.github.com/search/repositories?q=react"

type GithubResponseItem = {
  id: int
  name: string
  stargazers_count: int
}

type GithubResponse = {
  total_count: int
  items: GithubResponseItem list
}

let githubResponseDecoder = Decode.Auto.generateDecoder<GithubResponse>()

let fetchGithubResponse () = Fetch.fetchAs<GithubResponse> url githubResponseDecoder []

