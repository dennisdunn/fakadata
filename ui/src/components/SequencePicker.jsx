import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

export class SequencePicker extends React.Component {

    render() {
        const items = this.props.items
            .sort()
            .map(item => <Dropdown.Item key={item} eventKey={item}>{item}</Dropdown.Item>);
            
        return (
            <Dropdown onSelect={this.props.onSelect} size='sm' drop='left'>
                <Dropdown.Toggle variant="success">Sequence</Dropdown.Toggle>
                <Dropdown.Menu>
                    {items}
                </Dropdown.Menu>
            </Dropdown>
        );
    }
}

export default SequencePicker;
