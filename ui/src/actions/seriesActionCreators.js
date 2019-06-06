import * as actions from './stackActions';
import * as series from '../services/seriesService';

const size = 512;

export const linear = () => ({ type: actions.STACK_PUSH, payload: series.linear(size) });
export const zero = () => ({ type: actions.STACK_PUSH, payload: series.zero(size) });
export const unit = () => ({ type: actions.STACK_PUSH, payload: series.unit(size) });
export const noise = () => ({ type: actions.STACK_PUSH, payload: series.uniform(size) });
