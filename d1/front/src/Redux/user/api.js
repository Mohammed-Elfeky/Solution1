import axios from "axios"
const API_URL = 'http://localhost:46618/api/Account'

// Register user
export const register = async (userData) => {
    const response = await axios.post(`${API_URL}/signUp`, userData)
    return response.data
}

// Login user
export const login = async (userData) => {
    const response = await axios.post(`${API_URL}/signIn`, userData)
    if (response.data) {
        localStorage.setItem('user', JSON.stringify(response.data.token))
    }
    return response
}

