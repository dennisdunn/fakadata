import React, { Component } from "react";
import { connect } from "react-redux";
import ClippedDrawer from "./components/ClippedDrawer";
import NavKeys from "./components/NavKeys";
import SimpleAppBar from "./components/SimpleAppBar";
import * as actions from "./services/actionCreators";

class App extends Component {
  
  componentDidMount(){
    this.props.fetchMenu();
  }

  render() {
    return (
      <div className="App">
        <SimpleAppBar />
        <ClippedDrawer>
          <NavKeys
            onKeySelected={this.props.fetchTimeseries}
            items={this.props.items}
          />
        </ClippedDrawer>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return { ...state.menu };
}

export default connect(
  mapStateToProps,
  actions
)(App);
