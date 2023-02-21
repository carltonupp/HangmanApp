import React, {useState} from 'react';
import {Button, Col, Form, Input, Row} from "reactstrap";
import {useNavigate} from "react-router-dom";

export function Home() {
    const navigate = useNavigate();
    const [value, setValue] = useState({ gameId: ''});
    
    const create = () => {
        fetch('api/Game/start')
            .then(resp => resp.json())
            .then(json => navigate(`/game/${json.gameId}`));
    }
    
    return (
        <div>
            <Form>
                <Row>
                    <Col>
                        <Input value={value.gameId} onChange={(e) => setValue({ ...value, gameId: e.target.value})} />
                    </Col>
                    <Col>
                        <Button onClick={() => navigate(`game/${value.gameId}`)}>Join</Button>
                    </Col>
                    <Col>
                        <Button onClick={create}>Start</Button>
                    </Col>
                </Row>
            </Form>

        </div>
    );
}
