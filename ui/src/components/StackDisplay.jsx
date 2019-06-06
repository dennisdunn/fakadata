import React from 'react';
import { isNumber } from 'util';
import LineChart from 'react-svg-line-chart';

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

export const StackDisplay = props => {
    const { stack, ...rest } = props;
    const children = stack.map(toComponent);
    return (
        <div {...rest} style={{ display: 'flex', flexDirection: 'column-reverse' }}>
            {children}
        </div>
    );
};

export default StackDisplay;
