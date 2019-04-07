import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Icon from "react-fontawesome";

export class ExpressionEditor extends React.Component {

    changed(event) {
        this.props.onChange({ id: this.props.id, value: event.target.value });
    }

    remove() {
        this.props.onRemove({ id: this.props.id });
    }

    render() {
        const { value } = this.props;
        return (
            <Form.Group as={Form.Row}>
                <Col>
                    <Form.Control
                        value={value}
                        size="sm"
                        placeholder="f(x)"
                        onChange={this.changed.bind(this)}
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
            </Form.Group>
        );
    }
}

export default ExpressionEditor;
