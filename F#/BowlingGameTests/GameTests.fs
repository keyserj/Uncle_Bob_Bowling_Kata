﻿module GameTests

open System
open Xunit
open Game

let assert_rolls_makes_score rolls score =
    let game = rolls |> List.fold Game.roll []
    Assert.Equal(score, Game.score game)

[<Fact>]
let ``All gutters scores 0`` () =
    assert_rolls_makes_score [for i in 1..20 -> 0] 0

[<Fact>]
let ``All ones scores 20`` () =
    assert_rolls_makes_score [for i in 1..20 -> 1] 20

[<Fact>]
let ``Spare counts next roll twice`` () =
    assert_rolls_makes_score [4;6;3] 16