import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Icon from "react-fontawesome";
import { connect } from 'react-redux';
import * as actions from '../services/actionCreators';
import ExpressionEditor from './ExpressionEditor';


export class TimeseriesEditor extends React.Component {
    constructor(props) {
        super(props);
        const { id, name, start, period, expressions } = this.props.timeseries;
        this.state = { id, name, start, period, expressions };
    }

    update(field) {
        return event => {
            this.setState({ [field]: event.target.value });
        };
    }

    addExpression() {
        const { expressions } = this.state;
        expressions.push('');
        this.setState({ expressions });
    }

    removeExpression(item) {
        let { expressions } = this.state;
        expressions = expressions.filter((_, idx) => idx !== item.id);
        this.setState({ expressions });
    }

    changeExpression(item) {
        const { expressions } = this.state;
        expressions[item.id] = item.value;
        this.setState({ expressions });
    }

    preview() {
        const { expressions } = this.state;
        this.props.getPreview(expressions);
    }

    canPreview() {
        const { expressions } = this.state;
        return expressions.join('').length > 0;
    }

    canSave() {
        const { name, start, period } = this.state;
        return `${name}${start}${period}`.length > 0 && this.canPreview();
    }

    save() {
        this.props.saveTimeseries(this.state);
    }

    render() {
        const { id, name, start, period, expressions } = this.state;
        const exprEditors = expressions.map((item, idx) => <ExpressionEditor id={idx} value={item} onRemove={this.removeExpression.bind(this)} onChange={this.changeExpression.bind(this)} />);
        return (
            <Form>
                <Form.Group as={Form.Row}>
                    <Form.Label column xs={4}>
                        Name
                    </Form.Label>
                    <Col>
                        <Form.Control size="sm" type="text" value={name} onChange={this.update('name').bind(this)} />
                    </Col>
                </Form.Group>
                <Form.Group as={Form.Row}>
                    <Form.Label column xs={4}>
                        Start
                    </Form.Label>
                    <Col>
                        <Form.Control size="sm" type="text" placeholder='1970-01-01' value={start} onChange={this.update('start').bind(this)} />
                    </Col>
                </Form.Group>
                <Form.Group as={Form.Row}>
                    <Form.Label column xs={4}>
                        Period
                    </Form.Label>
                    <Col>
                        <Form.Control size="sm" type="text" placeholder='00:00:01:00' value={period} onChange={this.update('period').bind(this)} />
                    </Col>
                </Form.Group>
                <Form.Group as={Form.Row} >
                    <Col>
                        {this.canPreview()
                            ? (<Button
                                variant='light'
                                size="sm"
                                onClick={this.preview.bind(this)}>Preview</Button>)
                            : (<Button
                                variant='light'
                                size="sm"
                                disabled >Preview</Button>)}
                    </Col>
                    <Col xs={2}>
                        <Button
                            variant="success"
                            size="sm"
                            onClick={this.addExpression.bind(this)} >
                            <Icon name="plus" />
                        </Button>
                    </Col>
                </Form.Group>
                {exprEditors}
                <Form.Group as={Form.Row} >
                    <Col>
                        {this.canSave()
                            ? (<Button
                                variant='success'
                                size="sm"
                                onClick={this.save.bind(this)}>Save</Button>)
                            : (<Button
                                variant='success'
                                size="sm"
                                disabled >Save</Button>)}
                    </Col>
                </Form.Group>
            </Form>
        );
    }
}

export default connect(null, actions)(TimeseriesEditor);
