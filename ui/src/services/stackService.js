export const push = (stack, item) => {
    const s = [...stack];
    s.unshift(item);
    return s;
}

export const pop = stack => stack.shift();

export const drop = stack => {
    const s = [...stack];
    if (s.length > 0) {
        s.shift();
    }
    return s;
}

export const swap = stack => pick(stack, 1);

export const pick = (stack, idx) => {
    const s = [...stack];
    if (s.length >= idx + 1) {
        const item = s[idx];
        s.splice(idx, 1);
        s.unshift(item);
    }
    return s;
}

export const roll = (stack, n) => {
    const s = [...stack];
    for (let i = 0; i < n; i++) {
        s.unshift(s.pop());
    }
    return s;
}

export const clear = _ => [];
