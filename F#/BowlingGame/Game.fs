module Game

    let roll game pins =
        List.append game [pins]

    let score (game:int list) =
        let rec scoreFrame frameNumber (game:int list) =
            if frameNumber = 10 then
                List.sum game
            else
                let recurse = scoreFrame (frameNumber + 1)
                match game with
                | [] ->
                    0
                | fst::[] ->
                    fst
                | fst::snd::[] when fst = 10 ->
                    fst + snd + recurse [snd]
                | fst::snd::[] ->
                    fst + snd
                | fst::snd::tail when fst = 10 ->
                    fst + snd + tail.Head + recurse (snd::tail)
                | fst::snd::tail when fst + snd = 10 ->
                    fst + snd + tail.Head + recurse tail
                | fst::snd::tail ->
                    fst + snd + recurse tail
        scoreFrame 1 game