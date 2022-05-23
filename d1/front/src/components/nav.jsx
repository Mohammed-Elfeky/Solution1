import { Link } from "react-router-dom";
import { logout } from "../Redux/user/slice"
import { useDispatch } from 'react-redux'
const Nav = () => {
    const dispatch=useDispatch()
    const whenClick=()=>{
        dispatch(logout())
    }
    return (
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <Link to="/" class="nav-link active" aria-current="page" href="#">Home</Link>
                        </li>
                        <li class="nav-item">
                            <Link to="/login" class="nav-link" href="#">login</Link>
                        </li>
                        <li class="nav-item">
                            <Link to="/signUp" class="nav-link" href="#">signUp</Link>
                        </li>
                        <li class="nav-item">
                            <Link to="/departments" class="nav-link" href="#">departments</Link>
                        </li>
                        <li class="nav-item">
                            <Link onClick={whenClick} to="/departments" class="nav-link" href="#">logout</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Nav;