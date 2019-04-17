import React from 'react';
import Form from 'react-bootstrap/Form';

export class SourceEditor extends React.Component {

    render() {
        console.log(this.props.text);
        return (
            <Form.Control
                defaultValue={this.props.text}
                size="sm"
                as="textarea"
                rows={this.props.rows}
            />
        );
    }
}

export default SourceEditor;
