import * as actions from "./actionTypes";

const BASE_URI = "http://localhost:5000/api/timeseries";

const handleErrors = response => {
  if (!response.ok) {
    throw Error(response.statusText);
  }
  return response;
};

export const fetchTimeseries = key => {
  return dispatch => {
    dispatch({ type: actions.INIT_GET_TIMESERIES });
    const uri = `${BASE_URI}/${key}`;
    return fetch(uri)
      .then(handleErrors)
      .then(response => response.json())
      .then(timeseries =>
        dispatch({
          type: actions.OK_GET_TIMESERIES,
          payload: { timeseries, key }
        })
      )
      .catch(error =>
        dispatch({ type: actions.ERR_GET_TIMESERIES, payload: { error } })
      );
  };
};

export const fetchMenu = () => {
  return dispatch => {
    dispatch({ type: actions.INIT_GET_MENU });
    const uri = `${BASE_URI}`;
    return fetch(uri)
      .then(handleErrors)
      .then(response => response.json())
      .then(items =>
        dispatch({
          type: actions.OK_GET_MENU,
          payload: items
        })
      )
      .catch(error =>
        dispatch({ type: actions.ERR_GET_MENU, payload: { error } })
      );
  };
};
