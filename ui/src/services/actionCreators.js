import * as actions from "./actionTypes";

const API_HOST = `http://${window.location.hostname}:8081`;
const SEQUENCE_URL = "api/sequence";

export const getSequence = src => {
  const uri = `${API_HOST}/${SEQUENCE_URL}`;
  const options = {
    headers: {
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify(src)
  };
  return createThunk(uri, options, actions.SEQUENCE_LOADED);
};

export const getSequenceList = () => {
  const uri = `${API_HOST}/${SEQUENCE_URL}`;
  return createThunk(uri, null, actions.SEQUENCE_LIST_LOADED);
};

export const setSource = text => {
  return dispatch => {
    dispatch({ type: actions.SOURCE_SET, payload: text });
  }
}

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
