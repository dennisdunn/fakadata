import { combineReducers } from 'redux';

import * as actions from './actionTypes';

const library = (state = ['Math.pow(x,2)'], action) => {
    switch (action.type) {
        case actions.LIBRARY_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const data = (state = [], action) => {
    switch (action.type) {
        case actions.DATA_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const operations = (state = { isPending: false, error: undefined }, action) => {
    switch (action.type) {
        case actions.OPERATION_STARTED:
            return { isPending: true };
        case actions.OPERATION_COMPLETE:
            return { isPending: false };
        case actions.OPERATION_ERRORED:
            return { pending: false, error: action.payload };
        default:
            return state;
    }
};

export default combineReducers({
    operations,
    library,
    data
});
