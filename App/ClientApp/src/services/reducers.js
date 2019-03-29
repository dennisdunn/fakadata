import { combineReducers } from 'react-redux';

export const rootReducer = combineReducers({
    series
});

const series = (state = { data: [], key: '' }, action) => {
    switch (action.type) {
        case 'FETCH_SUCCESS':
            return { ...action.payload };
        default:
            return state;
    }
}
