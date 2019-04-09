import React from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

export class DefinitionList extends React.Component {

    render() {
        const items = this.props.items.map(item => <Dropdown.Item eventKey={item.value}>{item.label}</Dropdown.Item>);
        return (
            <Dropdown onSelect={this.props.onSelect}>
                <Dropdown.Toggle variant="success">Timeseries</Dropdown.Toggle>
                <Dropdown.Menu>
                    <Dropdown.Item eventKey={0}>New</Dropdown.Item>
                    <Dropdown.Divider />
                    {items}
                </Dropdown.Menu>
            </Dropdown>
        );
    }
}

export default DefinitionList;
