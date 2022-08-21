import React, {useCallback, useContext, useState} from "react";
// @ts-ignore
import _ from 'debounce';

// material ui
import {Grid, InputAdornment, TextField} from "@mui/material";
import IconButton from "@mui/material/IconButton";
import SearchIcon from "@mui/icons-material/Search";
import Button from "@mui/material/Button";

// components
import ClientCreateNewModal from "./ClientModal";
import {StateContext} from "../../store/DataProvider";
import {getClients} from "../../services/api";

export default function ClientInput() {
    const {dispatch} = useContext(StateContext);
    const [isOpen, showModal] = useState<boolean>(false);

    const clientSearch = useCallback(_.debounce((value: string) => {
        getClients(value).then((clients) =>
            dispatch({type: "FETCH_ALL_CLIENTS", data: clients})
        );
    }, 700), [])

    const handleOnClickCreateNew = useCallback(() => {
        showModal(!isOpen);
    }, [isOpen]);

    return <React.Fragment>
        <Grid item md={5} lg={5}>
            <TextField
                label="Search clients..."
                variant="outlined"
                size="small"
                InputProps={{
                    endAdornment: (
                        <InputAdornment position={'end'}>
                            <IconButton>
                                <SearchIcon/>
                            </IconButton>
                        </InputAdornment>
                    ),
                    onChange: (event) => clientSearch(event.target.value)
                }}
            />
        </Grid>
        <Grid item md={3} lg={3}/>
        <Grid item md={4} lg={4}>
            <Button variant="contained" color='primary' size={'medium'} onClick={handleOnClickCreateNew}>
                <label>Create new client</label>
            </Button>
        </Grid>
        <ClientCreateNewModal isOpen={isOpen} showModal={showModal}/>
    </React.Fragment>
}
