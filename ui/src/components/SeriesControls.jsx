import Button from '@material-ui/core/Button';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import React from 'react';
import { connect } from 'react-redux';
import { actions } from '../ducks/series';

export const SeriesControls = props => {
    return (
        <List component='nav'>
            <ListItem>
                <Button onClick={props.linear} style={{ width: '100%' }}>Linear</Button>
            </ListItem>
            <ListItem>
                <Button onClick={props.noise} style={{ width: '100%' }}>Noise</Button>
            </ListItem>
            <ListItem>
                <Button onClick={props.cycle} style={{ width: '100%' }}>Cyclic</Button>
            </ListItem>
        </List>
    );
}

export default connect(null, actions)(SeriesControls);
