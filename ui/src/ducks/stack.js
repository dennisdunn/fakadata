import * as stackService from '../services/stackService';

// Action types
export const actionTypes = {
    STACK_DUP: 'STACK_DUP',
    STACK_PUSH: 'STACK_PUSH',
    STACK_DROP: 'STACK_DROP',
    STACK_SWAP: 'STACK_SWAP',
    STACK_PICK: 'STACK_PICK',
    STACK_ROLL: 'STACK_ROLL',
    STACK_CLEAR: 'STACK_CLEAR'
};

// Action creators
export const actions = {
    push: payload => ({ type: actionTypes.STACK_PUSH, payload }),
    dup: () => ({ type: actionTypes.STACK_DUP }),
    drop: () => ({ type: actionTypes.STACK_DROP }),
    swap: () => ({ type: actionTypes.STACK_SWAP }),
    pick: () => ({ type: actionTypes.STACK_PICK }),
    roll: () => ({ type: actionTypes.STACK_ROLL }),
    clear: () => ({ type: actionTypes.STACK_CLEAR })
};

// Reducder
const reducer = (state = [], action) => {
    let stack = [...state];

    switch (action.type) {
        case actionTypes.STACK_PUSH:
            return stackService.push(stack, action.payload);
        case actionTypes.STACK_DUP:
            return stackService.dup(stack);
        case actionTypes.STACK_SWAP:
            return stackService.swap(stack);
        case actionTypes.STACK_DROP:
            return stackService.drop(stack);
        case actionTypes.STACK_PICK:
            if (!isNaN(Number(stack[0]))) {
                const idx = Number(stack[0]);
                stack.shift();
                stack = stackService.pick(stack, idx);
            }
            return stack;
        case actionTypes.STACK_ROLL:
            if (!isNaN(Number(stack[0]))) {
                const idx = Number(stack[0]);
                stack.shift();
                stack = stackService.roll(stack, idx);
            }
            return stack;
        case actionTypes.STACK_CLEAR:
            return [];
        default:
            return state;
    }
}

export default reducer;
