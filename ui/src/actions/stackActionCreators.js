import * as actions from './stackActions';

export const push = payload => ({ type: actions.STACK_PUSH, payload });

export const drop = () => ({ type: actions.STACK_DROP });

export const swap = () => ({ type: actions.STACK_SWAP });

export const pick = payload => ({ type: actions.STACK_PICK, payload });

export const roll = payload => ({ type: actions.STACK_ROLL, payload });

export const clear = () => ({ type: actions.STACK_CLEAR });
