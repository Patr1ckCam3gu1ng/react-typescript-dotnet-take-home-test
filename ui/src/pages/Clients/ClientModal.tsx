import {
    Button,
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
    DialogTitle,
    Grid,
    TextField
} from "@mui/material";
import React, {useCallback, useContext, useState} from "react";
import {withStyles} from "@mui/styles";
import styles from "./styles/ClientModal.style";
import {createClient} from "../../services/api";
import {StateContext} from "../../store/DataProvider";

interface IInputValue {
    id: string;
    value: string;
}

interface IInput {
    id: string;
    label: string;
    required: boolean;
}

export interface IProps {
    isOpen: boolean;
    classes: any;
    showModal: React.Dispatch<any>;
}

function ClientModal({showModal, isOpen, classes}: IProps) {
    const {dispatch} = useContext(StateContext);

    let inputs: Array<IInput[]> = [
        [
            {
                id: 'firstName',
                label: 'First name',
                required: true
            },
            {
                id: 'lastName',
                label: 'Last name',
                required: true
            }
        ],
        [
            {
                id: 'phoneNumber',
                label: 'Phone number',
                required: false
            },
            {
                id: 'email',
                label: 'email',
                required: false
            }
        ]
    ];

    const [inputValue, setInputValue] = useState<IClient>();

    const handleOnKeyChange = useCallback((input: IInputValue) => setInputValue((state: any) => {
        return {
            ...state,
            [input.id]: input.value
        };
    }), []);

    const handleOnButtonClick = useCallback(() => {
        if (inputValue) {
            createClient(inputValue).then((clients) => {
                dispatch({type: "FETCH_ALL_CLIENTS", data: clients});
                showModal(false);
            });
        }
    }, [inputValue, dispatch, showModal]);

    return <Dialog
        open={isOpen}
        onClose={() => showModal(false)}
    >
        <DialogTitle>
            {'Create New Client'}
        </DialogTitle>
        <DialogContent className={classes.root}>
            <DialogContentText>
                {
                    inputs.map((input: IInput[], key) => {
                        return <Grid container spacing={0} key={key}>
                            {
                                input.map((prop: IInput) => {
                                    return <React.Fragment key={prop.id}>
                                        <Grid item md={6} lg={6}>
                                            <TextField id={prop.id}
                                                       variant="outlined"
                                                       label={prop.label}
                                                       size={'small'}
                                                       required={prop.required}
                                                       onChange={(event) => handleOnKeyChange({
                                                           id: prop.id,
                                                           value: event.target.value
                                                       })}
                                            />
                                        </Grid>
                                    </React.Fragment>
                                })
                            }
                        </Grid>
                    })
                }
            </DialogContentText>
        </DialogContent>
        <DialogActions className={classes.root}>
            <Button variant="contained" color='primary' size={'medium'} onClick={handleOnButtonClick}>
                <label>Create Client</label>
            </Button>
        </DialogActions>
    </Dialog>
}

export default withStyles(styles)(ClientModal)
