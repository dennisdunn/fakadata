import * as actions from './actionTypes';

export const generateData = funcs => {
    return dispatch => {
        dispatch({ type: actions.OPERATION_STARTED });
        try {
            // gen data & data_loaded
            const data = [];
            const f = new Function("x", "return " + funcs.join("+") + ";");
            for (let x = 0; x < 100; x++) {
                data.push({ mv: f(x) });
            }
            dispatch({ type: actions.DATA_LOADED, payload: data });
            dispatch({ type: actions.OPERATION_COMPLETE });
        } catch (error) {
            dispatch({ type: actions.OPERATION_ERRORED, payload: error });
        }
    }
}
