import React, { Component } from 'react';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Row from 'react-bootstrap/Row';
import { connect } from 'react-redux';

import * as actions from '../services/actionCreators';
import DefinitionEditor from './DefinitionEditor';
import DefinitionList from './DefinitionList';
import ExpressionGraph from './ExpressionGraph';


const styles = {
  container: {
    marginTop: 20
  }
};

class App extends Component {

  componentDidMount() {
    this.props.getDefinitionList();
  }

  select(id) {
    if (+id === 0) {
      this.props.clearPreview();
      this.props.clearDefinition();
    } else {
      this.props.getDefinition(id);
    }
  }

  render() {
    return (
      <div >
        <Navbar bg="primary" variant="dark">
          <Navbar.Brand>Fakadata</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
            <DefinitionList items={this.props.library} onSelect={this.select.bind(this)} />
          </Navbar.Collapse>
        </Navbar>
        <Container style={styles.container} fluid>
          <Row>
            <Col xs={2}>
              <DefinitionEditor />
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
  const { library, preview } = state;
  return { library, preview };
};

export default connect(mapStateToProps, actions)(App);
