import React from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Icon from 'react-fontawesome';

const styles = {
    root: {
        flexGrow: 1
    },
    header: {
        textAlign: 'center',
        paddingBottom: 10
    }
}

export class ExpressionEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { items: props.expressions };
    }

    apply() {
        const { items } = this.state;
        this.props.onApply(items);
    }

    mkOnChange(idx) {
        return evt => {
            const { items } = this.state;
            items[idx] = evt.target.value;
            this.setState({ items });
        }
    }

    mkOnRemove(idx) {
        return () => {
            let { items } = this.state;
            items = items.filter((_, i) => idx !== i);
            if (items.length === 0) {
                this.props.onClear();
            }
            this.setState({ items });
        }
    }

    onAdd() {
        const { items } = this.state;
        items.push("");
        this.setState({ items });
    }

    onKey(evt) {
        if (evt.keyCode === 13) {
            this.apply();
        }
    }

    render() {
        const { items } = this.state;
        const controls = items.map((x, idx) =>
            <Form.Group key={idx}>
                <Form.Row>
                    <Col>
                        <Form.Control defaultValue={x} size='sm' placeholder='f(x)' onChange={this.mkOnChange(idx).bind(this)} onBlur={this.apply.bind(this)} onKeyUp={this.onKey.bind(this)} />
                    </Col>
                    <Col xs={2}>
                        <Button variant="secondary" size="sm" onClick={this.mkOnRemove(idx).bind(this)}><Icon name="minus" /></Button>
                    </Col>
                </Form.Row>
            </Form.Group>);

        return (
            <div style={styles.root}>

                {controls}
                <Form.Group>
                    <Form.Row>
                        <Col>
                        </Col>
                        <Col xs={2}>
                            <Button variant="primary" size="sm" onClick={this.onAdd.bind(this)}><Icon name="plus" /></Button>
                        </Col>
                    </Form.Row>
                </Form.Group>

            </div>
        );
    }
};

export default ExpressionEditor;
