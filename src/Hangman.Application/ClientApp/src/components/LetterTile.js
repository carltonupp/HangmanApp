import './LetterTile.css';

export function LetterTile(props) {
    const cssClass = props.disabled ? 'letter-tile letter-tile--disabled' : 'letter-tile';
    return (
        <div className={cssClass} onClick={() => console.log(props.value)}>
            {props.value}
        </div>
    )
}