import { ListItem } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import List from '@material-ui/core/List';
import React from 'react';
import * as actions from '../actions/stackActionCreators';
import { connect } from 'react-redux';

export const StackControls = props => {
    return (
        <List component="nav">
            <ListItem>
                <Button variant='contained' onClick={props.swap} style={{ width: '100%' }}>Swap</Button>
            </ListItem>
            <ListItem>
                <Button variant='contained' onClick={props.drop} style={{ width: '100%' }}>Drop</Button>
            </ListItem>
            <ListItem>
                <Button variant='contained' onClick={props.pick} style={{ width: '100%' }}>Pick</Button>
            </ListItem>
            <ListItem>
                <Button variant='contained' onClick={props.roll} style={{ width: '100%' }}>Roll</Button>
            </ListItem>
            <ListItem>
                <Button variant='contained' onClick={props.clear} style={{ width: '100%' }}>Clear</Button>
            </ListItem>
        </List>
    );
};

export default connect(null, actions)(StackControls);
