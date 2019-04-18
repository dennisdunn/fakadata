import React from 'react';
import Form from 'react-bootstrap/Form';

export class SourceEditor extends React.Component {

    render() {
        return (
            <Form>
                <Form.Group id="sourceEditor">
                    <Form.Control
                        value={this.props.text}
                        size="sm"
                        as="textarea"
                        rows={this.props.rows}
                        onChange={this.props.onChange}
                    />
                </Form.Group>
            </Form>
        );
    }
}

export default SourceEditor;
