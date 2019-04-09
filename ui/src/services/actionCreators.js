import * as actions from "./actionTypes";

const API_HOST ='http://192.168.99.104:8081';
const PREVIEW_URL = "api/preview";
const DEFINITION_URL = "api/definitions";

export const getPreview = funcs => {
  console.log(window.location);
  const uri = `${API_HOST}/${PREVIEW_URL}?${funcs.map(f => `source=${f}`).join("&")}`;
  return createThunk(uri, null, actions.PREVIEW_LOADED);
};

export const getDefinition = id => {
  const uri = `${API_HOST}/${DEFINITION_URL}/${id}`;
  return createThunk(uri, null, actions.DEFINITION_LOADED);
};

export const getDefinitionList = () => {
  const uri = `${API_HOST}/${DEFINITION_URL}`;
  return createThunk(uri, null, actions.DEFINITION_LIST_LOADED);
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

export const saveDefinition = definition => {
  const uri = `${API_HOST}/${DEFINITION_URL}`;
  const options = {
    headers: {
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify(definition)
  };
  return createThunk(uri, options, actions.DEFINITION_SAVED);
};

export const updateDefinition = payload =>{
  return dispatch =>{
    dispatch({type:actions.DEFINITION_UPDATED, payload});
  }
}

export const clearPreview = () => {
  return dispatch => {
    dispatch({ type: actions.PREVIEW_CLEARED });
  };
};

export const clearDefinition= () => {
  return dispatch => {
    dispatch({ type: actions.DEFINITION_CLEARED });
  };
};
