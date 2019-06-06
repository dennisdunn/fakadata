import React from 'react';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import FormControl from 'react-bootstrap/FormControl';
import InputGroup from 'react-bootstrap/InputGroup';
import Navbar from 'react-bootstrap/Navbar';
import Row from 'react-bootstrap/Row';
import ButtonToolbar from 'react-bootstrap/ButtonToolbar';
import { connect } from 'react-redux';
import * as Actions from './actions/stackActionCreators';
import './app.css';
import StackDisplay from './components/StackDisplay';

export const App = ({ stack, ...props }) => {

  const [input, setInput] = React.useState('');

  return (
    <div>
      <Navbar variant='dark' bg='primary'>
        <Navbar.Brand>Fakadata</Navbar.Brand>
      </Navbar>
      <Container>
        <Row>
          <Col>
            <InputGroup size="sm">
              <FormControl value={input} onChange={e => setInput(e.target.value)} />
              <InputGroup.Append>
                <Button variant='outline-secondary' onClick={() => { props.push(input); setInput(''); }}>Enter</Button>
              </InputGroup.Append>
            </InputGroup>
            <ButtonGroup>
              <Button variant='success' onClick={props.swap}>Swap</Button>
              <Button variant='success' onClick={props.drop}>Drop</Button>
              <Button variant='success' onClick={props.pick}>Pick</Button>
              <Button variant='success' onClick={props.roll}>Roll</Button>
              <Button variant='success' onClick={props.clear}>Clear</Button>
            </ButtonGroup>
          </Col>
          <Col>
            <StackDisplay stack={stack} />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

const mapStateToProps = state => {
  return { stack: state.stack };
}

export default connect(mapStateToProps, Actions)(App);
