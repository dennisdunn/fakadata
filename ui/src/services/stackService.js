export const push = (stack, item) => {
    stack.unshift(item);
    return stack;
}

export const pop = stack => stack.shift();

export const dup = stack => {
    if (Array.isArray(stack[0])) {
        stack.push(stack[0].map(x => x));
    } else {
        push(stack, stack[0]);
    }
    return stack;
}

export const drop = stack => {
    if (stack.length > 0) {
        stack.shift();
    }
    return stack;
}

export const swap = stack => pick(stack, 1);

export const pick = (stack, idx) => {
    if (stack.length >= idx + 1) {
        const item = stack[idx];
        stack.splice(idx, 1);
        stack.unshift(item);
    }
    return stack;
}

export const roll = (stack, n) => {
    for (let i = 0; i < n; i++) {
        stack.unshift(stack.pop());
    }
    return stack;
}

export const clear = stack => {
    stack.length = 0;
    return stack;
};
