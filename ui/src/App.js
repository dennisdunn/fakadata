import React, { Component } from "react";
import { connect } from "react-redux";
import NavKeys from "./components/NavKeys";
import SimpleAppBar from "./components/SimpleAppBar";
import { TimeseriesView } from "./components/TimeseriesView";
import * as actions from "./services/actionCreators";

class App extends Component {

  componentDidMount() {
    this.props.fetchMenu();
  }
  
  styles = {
    root: {
      display: "flex",
      flexDirection: "column"
    },
    content: {
      display: "flex",
      flexDirection: "row"
    }
  };
  render() {
    const { menu, timeseries, fetchTimeseries } = this.props;

    return (
      <div style={this.styles.root}>
        <SimpleAppBar />
        <div style={this.styles.content}>
          <NavKeys onKeySelected={fetchTimeseries} items={menu.items} />
          <TimeseriesView data={timeseries.series} />
        </div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return { ...state };
}

export default connect(
  mapStateToProps,
  actions
)(App);
