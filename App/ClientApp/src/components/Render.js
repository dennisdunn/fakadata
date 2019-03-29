import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { connnect } from 'react-redux';

export class Render extends Component {

    state = { data: [] }

    componentDidMount() {
        const { series } = this.props.match.params

        fetch(`/api/timeseries/${series}`)
            .then(response => response.json())
            .then(data => this.setState({ data }));
    }

    render() {
        const rows = this.state.data.map(x => <tr><td>{x.timestamp}</td><td>{x.value}</td></tr>);

        return (
            <div>
                <Table size={'sm'} striped={true}>
                    <thead>
                        <tr>
                            <th>Timestamp</th>
                            <th>Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows}
                    </tbody>
                </Table>
            </div>
        );
    }
}

export default connect(mapStateToProps)(Render);

function mapStateToProps(state) {
    return { data: [], key: '' };
}
