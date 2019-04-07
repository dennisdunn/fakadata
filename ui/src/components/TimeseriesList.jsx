import React from "react";
import Dropdown from "react-bootstrap/Dropdown";

export class TimeseriesList extends React.Component {
    render() {
        const items = this.props.items.map(item => <Dropdown.Item eventKey={item.id}>{item.name}</Dropdown.Item>);
        return (
            <Dropdown>
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

export default TimeseriesList;
