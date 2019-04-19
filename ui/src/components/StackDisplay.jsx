import React from 'react';
import Alert from 'react-bootstrap/Alert';

const styles = {
    display: 'flex',
    flexDirection: 'column-reverse',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
    height: '10em'
};

export class StackDisplay extends React.Component {

    render() {
        return (
            <Alert variant="info">
                <div style={styles}>
                    {this.props.stack.map(item => <div>{item}</div>)}
                </div>
            </Alert>
        );
    }
}

export default StackDisplay;
