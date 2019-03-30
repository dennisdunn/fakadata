import { NEW_DATA } from "./actions";

const BASE_URI="http://localhost:5000/api/timeseries";

export const fetchData = key => {
  return dispatch => {
    const uri = `${BASE_URI}/${key}`;
    return fetch(uri)
      .then(response => response.json())
      .then(timeseries =>
        dispatch({ type: NEW_DATA, payload: { timeseries, key } })
      );
  };
};
