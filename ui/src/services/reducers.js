import { combineReducers } from "redux";
import * as actions from "./actionTypes";

function initialTimeseriesData() {
  return {
    timeseries: [],
    name: "",
    isFetching: false,
    error: undefined
  };
}

function initialMenuData() {
  return {
    items: [],
    isFetching: false,
    error: undefined
  };
}

function timeseries(state = initialTimeseriesData(), action) {
  switch (action.type) {
    case actions.INIT_GET_TIMESERIES:
      return { ...state, isFetching: true, error: undefined };
    case actions.OK_GET_TIMESERIES:
      return { ...action.payload, isFetching: false, error: undefined };
    case actions.ERR_GET_TIMESERIES:
      console.log(action.payload);
      return {
        ...state,
        error: action.payload,
        isFetching: false
      };
    default:
      return state;
  }
}

const menu = (state = initialMenuData(), action) => {
  switch (action.type) {
    case actions.INIT_GET_MENU:
      return { items: [], isFetching: true, error: undefined };
    case actions.OK_GET_MENU:
      return { items: action.payload, isFetching: false, error: undefined };
    case actions.ERR_GET_MENU:
      console.log(action.payload);
      return {
        items: [],
        error: action.payload,
        isFetching: false
      };
    default:
      return state;
  }
};

export const rootReducer = combineReducers({
  timeseries,
  menu
});

export default rootReducer;
