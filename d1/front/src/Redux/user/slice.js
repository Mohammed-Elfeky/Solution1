import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { login } from './api.js'

const initialState = {
    user: localStorage.getItem("user") ?
        JSON.stringify(localStorage.getItem("user")) :
        null
}

export const loginAction = createAsyncThunk("user/login", async (userForm) => {
    try {
        const {data:{token}}= await login(userForm)
        return token
    } catch (err) {
        return err.message
    }
});


const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        logout: (state) => {
            state.user = null;
            localStorage.removeItem("user")
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginAction.fulfilled, (state, {payload} ) => {
                state.user = payload;
            })
    }
});


export const { logout } = userSlice.actions;
export default userSlice.reducer;