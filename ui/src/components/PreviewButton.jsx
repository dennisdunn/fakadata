import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";

export class PreviewButton extends React.Component {
    render() {
        const previewBtn = this.props.disabled ? (
            <Button variant="primary" disabled onClick={this.props.onClick.bind(this)}>
                Preview
            </Button>
        ) : (
                <Button variant="primary" onClick={this.props.onClick.bind(this)}>
                    Preview
            </Button>
            );

        return (
            <Form.Row>
                <Col>{previewBtn}</Col>
                <Col xs={2} />
            </Form.Row>
        );
    }
}

export default PreviewButton;
