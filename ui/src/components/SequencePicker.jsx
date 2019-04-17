import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

export class SequencePicker extends React.Component {

    render() {
        const items = this.props.items.map(item => <Dropdown.Item eventKey={item}>{item}</Dropdown.Item>);
        return (
            <Dropdown onSelect={this.props.onSelect}>
                <Dropdown.Toggle variant="success">Sequence</Dropdown.Toggle>
                <Dropdown.Menu>
                    {items}
                </Dropdown.Menu>
            </Dropdown>
        );
    }
}

export default SequencePicker;
