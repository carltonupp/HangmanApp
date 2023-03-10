import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import {GameBoard} from "./GameBoard";

export function Game() {
    const { gameId } = useParams();
    const [value, setValue] = useState({ gameState: { numberOfGuesses: 0, wordProgress: [], usedLetters: []}})
    
    useEffect(() => {
        fetch(`api/Game/${gameId}`)
            .then(resp => resp.json())
            .then(gameState =>  setValue({ ...value, gameState }));
    }, [gameId])
    
    const letterSelected = (letter) => {
        const requestBody = {
            letter,
        }
        
        fetch(`api/Game/${gameId}`, {
            body: JSON.stringify(requestBody),
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        }).catch(err => console.error(err))
    }
    
    return (
        <div>
            <h2>Game {gameId}</h2>
            <GameBoard game={value.gameState} letterSelected={letterSelected} />
        </div>
    )
}