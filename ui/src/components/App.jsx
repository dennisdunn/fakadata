import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Row from 'react-bootstrap/Row';
import { connect } from 'react-redux';
import * as actions from '../services/actionCreators';
import ExpressionGraph from './ExpressionGraph';
import SequencePicker from './SequencePicker';
import SourceEditor from './SourceEditor';

const styles = {
  container: {
    marginTop: 20
  }
};

class App extends Component {

  componentDidMount() {
    this.props.getSequenceList();
  }

  select(sequence) {
    this.props.setSource(`${sequence}\nload`);
  }

  textChanged(args) {
    this.props.setSource(args.target.value);
  }

  preview() {
    const lines = this.props.source.split('\n');
    this.props.getSequence(lines);
  }

  render() {
    return (
      <div >
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand>Fakadata</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
            <SequencePicker items={this.props.options} onSelect={this.select.bind(this)} />
          </Navbar.Collapse>
        </Navbar>
        <Container style={styles.container} fluid>
          <Row>
            <Col xs={2}>
              <SourceEditor text={this.props.source} rows={10} onChange={this.textChanged.bind(this)} />
              <Button variant='discrete' onClick={this.preview.bind(this)}>Preview</Button>
            </Col>
            <Col xs={2} />
            <Col xs={8}>
              <ExpressionGraph data={this.props.preview} />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

const mapStateToProps = state => {
  const { options, preview, source } = state;
  return { options, preview, source };
};

export default connect(mapStateToProps, actions)(App);
