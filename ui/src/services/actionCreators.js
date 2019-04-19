import * as actions from "./actionTypes";

const API_HOST = `http://${window.location.hostname}:8080`;
const SEQUENCE_URL = "api/sequencer";

export const evalSequencerCommands = commands => {
  const uri = `${API_HOST}/${SEQUENCE_URL}/eval`;
  const options = {
    headers: {
      'Content-Type': 'application/json'
    },
    method: 'POST',
    body: JSON.stringify(commands)
  };
  return createThunk(uri, options, actions.SEQUENCER_EVAL_SUCCESS);
};

export const getSequencePreview = () => {
  const uri = `${API_HOST}/${SEQUENCE_URL}`;
  return createThunk(uri, null, actions.SEQUENCER_PREVIEW_LOADED);
};

export const getNamedSequences = () => {
  const uri = `${API_HOST}/${SEQUENCE_URL}/names`;
  return createThunk(uri, null, actions.SEQUENCER_NAMES_LOADED);
};

export const getSequencerCommands = () => {
  const uri = `${API_HOST}/${SEQUENCE_URL}/operations`;
  return createThunk(uri, null, actions.SEQUENCER_COMMANDS_LOADED);
};

export const createThunk = (uri, options, type) => {
  return dispatch => {
    dispatch({ type: actions.SEQUENCER_ERROR_CLEARED});
    fetch(uri, options)
      .then(resp => resp.json())
      .then(payload => dispatch({ type, payload }))
      .catch(error =>
        dispatch({ type: actions.SEQUENCER_ERROR, payload: error})
      );
  };
};
