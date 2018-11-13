module Game

    let roll game pins =
        List.append game [pins]

    let score (game:int list) =
        List.sum game