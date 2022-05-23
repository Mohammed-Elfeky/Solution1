import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useState } from 'react';
import { register } from '../Redux/user/api'
const SignUp = () => {
    const [name, setName] = useState('')
    const [pass, setPass] = useState('')
    const [confirnPass, setConfirnPass] = useState('')

    const nameChange = (e) => {
        setName(e.target.value)
    }
    const passChange = (e) => {
        setPass(e.target.value)
    }
    const passConfirmChange = (e) => {
        setConfirnPass(e.target.value)
    }

    const whenClick = () => {
        register({
            Password: pass,
            UserName: name,
            ConfirmPassword: confirnPass
        }).then(res=>console.log(res))
    }

    return (
        <div className='my-form'>
            <TextField onChange={nameChange} id="standard-basic" label="user name" variant="standard" />
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
            <TextField
                style={{ marginTop: '25px' }}
                id="standard-basic"
                label="Password"
                variant="standard"
                type={"password"}
                onChange={passConfirmChange}
            />
            <br />
            <Button onClick={whenClick} style={{ marginTop: '25px' }} variant="outlined">Primary</Button>
        </div>
    );
}
export default SignUp;