import commonStyle from "./common.style";

const useStyles = () => ({
    root: {
        '& .MuiTextField-root': {
            margin: '8px'
        },
        marginTop: '5px',
        ...commonStyle
    }
});

export default useStyles;
