import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getById } from "../api/album";

const Details = () => {
    const {id}=useParams()
    const [content,setContent]=useState('')
    useEffect(()=>{
        getById(id).
        then(({data:{title:mytitle}})=>{
            setContent(mytitle)
        })
    },[id])
    return (
        <div className="my-form">
            {content}
        </div>
    );
}
 
export default Details;