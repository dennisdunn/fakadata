import { combineReducers } from 'redux';

import * as actions from './actionTypes';

const defaultSequencerState = { names: [], commands: [], stack: [], data: [] };
const defaultErrorState = { isError: false, text: null };

const sequencer = (state = defaultSequencerState, action) => {
    switch (action.type) {
        case actions.SEQUENCER_COMMANDS_LOADED:
            return { ...state, commands: action.payload };
        case actions.SEQUENCER_PREVIEW_LOADED:
            return { ...state, data: action.payload.map(mv => { return { value: mv }; }) };
        case actions.SEQUENCER_NAMES_LOADED:
            return { ...state, names: action.payload.sort() };
        case actions.SEQUENCER_EVAL_SUCCESS:
            return { ...state, stack: action.payload };
        default:
            return state;
    }
};

const error = (state = defaultErrorState, action) => {
    switch (action.type) {
        case actions.SEQUENCER_ERROR:
            return { isError: true, text: action.payload };
        case actions.SEQUENCER_ERROR_CLEARED:
            return { isError: false, text: null };
        default:
            return state;
    }
}

export default combineReducers({
    sequencer,
    error
});
