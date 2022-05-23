import {Routes,Route} from "react-router-dom"
import Login from "./components/login";
import Nav from "./components/nav";
import './App.css'
import Details from "./components/details";
import Cards from "./components/cards";
import SignUp from "./components/signUp";
import axios from "axios";

function App() {
  let image;
  let form=new FormData()
  const assignImage=(e)=>{
    image=e.target.files[0];
    form.append("image",e.target.files[0],e.target.files[0].name)
  }
  const whenSubmit=()=>{
    axios.post("http://localhost:46618/api/Department",{
        name:"mohammed",
        manger:"ahmed"
    })
    .then(({data:{id}})=>{
        axios.post(`http://localhost:46618/api/Upload/${id}`,form)
        .then((res)=>{
          console.log(res)
        })
    })
  }
  return (
    <div className="App">
      <Nav/>
        <Routes>
          <Route path="/" element={<Login/>}/>
          <Route path="/departments" element={<Cards/>}/>
          <Route path="/login" element={<Login/>} />
          <Route path="/signUp" element={<SignUp/>} />
          <Route path="/details/:id" element={<Details/>} />
        </Routes>

        <input type="file" onChange={assignImage} />
        <button onClick={whenSubmit}>submit</button>
        <img src="http://localhost:46618/images/OIP.jpg"/>
    </div>
  );
}

export default App;
