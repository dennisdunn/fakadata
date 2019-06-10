import * as series from '../services/seriesService';
import * as stackService from '../services/stackService';
import { actionTypes as stackActions } from './stack';

const DEFAULT_SIZE = 512;

// Action types
export const actionTypes = {
    SERIES_CYCLE: 'SERIES_CYCLE'
}

// Action creators
export const actions = {
    linear: () => ({ type: stackActions.STACK_PUSH, payload: series.linear(DEFAULT_SIZE) }),
    zero: () => ({ type: stackActions.STACK_PUSH, payload: series.zero(DEFAULT_SIZE) }),
    unit: () => ({ type: stackActions.STACK_PUSH, payload: series.unit(DEFAULT_SIZE) }),
    noise: () => ({ type: stackActions.STACK_PUSH, payload: series.uniform(DEFAULT_SIZE) }),
    cycle: () => ({ type: actionTypes.SERIES_CYCLE })
};

// Reducer
export const reducer = (state = [], action) => {
    let stack = [...state];

    switch (action.type) {
        case actionTypes.SERIES_CYCLE:
            if (isNaN(Number(stack[0]))) break;
            const sample_rate = stackService.pop(stack);
            const cycle = series.cycle(sample_rate, DEFAULT_SIZE);
            console.log(cycle);
            stackService.push(stack, cycle);
            return stack;
        default:
            return state;
    }
    return state;
}

export default reducer;
