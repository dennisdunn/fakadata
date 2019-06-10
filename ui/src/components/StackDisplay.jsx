import React from 'react';
import LineChart from '../components/LineChart';
import * as seriesService from '../services/seriesService';

const styles = {
    stack: {
        display: 'flex',
        flexDirection: 'column'
    }
};

const getHeight = arr =>{
    const min = seriesService.min(arr);
    const max = seriesService.max(arr);
    const range = max-min;
    return Math.sign(range) * 50 * range;
}

const toComponent = (item, idx) => {
    if (Array.isArray(item)) {
        const data = item.map((y, x) => ({ x, y }));
        const svgWidth=800;
        const svgHeight=getHeight(item);
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
