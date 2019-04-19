import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

export class SequencePicker extends React.Component {

    render() {
        const items = this.props.items
            .sort()
            .map((item, idx) => <Dropdown.Item key={idx} eventKey={item}>{item}</Dropdown.Item>);
            
        return (
            <Dropdown onSelect={this.props.onSelect} size='sm'>
                <Dropdown.Toggle variant="success">Sequence</Dropdown.Toggle>
                <Dropdown.Menu>
                    {items}
                </Dropdown.Menu>
            </Dropdown>
        );
    }
}

export default SequencePicker;
