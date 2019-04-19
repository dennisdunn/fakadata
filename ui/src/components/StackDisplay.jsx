import React from 'react';

const styles = {
    flexDirection: 'column',
    justifyContent: 'flex-end'
};

export class StackDisplay extends React.Component {

    render() {
        return (
            <div style={styles}>
                {this.props.stack.reverse().map(item => <div>{item}</div>)}
            </div>
        );
    }
}

export default StackDisplay;
