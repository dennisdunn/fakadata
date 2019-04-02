import React, { Component } from 'react';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Row from 'react-bootstrap/Row';
import { connect } from 'react-redux';

import * as actions from '../services/actionCreators';
import ExpressionEditor from './ExpressionEditor';
import ExpressionGraph from './ExpressionGraph';

const styles = {
  container: {
    marginTop: 20
  }
};

class App extends Component {

  render() {
    return (
      <div >
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand>Fakadata Builder</Navbar.Brand>
        </Navbar>
        <Container style={styles.container} fluid>
          <Row>
            <Col xs={2}>
              <ExpressionEditor expressions={this.props.library} onApply={this.props.generateData} />
            </Col>
            <Col xs={1}></Col>
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
  return { ...state };
};

export default connect(mapStateToProps, actions)(App);
