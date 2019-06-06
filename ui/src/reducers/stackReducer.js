import * as actions from '../actions/stackActions';

const stackReducer = (state = [], action) => {
    var stack = [...state];
    switch (action.type) {
        case actions.STACK_PUSH:
            stack.unshift(action.payload);
            return stack;
        case actions.STACK_DROP:
            stack.shift();
            return stack;
        case actions.STACK_SWAP:
            stack.unshift(stack[1]);
            return stack;
        case actions.STACK_PICK:
            stack.unshift(stack[action.payload - 1]);
            return stack;
        case actions.STACK_ROLL:
            for (let i = 0; i < stack.length; i++) {
                stack.push(stack[0]);
            }
            return stack;
        case actions.STACK_CLEAR:
            return [];
        default:
            return state;
    }
}

export default stackReducer;
