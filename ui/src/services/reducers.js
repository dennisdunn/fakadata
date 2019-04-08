import { combineReducers } from 'redux';

import * as actions from './actionTypes';

const library = (state = [], action) => {
    switch (action.type) {
        case actions.TIMESERIES_LIST_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const preview = (state = [], action) => {
    switch (action.type) {
        case actions.PREVIEW_LOADED:
            return action.payload;
        case actions.PREVIEW_CLEARED:
            return [];
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

const timeseries = (state = { id: 0, name: null, start: null, period: null, expressions: [] }, action) => {
    switch (action.type) {
        case actions.TIMESERIES_LOADED:
            return action.payload;
        case actions.TIMESERIES_UPDATED:
            return { ...state, ...action.payload };
        case actions.TIMESERIES_SAVED:
        default:
            return state;
    }
};

export default combineReducers({
    timeseries,
    operations,
    library,
    preview
});
