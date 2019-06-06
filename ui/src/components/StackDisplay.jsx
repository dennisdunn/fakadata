import React from 'react';
import { isNumber } from 'util';
import LineChart from 'react-svg-line-chart';

const styles = {
    stack: {
        display: 'flex',
        flexDirection: 'column-reverse'
    }
};

const toComponent = item => {
    if (Array.isArray(item) && isNumber(item[0].x * item[0].y)) {
        return <LineChart data={item}
            pointsVisible={false}
            gridVisible={false}
            axisVisible={false}
            labelsVisible={false}
            pathWidth={1}
            pathColor='slateblue' />
    }
    return <div>{item.toString()}</div>;
};

export const StackDisplay = ({ stack, ...rest }) => {
    const children = stack.map(toComponent);
    
    return (
        <div {...rest} className={styles.stack}>
            {children}
        </div>
    );
};

export default StackDisplay;
