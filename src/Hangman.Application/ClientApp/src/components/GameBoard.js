import {LetterTile} from "./LetterTile";
import {useEffect} from "react";

export function GameBoard(props) {
    
    return (
        <div>
            <p>Number of guesses: {props.game.numberOfGuesses}</p>
            {props.game.wordProgress.map((l, i) => {
                return <div className={'d-inline-block me-5'} key={i}>{l}</div>
            })}
            <div>
                {[...'ABCDEFGHIJKLMNOPQRSTUVWXYZ'].map(l => {
                    return <LetterTile value={l} 
                                       key={l} 
                                       disabled={isLetterUsed(l, props.game.usedLetters)} 
                                       letterSelected={props.letterSelected} />
                })}
            </div>
        </div>
    )
}

const isLetterUsed = (letter, usedLetters) => {
    return usedLetters.some(ul => ul === letter);
}
