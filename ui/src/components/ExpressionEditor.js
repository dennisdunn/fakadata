import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Icon from 'react-fontawesome';
import React from 'react';

const styles = {
    root: {
        flexGrow: 1
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
            this.setState({ items });
        }
    }

    onAdd() {
        const { items } = this.state;
        items.push("");
        this.setState({ items });
    }

    isValid() {
        const { items } = this.state;
        return items.length === 0 ? false : items.map(x => x.length).reduce((t, c) => t * c, 1);
    }

    render() {
        const { items } = this.state;
        const controls = items.map((x, idx) =>
            <Form.Group key={idx}>
                <Form.Row>
                    <Col>
                        <Form.Control defaultValue={x} onChange={this.mkOnChange(idx).bind(this)} size='sm' placeholder='f(x)'/>
                    </Col>
                    <Col xs={2}>
                        <Button variant="secondary" size="sm" onClick={this.mkOnRemove(idx).bind(this)}><Icon name="minus" /></Button>
                    </Col>
                </Form.Row>
            </Form.Group>);

        return (
            <div style={styles.root}>
                <Form>
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
                    <Button variant="primary" onClick={this.apply.bind(this)} disabled={!this.isValid()}>Apply</Button>
                </Form>
            </div>
        );
    }
};

export default ExpressionEditor;
