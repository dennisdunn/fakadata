export const asChartSeries = (name, data) => {
  const points = data.map(x => [new Date(x.timestamp).getTime(), x.value]);
  const columns = ["time", "value"];
  return {
    name,
    columns,
    points
  };
};
