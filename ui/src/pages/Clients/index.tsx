// npm
import { memo, useContext, useEffect } from "react";

// material ui
import { Grid, Paper, Typography } from "@mui/material";
import { withStyles } from "@mui/styles";

// api
import { getClients } from "../../services/api";
import { StateContext } from "../../store/DataProvider";

// components
import ClientInput from "./ClientInput";
import Page from "../../components/Page";
import ClientTable from "./ClientTable";

// styles
import styles from "./styles/index.style";

export interface IProps {
    classes: any;
}

function Clients({ classes }: IProps) {
    const {state, dispatch} = useContext(StateContext);
    const {clients} = state;

    useEffect(() => {
        getClients().then((clients) =>
            dispatch({type: "FETCH_ALL_CLIENTS", data: clients})
        );
    }, [dispatch]);

    return (
        <Page>
            <Typography variant="h4" sx={{textAlign: "start"}}>
                Clients
            </Typography>
            <Grid container spacing={0} className={classes.root}>
                <ClientInput/>
                <Grid item md={12} lg={12}>
                    <Paper sx={{margin: "auto", marginTop: 3}}>
                        <ClientTable clients={clients}/>
                    </Paper>
                </Grid>
            </Grid>
        </Page>
    );
}

export default memo(withStyles(styles)(Clients));
