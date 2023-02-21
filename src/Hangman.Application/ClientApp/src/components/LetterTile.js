import './LetterTile.css';

export function LetterTile(props) {
    const cssClass = props.disabled ? 'letter-tile letter-tile--disabled' : 'letter-tile';
    return (
        <div className={cssClass} onClick={() =>  props.disabled ? false : props.letterSelected(props.value)}>
            {props.value}
        </div>
    )
}