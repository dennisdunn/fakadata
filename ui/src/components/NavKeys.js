import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from "prop-types";
import React from "react";

const styles = {
  root: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
    marginRight: 20,
    marginTop: 20
  }
};

export const NavKeys = props => {
  const { items, classes, onKeySelected } = props;

  const btnClicked = evt => {
    onKeySelected(evt.target.innerText);
  };
  
  let i = 0;

  return (
    <div className={classes.root}>
      {items.map(item => (
        <Button key={i++} onClick={btnClicked} color={"primary"}>
          {item}
        </Button>
      ))}
    </div>
  );
};

NavKeys.propTypes = {
  classes: PropTypes.object.isRequired,
  onKeySelected: PropTypes.func,
  items: PropTypes.array.isRequired
};

export default withStyles(styles)(NavKeys);
