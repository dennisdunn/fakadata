import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Icon from "react-fontawesome";

export class AddExpressionButton extends React.Component {

    render() {
        return (
            <Row>
                <Col />
                <Col xs={2}>
                    <Button
                        variant="primary"
                        size="sm"
                        onClick={this.props.onClick.bind(this)}>
                        <Icon name="plus" />
                    </Button>
                </Col>
            </Row>
        );
    }
}

export default AddExpressionButton;
