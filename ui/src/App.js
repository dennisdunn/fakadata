import AppBar from '@material-ui/core/AppBar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import TextField from '@material-ui/core/TextField';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import React from 'react';
import { connect } from 'react-redux';
import { push } from './actions/stackActionCreators';
import { StackControls, StackDisplay, SeriesControls } from './components';

export const App = props => {
  const [input, setInput] = React.useState('');
  return (
    <div>
      <CssBaseline />
      <AppBar position='fixed' style={{ zIndex: 2000 }}>
        <Toolbar>
          <Typography variant='h6'>Fakadata</Typography>
        </Toolbar>
      </AppBar>
      <Drawer variant="permanent">
        <div style={{ marginTop: '5em' }}>
          <StackControls />
          <SeriesControls />
        </div>
      </Drawer>
      <main style={{ marginTop: '5em', marginLeft: '10em', marginRight: '5em' }}>
        <TextField value={input} onChange={e => setInput(e.target.value)} />
        <Button onClick={() => { props.push(input); setInput('') }}>Enter</Button>
        <StackDisplay stack={props.stack} style={{ marginTop: '2em' }} />
      </main>
    </div>
  );
};

export default connect(({ stack }) => ({ stack }), { push })(App);
