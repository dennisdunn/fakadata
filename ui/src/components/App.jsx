import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Row from 'react-bootstrap/Row';
import { connect } from 'react-redux';
import * as actions from '../services/actionCreators';
import ExpressionGraph from './ExpressionGraph';
import SequencePicker from './SequencePicker';
import StackDisplay from './StackDisplay';

const styles = {
  container: {
    marginTop: 20
  }
};

class App extends Component {

  componentDidMount() {
    this.props.getNamedSequences();
  }

  select(name) {
    this.props.evalSequencerCommands([name, "load"]);
  }

  eval(evt) {
    this.props.evalSequencerCommands([evt]);
  }

  render() {
    return (
      <div >
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand>Fakadata</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
          </Navbar.Collapse>
        </Navbar>
        <Container style={styles.container} fluid>
          <Row>
            <Col xs={3} sm={2} lg={1}>
              <ButtonGroup vertical>
                <SequencePicker items={this.props.names} onSelect={this.select.bind(this)} />
                <Button variant="success" onClick={this.eval.bind(this, 'seq')}>Base</Button>
                <Button variant="success" onClick={this.eval.bind(this, 'para')}>Para</Button>
                <Button variant="success" onClick={this.eval.bind(this, 'noise')}>Noise</Button>
                <Button variant='secondary' onClick={this.props.getSequencePreview}>Preview</Button>
              </ButtonGroup>
            </Col>
            <Col xs={6} sm={4} lg={2}>
              <StackDisplay stack={this.props.stack} />
            </Col>
            <Col xs={3} sm={2} lg={1}>
              <ButtonGroup vertical>
                <Button variant="secondary" onClick={this.eval.bind(this, 'swap')}>Swap</Button>
                <Button variant="secondary" onClick={this.eval.bind(this, 'drop')}>Drop</Button>
                <Button variant="secondary" onClick={this.eval.bind(this, 'pick')}>Pick</Button>
                <Button variant="secondary" onClick={this.eval.bind(this, 'roll')}>Roll</Button>
                <Button variant="secondary" onClick={this.eval.bind(this, 'clear')}>Clear</Button>
              </ButtonGroup>
            </Col>
            <Col>
              <ExpressionGraph data={this.props.data} />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

const mapStateToProps = state => {
  return { ...state.sequencer, ...state.error };
};

export default connect(mapStateToProps, actions)(App);
