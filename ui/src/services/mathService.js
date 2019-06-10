import * as series from './seriesService';

export const sum = (a, b) => {
    if (Array.isArray(a) && Array.isArray(b)) {
        return series.sum(a, b);
    } else if (!isNaN(Number(a)) && Array.isArray(b)) {
        return b.map(x => x + a);
    } else {
        return a + b;
    }
};

export const diff = (a, b) => {
    if (Array.isArray(a) && Array.isArray(b)) {
        return series.diff(a, b);
    } else if (!isNaN(Number(a)) && Array.isArray(b)) {
        return b.map(x => x - a);
    } else {
        return a - b;
    }
};

export const product = (a, b) => {
    if (Array.isArray(a) && Array.isArray(b)) {
        return series.product(a, b);
    } else if (!isNaN(Number(a)) && Array.isArray(b)) {
        return b.map(x => x * a);
    } else {
        return a * b;
    }
};

export const quotient = (a, b) => {
    if (Array.isArray(a) && Array.isArray(b)) {
        return series.quotient(a, b);
    } else if (!isNaN(Number(a)) && Array.isArray(b)) {
        return b.map(x => x / a);
    } else {
        return a / b;
    }
};
