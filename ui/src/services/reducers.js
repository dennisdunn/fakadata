import { combineReducers } from 'redux';

import * as actions from './actionTypes';

const library = (state = [], action) => {
    switch (action.type) {
        case actions.DEFINITION_LIST_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const defaultPreview = [];
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

const defaultDefinition = { id: 0, name: '', start: '1970-01-01', period: '00:01:00:00', expressions: [] };
const definitions = (state = defaultDefinition, action) => {
    switch (action.type) {
        case actions.DEFINITION_LOADED:
            return action.payload;
        case actions.DEFINITION_UPDATED:
            return { ...state, ...action.payload };
        case actions.DEFINITION_CLEARED:
            return { ...defaultDefinition };
        case actions.DEFINITION_SAVED:
        default:
            return state;
    }
};

const source = (state = '', action) => {
    switch (action.type) {
        case actions.SOURCE_APPEND:
            return `${state}\n${action.payload}`;
        default:
            return state;
    }
}

export default combineReducers({
    definitions,
    operations,
    library,
    preview,
    source
});
