import * as actions from "./actionTypes";

const ENGINE_URI = "http://localhost:5000/api/engine";
const CONFIG_URI = "http://localhost:5000/api/config";

export const getPreview = funcs => {
  const src = funcs.join("+");
  const uri = ENGINE_URI + "?source=" + src;
  return dispatch => {
    dispatch({ type: actions.OPERATION_STARTED });
    fetch(uri)
      .then(resp => resp.json())
      .then(data => dispatch({ type: actions.DATA_LOADED, payload: data }))
      .then(() => dispatch({ type: actions.OPERATION_COMPLETE }))
      .catch(error =>
        dispatch({ type: actions.OPERATION_ERRORED, payload: error })
      );
  };
};

export const clearData = () => {
  return dispatch => {
    dispatch({ type: actions.DATA_CLEARED });
  };
};
