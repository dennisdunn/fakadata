import React from 'react';
import { connect } from 'react-redux';
import './app.css';
import StackDisplay from './components/StackDisplay';
import * as Actions from './actions/stackActionCreators';

export const App = ({ stack, ...props }) => {
  return (
    <div>
      <h1>Fakadata</h1>
      <h4>Building timeseries data on demand.</h4>
      <StackDisplay stack={stack} className='stack' />
      <button onClick={() => props.push(Math.random())}>push</button>
      <button onClick={props.drop}>drop</button>
      <button onClick={props.clear}>clear</button>
    </div>
  );
};

const mapStateToProps = state => {
  return { stack: state.stack };
}

export default connect(mapStateToProps, Actions)(App);
