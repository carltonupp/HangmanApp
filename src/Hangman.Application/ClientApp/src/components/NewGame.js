export async function NewGame() {
    fetch('api/Game/start').then(res => res.body.getReader()).then(r => r.read())
    return (
        <div>
            <p>Starting new game...</p>
        </div>
    )
}