import {LetterTile} from "./LetterTile";

export function GameBoard(props) {
    return (
        <div>
            <p>Number of guesses: {props.game.numberOfGuesses}</p>
            {props.game.wordProgress.map(l => {
                return <div className={'d-inline-block me-5'}>{l}</div>
            })}
            <div>
                {[...'ABCDEFGHIJKLMNOPQRSTUVWXYZ'].map(l => {
                    return <LetterTile value={l} disabled={isLetterUsed(l, props.game.usedLetters)}/>
                })}
            </div>
        </div>
    )
}

const isLetterUsed = (letter, usedLetters) => {
    return usedLetters.some(ul => ul === letter);
}
