import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { loginAction } from '../Redux/user/slice'
const Login = () => {
    const [name, setName] = useState('')
    const [pass, setPass] = useState('')
    const dispatch = useDispatch()

    const nameChange = (e) => {
        setName(e.target.value)
    }
    const passChange = (e) => {
        setPass(e.target.value)
    }

    const whenClick = () => {
        dispatch(
            loginAction({
                UserName: name,
                Password: pass,
            })
        )
    }

    return (
        <div className='my-form'>
            <TextField onChange={nameChange} id="standard-basic" label="Email" variant="standard" />
            <br />
            <TextField
                style={{ marginTop: '25px' }}
                id="standard-basic"
                label="Password"
                variant="standard"
                type={"password"}
                onChange={passChange}
            />
            <br />
            <Button onClick={whenClick} style={{ marginTop: '25px' }} variant="outlined">Primary</Button>
        </div>
    )
}

export default Login;