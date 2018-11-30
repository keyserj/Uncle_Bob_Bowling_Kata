module Game

    let roll game pins =
        List.append game [pins]

    let private isLastFrame frame =
        frame = 10

    let rec private addNextRolls numRolls game =
        if numRolls = 0 then
            0
        else
            let recurse = addNextRolls (numRolls - 1)
            match game with
            | [] -> 0
            | roll::game -> roll + recurse game

    let private strikeBonus game =
        addNextRolls 2 game

    let private spareBonus game =
        addNextRolls 1 game

    let score (game:int list) =
        let rec scoreFrame currentFrame (game:int list) =
            if isLastFrame currentFrame then
                List.sum game
            else
                let recurse = scoreFrame (currentFrame + 1)
                match game with
                | [] ->
                    0
                | [roll] ->
                    roll
                | 10::game ->
                    10 + strikeBonus game + recurse game
                | roll1::roll2::game when roll1 + roll2 = 10 ->
                    10 + spareBonus game + recurse game
                | roll1::roll2::game ->
                    roll1 + roll2 + recurse game
        scoreFrame 1 game