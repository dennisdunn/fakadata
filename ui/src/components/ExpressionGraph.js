import React from 'react';
import { ResponsiveContainer } from 'recharts';
import { LineChart } from 'recharts';
import { Line } from 'recharts';

const styles = {
    root: {
        flexGrow: 1
    }
}

export const ExpressionGraph = props => {
    const { data } = props;

    return (
        <div style={styles.root}>
            <ResponsiveContainer height={450} width="70%">
                <LineChart data={data}>
                    <Line type="monotone" dataKey="value" stroke="#8884d8" dot={false} />
                </LineChart>
            </ResponsiveContainer>
        </div>
    );
};

export default ExpressionGraph;
