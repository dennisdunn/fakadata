import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardHeader from "@material-ui/core/CardHeader";
import { withStyles } from "@material-ui/core/styles";
import { TimeSeries } from "pondjs";
import PropTypes from "prop-types";
import React from "react";
import {
  ChartContainer,
  ChartRow,
  Charts,
  LineChart,
  Resizable,
  YAxis
} from "react-timeseries-charts";

const styles = {
  root: {
    flexGrow: 1,
    margin: 20
  },
  hidden: {
    display: "none"
  }
};

const chartStyles = {
  value: {
    normal: { stroke: "steelblue", fill: "none", strokeWidth: 1 }
  }
};

export const TimeseriesView = props => {
  const { data } = props;
  const series = new TimeSeries(data);
  
  return !data ? (
    <div />
  ) : (
    <div style={styles.root}>
      <Card>
        <CardHeader title={data.name} />
        <CardContent>
          <Resizable>
            <ChartContainer timeRange={series.timerange()}>
              <ChartRow height="350">
                <YAxis
                  id="axis1"
                  label="MV"
                  width="60"
                  type="linear"
                  format=".2f"
                  min={series.min()} max={series.max()}
                />
                <Charts>
                  <LineChart
                    style={chartStyles}
                    axis={"axis1"}
                    series={series}
                  />
                </Charts>
              </ChartRow>
            </ChartContainer>
          </Resizable>
        </CardContent>
      </Card>
    </div>
  );
};

TimeseriesView.propTypes = {
  classes: PropTypes.object,
  name: PropTypes.string,
  data: PropTypes.object
};

export default withStyles(styles)(TimeseriesView);
