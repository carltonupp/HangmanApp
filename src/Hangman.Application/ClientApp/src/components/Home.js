import React, { Component } from 'react';
import {Button, Col, Form, Input, Row} from "reactstrap";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
          <Form>
              <Row>
                  <Col>
                      <Input />
                  </Col>
                  <Col>
                      <Button>Join</Button>
                  </Col>
                  <Col>
                      <Button onClick={this.create}>Start</Button>  
                  </Col>
              </Row>
          </Form>

      </div>
    );
  }
  
  create() {
      fetch('api/Game/start').then(resp => resp.json()).then(json => console.log(json))
  }
  
  join() {
      
  }
}
