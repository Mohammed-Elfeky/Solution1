import axios from "axios"
const base="http://localhost:46618/api/Department"





export const getAll=async()=>await axios.get(base)
