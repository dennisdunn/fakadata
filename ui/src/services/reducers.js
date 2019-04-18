import { combineReducers } from 'redux';

import * as actions from './actionTypes';

const options = (state = [], action) => {
    switch (action.type) {
        case actions.SEQUENCE_LIST_LOADED:
            return action.payload;
        default:
            return state;
    }
};

const defaultPreview = [];
const preview = (state = defaultPreview, action) => {
    switch (action.type) {
        case actions.SEQUENCE_LOADED:
            const values = action.payload.map(n => { return { value: n }; });
            return values;
        default:
            return state;
    }
};

const source = (state = '', action) => {
    switch (action.type) {
        case actions.SOURCE_SET:
            return action.payload;
        default:
            return state;
    }
}

export default combineReducers({
    options,
    preview,
    source
});
