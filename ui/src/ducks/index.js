import stack from './stack';
import series from './series';

const reduceReducers = (...reducers) => {
    return (previous, current) =>
        reducers.reduce(
            (p, r) => r(p, current),
            previous
        );
};

export default reduceReducers(
    stack,
    series
);
