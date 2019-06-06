import * as actions from '../actions/stackActions';
import * as stackService from '../services/stackService';

const stackReducer = (state = [], action) => {
    let stack = [...state];
    switch (action.type) {
        case actions.STACK_PUSH:
            return stackService.push(stack, action.payload);
        case actions.STACK_DROP:
            return stackService.drop(stack);
        case actions.STACK_SWAP:
            return stackService.swap(stack);
        case actions.STACK_PICK:
            if (Number(stack[0] != NaN)) {
                const idx = stackService.pop(stack);
                stack = stackService.pick(stack, idx);
            }
            return stack;
        case actions.STACK_ROLL:
            if (Number(stack[0] != NaN)) {
                const idx = stackService.pop(stack);
                stack = stackService.roll(stack, idx);
            }
            return stack;
        case actions.STACK_CLEAR:
            return [];
        default:
            return state;
    }
}

export default stackReducer;
