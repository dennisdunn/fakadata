import { combineReducers } from "redux";
import { ERR_DATA, NEW_DATA } from "./actions";

export const rootReducer = combineReducers({
  data
});

function initialData() {
  return { timeseries: [], key: "" };
}

function data(state = initialData(), action) {
  console.log(action);
  switch (action.type) {
    case ERR_DATA:
    case NEW_DATA:
      return action.payload;
    default:
      return state;
  }
}

export default rootReducer;
