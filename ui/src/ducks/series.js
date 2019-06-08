import { actionTypes } from './stack';
import * as series from '../services/seriesService';

const DEFAULT_SIZE = 512;

// Action creators
export const actions = {
    linear: () => ({ type: actionTypes.STACK_PUSH, payload: series.linear(DEFAULT_SIZE) }),
    zero: () => ({ type: actionTypes.STACK_PUSH, payload: series.zero(DEFAULT_SIZE) }),
    unit: () => ({ type: actionTypes.STACK_PUSH, payload: series.unit(DEFAULT_SIZE) }),
    noise: () => ({ type: actionTypes.STACK_PUSH, payload: series.uniform(DEFAULT_SIZE) })
};
