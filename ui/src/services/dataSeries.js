export const zip = (a_arr, b_arr, f) => a_arr.map((x, idx) => f(x, b_arr[idx]));

export const sum = (a_arr, b_arr) => zip(a_arr, b_arr, (x, y) => x + y);

export const diff = (a_arr, b_arr) => zip(a_arr, b_arr, (x, y) => x - y);

export const product = (a_arr, b_arr) => zip(a_arr, b_arr, (x, y) => x * y);

export const quotient = (a_arr, b_arr) => zip(a_arr, b_arr, (x, y) => x / y);

export const min = a_arr => a_arr.reduce((prev, current) => current < prev ? current : prev, a_arr[0]);

export const max = a_arr => a_arr.reduce((prev, current) => current > prev ? current : prev, a_arr[0]);

export const mean = a_arr => (a_arr.reduce((prev, current) => prev + current, 0)) / a_arr.length;

export const stddev = (a_arr, arr_mean) => {
    arr_mean = arr_mean || mean(a_arr);
    const sqrError = a_arr.map(x => Math.pow(x - arr_mean, 2));
    const meanSqrError = mean(sqrError);
    return Math.sqrt(meanSqrError);
}

export const normalize = a_arr => {
    const min_val = min(a_arr);
    const range = max(a_arr) - min_val;
    return a_arr.map(x => (x - min_val) / range);
}

export const standardize = a_arr => {
    const arr_mean = mean(a_arr);
    const arr_stddev = stddev(a_arr, arr_mean);
    return a_arr.map(x => (x - arr_mean) / arr_stddev);
}

export const zero = (n = 1024) => [...Array(n)].map(() => 0);

export const unit = (n = 1024) => [...Array(n)].map(() => 1);

export const uniform = (n = 1024) => [...Array(n)].map(() => Math.random());

export const linear = (n = 1024) => [...Array(n).keys()];

export const cycle = (n, sample_rate) => {
    const a_cycle = [...Array(sample_rate).keys()].map(x => Math.sin(2 * Math.PI * (x / sample_rate)));
    return [...Array(n).keys()].map(x => a_cycle[x % sample_rate]);
}

export const clone = a_arr => a_arr.map(x => x);