import * as actions from './stackActions';

export const push = payload => ({ type: actions.STACK_PUSH, payload });

export const drop = () => ({ type: actions.STACK_DROP });

export const swap = () => ({ type: actions.STACK_SWAP });

export const pick = () => ({ type: actions.STACK_PICK });

export const roll = () => ({ type: actions.STACK_ROLL });

export const clear = () => ({ type: actions.STACK_CLEAR });
