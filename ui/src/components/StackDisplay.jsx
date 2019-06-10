import React from 'react';
import LineChart from '../components/LineChart';

const styles = {
    stack: {
        display: 'flex',
        flexDirection: 'column'
    }
};

const toComponent = (item, idx) => {
    if (Array.isArray(item)) {
        const data = item.map((y, x) => ({ x, y }));
        const svgWidth=800;
        const svgHeight=100;
        return <LineChart data={data} svgWidth={svgWidth} svgHeight={svgHeight} />
    }
    return <div key={idx}>{item.toString()}</div>;
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
