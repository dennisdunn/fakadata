import * as actions from "./actionTypes";

const API_HOST = `http://${window.location.hostname}:8080`;
const PREVIEW_URL = "api/preview";
const SEQUENCE_URL = "api/sequence";

export const getPreview = funcs => {
  const uri = `${API_HOST}/${PREVIEW_URL}?${funcs.map(f => `source=${f}`).join("&")}`;
  return createThunk(uri, null, actions.PREVIEW_LOADED);
};

export const getDefinition = id => {
  const uri = `${API_HOST}/${SEQUENCE_URL}/${id}`;
  return createThunk(uri, null, actions.DEFINITION_LOADED);
};

export const getDefinitionList = () => {
  const uri = `${API_HOST}/${SEQUENCE_URL}`;
  return createThunk(uri, null, actions.DEFINITION_LIST_LOADED);
};

export const appendSource = text => {
  return dispatch => {
    dispatch({ type: actions.SOURCE_APPEND, payload: text });
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

export const saveDefinition = definition => {
  const uri = `${API_HOST}/${SEQUENCE_URL}`;
  const options = {
    headers: {
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify(definition)
  };
  return createThunk(uri, options, actions.DEFINITION_SAVED);
};

export const updateDefinition = payload => {
  return dispatch => {
    dispatch({ type: actions.DEFINITION_UPDATED, payload });
  }
}

export const clearPreview = () => {
  return dispatch => {
    dispatch({ type: actions.PREVIEW_CLEARED });
  };
};

export const clearDefinition = () => {
  return dispatch => {
    dispatch({ type: actions.DEFINITION_CLEARED });
  };
};
