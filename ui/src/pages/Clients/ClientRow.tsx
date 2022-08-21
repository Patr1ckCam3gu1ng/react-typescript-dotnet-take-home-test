import { TableCell, TableRow } from "@mui/material";

export interface IProps {
    client: IClient;
}

function ClientListItem({client}: IProps) {
    const {id, firstName, lastName, email, phoneNumber} = client;

    return (
        <TableRow
            key={id}
        >
            <TableCell component="th" scope="row">
                <a href={'/clients'}>{firstName} {lastName}</a>
            </TableCell>
            <TableCell>{phoneNumber}</TableCell>
            <TableCell>{email}</TableCell>
        </TableRow>
    );
}

export default ClientListItem;
