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

  eval(evt){
    this.props.evalSequencerCommands([evt]);
  }

  render() {
    return (
      <div >
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand>Fakadata</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
            <SequencePicker items={this.props.names} onSelect={this.select.bind(this)} />
          </Navbar.Collapse>
        </Navbar>
        <Container style={styles.container} fluid>
          <Row>
            <Col xs={2}>
            <ButtonGroup vertical>
            <Button onClick={this.eval.bind(this,'seq')}>Seq</Button>
            <Button onClick={this.eval.bind(this,'para')}>Para</Button>
            <Button onClick={this.eval.bind(this,'noise')}>Noise</Button>
            </ButtonGroup>
              <StackDisplay stack={this.props.stack} />
              <Button variant='discrete' onClick={this.props.getSequencePreview}>Preview</Button>
            </Col>
            <Col xs={2} />
            <Col xs={8}>
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
