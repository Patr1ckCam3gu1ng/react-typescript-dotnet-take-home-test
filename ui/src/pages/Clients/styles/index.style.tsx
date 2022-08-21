import commonStyle from "./common.style";

const useStyles = () => ({
    root: {
        marginTop: '20px',
        '& .MuiButton-root': {
            paddingTop: '5px',
            paddingBottom: '5px'
        },
        '& .MuiInputBase-colorPrimary': {
            backgroundColor: 'white'
        },
        ...commonStyle,
        '& .MuiTableCell-sizeMedium': {
            padding: '20px 40px'
        },
        '& .MuiTableCell-head': {
            fontWeight: 'bold'
        },
        '& a': {
            color: '#4e73ff',
            fontWeight: 'bold',
            textDecoration: 'none'
        }
    },
    textField: {
        backgroundColor: '#fff'
    },
    Dialog: {
        backgroundColor: 'red'
    }
})

export default useStyles;
