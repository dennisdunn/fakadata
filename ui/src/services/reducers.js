import { combineReducers } from 'redux';
import { getTimeseriesList } from './actionCreators';
import * as actions from './actionTypes';

const library = (state = [], action) => {
    switch (action.type) {
        case actions.TIMESERIES_LIST_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const defaultPreview=[];
const preview = (state = defaultPreview, action) => {
    switch (action.type) {
        case actions.PREVIEW_LOADED:
            return action.payload;
        case actions.PREVIEW_CLEARED:
            return defaultPreview;
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

const defaultTimeseries = { id: 0, name: '', start: '', period: '', expressions: [] };
const timeseries = (state = defaultTimeseries, action) => {
    switch (action.type) {
        case actions.TIMESERIES_LOADED:
            return action.payload;
        case actions.TIMESERIES_UPDATED:
            return { ...state, ...action.payload };
        case actions.TIMESERIES_CLEARED:
            return defaultTimeseries ;
        case actions.TIMESERIES_SAVED:
            return state;
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
