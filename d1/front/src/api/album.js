import axios from "axios"



const base="https://jsonplaceholder.typicode.com/albums"
export const getAll=async()=>await axios.get(base)
export const getById=async(id)=>await axios.get(`${base}/${id}`)
