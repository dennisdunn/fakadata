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
  const { items, classes, onKeySelected } = props;

  function btnClicked(evt) {
    onKeySelected(evt.target.innerText);
  }

  return (
    <div className={classes.root}>
      {items.map(item => (
        <Button key={item.key} onClick={btnClicked} color={"primary"}>
          {item.value}
        </Button>
      ))}
    </div>
  );
}

NavKeys.propTypes = {
  classes: PropTypes.object.isRequired,
  onKeySelected: PropTypes.func,
  items: PropTypes.array.isRequired
};

export default withStyles(styles)(NavKeys);
