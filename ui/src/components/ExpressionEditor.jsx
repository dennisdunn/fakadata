import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import Icon from "react-fontawesome";

export class ExpressionEditor extends React.Component {

    remove() {
        this.props.onRemove(this.props.id);
    }

    render() {
        const { value } = this.props;
        return (
            <Row>
                <Col>
                    <Form.Control
                        defaultValue={value}
                        size="sm"
                        placeholder="f(x)"
                        onChange={this.props.onChange}
                    />
                </Col>
                <Col xs={2}>
                    <Button
                        variant="secondary"
                        size="sm"
                        onClick={this.remove.bind(this)}>
                        <Icon name="minus" />
                    </Button>
                </Col>
            </Row>
        );
    }
}

export default ExpressionEditor;
