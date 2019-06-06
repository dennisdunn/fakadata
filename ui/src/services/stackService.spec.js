import * as stack from "./stackService";

it("should push some things", () => {
    let ans = stack.push([], "a");
    ans = stack.push(ans, "b");
    expect(ans).toStrictEqual(["b", "a"]);
});

it("should drop some things", () => {

    let ans = ["a", "b", "c", "d"];
    ans = stack.drop(ans);
    expect(ans).toStrictEqual(["b", "c", "d"]);
});

it("should swap some things", () => {

    let ans = ["a", "b", "c", "d"];
    ans = stack.swap(ans);
    expect(ans).toStrictEqual(["b", "a", "c", "d"]);
});

it("should pick some things", () => {

    let ans = ["a", "b", "c", "d"];
    ans = stack.pick(ans,2);
    expect(ans).toStrictEqual(["c", "a", "b", "d"]);
});

it("should pick roll things", () => {

    let ans = ["a", "b", "c", "d"];
    ans = stack.roll(ans,2);
    expect(ans).toStrictEqual(["c", "d", "a", "b"]);
});

