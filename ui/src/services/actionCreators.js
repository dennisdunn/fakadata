import * as actions from "./actionTypes";

const ENGINE_URI = "http://localhost:8080/api/eval";
const CONFIG_URI = "http://localhost:8080/api/timeseries";

export const getPreview = funcs => {
  const uri = `${ENGINE_URI}?${funcs.map(f => `source=${f}`).join("&")}`;
  return createThunk(uri, null, actions.PREVIEW_LOADED);
};

export const getTimeseries = id => {
  const uri = `${CONFIG_URI}/${id}`;
  return createThunk(uri, null, actions.TIMESERIES_LOADED);
};

export const getTimeseriesList = () => {
  const uri = `${CONFIG_URI}`;
  return createThunk(uri, null, actions.TIMESERIES_LIST_LOADED);
};

export const createThunk = (uri, options, type) => {
  return dispatch => {
    dispatch({ type: actions.OPERATION_STARTED });
    fetch(uri, options)
      .then(resp => resp.json())
      .then(payload => dispatch({ type, payload }))
      .then(() => dispatch({ type: actions.OPERATION_COMPLETE }))
      .catch(error =>
        dispatch({ type: actions.OPERATION_ERRORED, payload: error, error: true })
      );
  };
};

export const saveTimeseries = timeseries => {
  const uri = `${CONFIG_URI}`;
  const options = {
    headers: {
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify(timeseries)
  };
  return createThunk(uri, options, actions.TIMESERIES_SAVED);
};

export const updateTimeseries = payload =>{
  return dispatch =>{
    dispatch({type:actions.TIMESERIES_UPDATED, payload});
  }
}

export const clearPreview = () => {
  return dispatch => {
    dispatch({ type: actions.PREVIEW_CLEARED });
  };
};

export const clearTimeseries= () => {
  return dispatch => {
    dispatch({ type: actions.TIMESERIES_CLEARED });
  };
};
