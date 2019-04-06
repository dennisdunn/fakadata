import * as actions from "./actionTypes";

const ENGINE_URI = "http://localhost:8080/api/eval";
const CONFIG_URI = "http://localhost:8080/api/timeseries";

export const getPreview = funcs => {
  const uri = ENGINE_URI + "?" +funcs.map(f=>`source=${f}`).join("&");
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
