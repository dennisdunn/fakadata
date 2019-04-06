import React from "react";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Dropdown from "react-bootstrap/Dropdown";

export class TimeseriesList extends React.Component {
    render() {
        return (
            <Row>
                <Col>
                    <Dropdown>
                        <Dropdown.Toggle variant="success">{this.props.title || 'Definitions'}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item eventKey={0}>New</Dropdown.Item>
                            <Dropdown.Divider />
                        </Dropdown.Menu>
                    </Dropdown>
                </Col>
                <Col xs={2} />
            </Row>
        );
    }
}

export default TimeseriesList;
