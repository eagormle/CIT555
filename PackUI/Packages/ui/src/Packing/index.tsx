import * as React from "react";
import { Grid, GridProps, Toolbar, Typography } from "@mui/material";

interface MyComponentProps extends GridProps {
  // Define additional props here
}

const MyComponent: React.FC<MyComponentProps> = (props) => {
  const { children, ...rest } = props;

  return (
    <Grid>
      <Toolbar>
        <Grid item>
          <Grid container>
            <Typography variant="body1">Header bar</Typography>
          </Grid>
        </Grid>
      </Toolbar>
      <Grid item>
        <Grid container>
          <Typography variant="body1">Body Space</Typography>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default MyComponent;
//prettier is option+shift+F, need to configure it for on save 
