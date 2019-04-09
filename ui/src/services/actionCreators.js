import * as actions from "./actionTypes";

const API_HOST ='http://192.168.99.104:8081';
const PREVIEW_URL = "api/preview";
const DEFINITION_URL = "api/definitions";
const TIMESERIES_URL = "api/timeseries";

export const getPreview = funcs => {
  console.log(window.location);
  const uri = `${API_HOST}/${PREVIEW_URL}?${funcs.map(f => `source=${f}`).join("&")}`;
  return createThunk(uri, null, actions.PREVIEW_LOADED);
};

export const getTimeseries = id => {
  const uri = `${API_HOST}/${TIMESERIES_URL}/${id}`;
  return createThunk(uri, null, actions.TIMESERIES_LOADED);
};

export const getTimeseriesList = () => {
  const uri = `${API_HOST}/${DEFINITION_URL}`;
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
  const uri = `${API_HOST}/${DEFINITION_URL}`;
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
