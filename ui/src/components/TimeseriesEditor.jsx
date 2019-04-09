import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Icon from "react-fontawesome";
import { connect } from 'react-redux';
import * as actions from '../services/actionCreators';
import ExpressionEditor from './ExpressionEditor';


export class TimeseriesEditor extends React.Component {

    componentDidUpdate(prev) {
        const id = +this.props._id;
        if (id !== prev._id && id > 0) {
            this.preview();
        }
    }

    update(field) {
        return event => {
            this.props.updateTimeseries({ [field]: event.target.value });
        };
    }

    addExpression() {
        const expressions = this.props.expressions.slice(0);
        expressions.push('');
        this.props.updateTimeseries({ expressions });
    }

    removeExpression(item) {
        const expressions = this.props.expressions.slice(0);
        const stk = [];
        for (let i = 0; i < item.id; i++) {
            stk.push(expressions.shift());
        }
        expressions.pop();
        for (let i = 0; i < item.id; i++) {
            expressions.unshift(stk.pop());
        }
        this.props.updateTimeseries({ expressions });
    }

    changeExpression(item) {
        const expressions = this.props.expressions.slice(0);
        expressions[item.id] = item.value;
        this.props.updateTimeseries({ expressions });
    }

    preview() {
        this.props.getPreview(this.props.expressions);
    }

    canPreview() {
        return this.props.expressions.join('').length > 0;
    }

    canSave() {
        const { name, start, period } = this.props;
        return `${name}${start}${period}`.length > 0 && this.canPreview();
    }

    save() {
        const { _id, name, start, period, expressions } = this.props;
        this.props.saveTimeseries({ _id, name, start, period, expressions });
    }

    render() {
        const { name, start, period, expressions } = this.props;
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


const mapStateToProps = state => {
    return { ...state.timeseries };
};

export default connect(mapStateToProps, actions)(TimeseriesEditor);
