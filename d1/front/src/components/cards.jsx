import { useEffect, useState } from "react";
import Card from "./card";
import { getAll } from '../api/Departments'
import { useNavigate } from 'react-router-dom'
import { useSelector} from "react-redux"
const Cards = () => {

    const user=useSelector(({auth:{user}})=>user)

    const [Departments, setDepartments] = useState([])
    const navigate = useNavigate()

    useEffect(() => {
        getAll()
            .then(({ data }) => {
                setDepartments(data)
            })
    }, [])

    useEffect(() => {
        if (!user) {
            navigate("/login")
        }
    }, [user])

    return (
        <>
            <div className="d-flex flex-wrap justify-content-center py-4">
                {Departments.map(Department => <Card Department={Department} />)}
            </div>
        </>
    );
}

export default Cards;