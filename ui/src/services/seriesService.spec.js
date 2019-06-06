import * as series from './seriesService';

const a = [0, 1, 2, 3, 4];
const b = [5, 6, 7, 8, 9];

it("should sum two series", () => {
    const ans = series.sum(a, b);
    expect(ans).toStrictEqual([5, 7, 9, 11, 13]);
});

it("should get the mean of a series", () => {
    const ans = series.mean(a);
    expect(ans).toBe(2);
});

it("should get the max of a series", () => {
    const ans = series.max(a);
    expect(ans).toBe(4);
});

it("should get the min of a series", () => {
    const ans = series.min(a);
    expect(ans).toBe(0);
});

it("should normalize a series", () => {
    const ans = series.normalize(a);
    expect(ans).toStrictEqual([0, 0.25, 0.5, 0.75, 1]);
});

it("should standardize a series", () => {
    const ans = series.standardize(a);
});

it("should get a normalized linear series", () => {
    const ans = series.normalize(series.linear(5));
    expect(ans).toStrictEqual([0, 0.25, 0.5, 0.75, 1]);
});

it("should get a unit series", () => {
    const ans = series.unit(5);
    expect(ans).toStrictEqual([1, 1, 1, 1, 1]);
});

it("should get a cycle series", () => {
    const ans = series.cycle(1000, 10, 50);
});
