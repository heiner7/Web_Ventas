import { useEffect, useState } from "react";
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ViewPlayer from "./components/ViewPlayer";
import Login from "./components/Login";
import Home from "./components/Home";
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaHome, FaUser, FaFootballBall, FaUserFriends, FaSignInAlt } from 'react-icons/fa';

function App() {
    const [displayusername, displayusernameupdate] = useState('');

    useEffect(() => {
        let username = sessionStorage.getItem('username');
        displayusernameupdate(username);
        
    }, [])

    return (
        <div>
            <ToastContainer
                position="top-center"
                autoClose={5000}
                limit={1}
                hideProgressBar={false}
                newestOnTop
                closeOnClick
                rtl={false}
                pauseOnFocusLoss={false}
                draggable
                pauseOnHover
                theme="dark"
            />

            <BrowserRouter>
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    <div className="container-fluid">
                        <Link className="navbar-brand" to="/">
                            <FaHome /> Inicio
                        </Link>
                        <button
                            className="navbar-toggler"
                            type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#navbarNav"
                            aria-controls="navbarNav"
                            aria-expanded="false"
                            aria-label="Toggle navigation"
                        >
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navbarNav">
                            <ul className="navbar-nav ms-auto">
                                <li className="nav-item me-3">
                                    <Link className="nav-link" to="/viewPlayer">
                                        <FaUserFriends /> Ver Jugadores
                                    </Link>
                                </li>
                                <li className="nav-item me-3">
                                    <Link className="nav-link" to="/viewTeam">
                                        <FaFootballBall /> Ver Equipos
                                    </Link>
                                </li>
                                <li className="nav-item me-3">
                                    <li className="nav-link">
                                        <span ><FaUser /> <b>{displayusername}</b></span>
                                    </li>
                                </li>
                                <li className="nav-item me-3">
                                    <Link className="nav-link" to="/login">
                                        <FaSignInAlt /> Salir
                                    </Link>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/viewPlayer" element={<ViewPlayer />} />
                    <Route path="/login" element={<Login />} />
                </Routes>
            </BrowserRouter>
            
        </div>
    );
}
export default App;