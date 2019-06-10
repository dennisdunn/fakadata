import * as stackService from '../services/stackService';
import * as mathService from '../services/mathService';

export const actionTypes = {
    MATH_SUM: 'MATH_SUM',
    MATH_DIFF: 'MATH_DIFF',
    MATH_PRODUCT: 'MATH_PRODUCT',
    MATH_QUOTIENT: 'MATH_QUOTIENT'
};

export const actions = {
    sum: () => ({ type: actionTypes.MATH_SUM }),
    diff: () => ({ type: actionTypes.MATH_DIFF }),
    product: () => ({ type: actionTypes.MATH_PRODUCT }),
    quotient: () => ({ type: actionTypes.MATH_QUOTIENT }),
};

export const reducer = (state = [], action) => {
    const stack = [...state];
    if (stack.length >= 2) {
        const a = stackService.pop(stack);
        const b = stackService.pop(stack);
        switch (action.type) {
            case actionTypes.MATH_SUM: {
                console.log(action.type);
                const ans = mathService.sum(a, b);
                stackService.push(stack, ans);
                return stack;
            }
            case actionTypes.MATH_DIFF: {
                const ans = mathService.diff(a, b);
                stackService.push(stack, ans);
                return stack;
            }
            case actionTypes.MATH_PRODUCT: {
                const ans = mathService.product(a, b);
                stackService.push(stack, ans);
                return stack;
            }
            case actionTypes.MATH_QUOTIENT: {
                const ans = mathService.quotient(a, b);
                stackService.push(stack, ans);
                return stack;
            }
            default:
                return state;
        }
    }
    return state;
}

export default reducer;
