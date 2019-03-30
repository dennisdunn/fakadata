import React, { Component } from "react";
import { connect } from "react-redux";
import ClippedDrawer from "./components/ClippedDrawer";
import NavKeys from "./components/NavKeys";
import SimpleAppBar from "./components/SimpleAppBar";
import { fetchData } from "./services/actionCreators";

class App extends Component {
  render() {
    return (
      <div className="App">
        <SimpleAppBar />
        <ClippedDrawer>
          <NavKeys
            onKeySelected={this.props.fetchData}
            keys={[
              "inlet_t_c",
              "inlet_p_barg",
              "discharge_p_barg",
              "discharge_t_c",
              "flow_mbar",
              "flow_m3ph",
              "power_kW",
              "valve_position_pct",
              "speed_rpm",
              "surge_line",
              "surge_value",
              "surge_speed_rpm"
            ]}
          />
        </ClippedDrawer>
      </div>
    );
  }
}

const actions = {
  fetchData
};

function mapStateToProps(state) {
  return { ...state };
}

export default connect(
  mapStateToProps,
  actions
)(App);
