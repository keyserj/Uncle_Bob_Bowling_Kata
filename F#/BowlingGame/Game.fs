module Game

    let roll game pins =
        List.append game [pins]

    let private maxRoll = 10
    let private lastFrame = 10

    let private isStrike fstRoll =
        fstRoll = maxRoll

    let private isSpare fstRoll sndRoll =
        fstRoll + sndRoll = maxRoll

    let private isLastFrame frame =
        frame = lastFrame

    let score (game:int list) =
        let rec scoreFrame currentFrame (game:int list) =
            if isLastFrame currentFrame then
                List.sum game
            else
                let recurse = scoreFrame (currentFrame + 1)
                match game with
                | [] ->
                    0
                | fst::[] ->
                    fst
                | fst::snd::[] when isStrike fst ->
                    fst + snd + recurse [snd]
                | fst::snd::[] ->
                    fst + snd
                | fst::snd::tail when isStrike fst ->
                    fst + snd + tail.Head + recurse (snd::tail)
                | fst::snd::tail when isSpare fst snd ->
                    fst + snd + tail.Head + recurse tail
                | fst::snd::tail ->
                    fst + snd + recurse tail
        scoreFrame 1 game