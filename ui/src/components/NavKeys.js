import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from "prop-types";
import React from "react";

const styles = {
  root: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between"
  }
};

export function NavKeys(props) {
  const { keys, classes } = props;

  function btnClicked(evt) {
    props.onKeySelected(evt.target.innerText);
  }

  return (
    <div className={classes.root}>
      {keys.map(key => (
        <Button onClick={btnClicked} color={"primary"}>
          {key}
        </Button>
      ))}
    </div>
  );
}

NavKeys.propTypes = {
  classes: PropTypes.object.isRequired,
  onKeySelected: PropTypes.func,
  keys: PropTypes.array.isRequired
};

export default withStyles(styles)(NavKeys);
