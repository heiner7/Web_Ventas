import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import { toast } from "react-toastify";
import TablaTask from "./TablaTask";
import { useEffect, useState } from "react";
import ModalTask from "./ModalTask";

const ViewTask = () => {

    const [task, setTask] = useState([])

    const [mostrarModal, setMostrarModal] = useState(false);
    //Variable que almacena la informacion a editar
    const [edit, setEdit] = useState(null)

    const [busqueda, setBusqueda] = useState('');

    const [completada, setCompletada] = useState(false);

    const marcarCheck = () => {
        setCompletada(!completada);
    };

    const resultados = task.filter((dato) =>
        dato.titulo.toLowerCase().includes(busqueda.toLowerCase()) ||
        dato.id.toString().includes(busqueda)
    );

    const handleSubmit = (e) => {
        e.preventDefault();
        if (!busqueda)
            mostrarTareas(0)
        else
            resultados.map((dato) => (
                mostrarTareas(dato.id)
            ))
        
    };

    const mostrarTareas = async (titulo) => {
        const response = await fetch("api/task/obtenerTarea/" + titulo);
        if (response.ok) {
            const data = await response.json();
            setTask(data)
        } else {
            toast.info('¡No hay datos para mostrar!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }

    const mostrarEstadosTareas = async (estado) => {
        const response = await fetch("api/task/obtenerEstadoTarea/" + estado);
        if (response.ok) {
            const data = await response.json();
            setTask(data)
        } else {
            toast.info('¡No hay datos para mostrar!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }


    useEffect(() => {
        mostrarTareas(0)
    }, [])

    const salveTask = async (task) => {
        let jwttoken = sessionStorage.getItem('jwttoken');

        const response = await fetch("api/task/guardarTarea", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
            body: JSON.stringify(task)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarTareas(0);
        } else if (response.status == 401) {
            setMostrarModal(!mostrarModal);
            toast.error('¡No esta autorizado!, Se requiere iniciar sesión', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else if (response.status == 500) {
            setMostrarModal(!mostrarModal);
            toast.error('¡Error en la conexión con el servidor!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else {
            setMostrarModal(!mostrarModal);
            toast.error('¡Posible campos vacios!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }

    const editTask = async (task) => {
        let jwttoken = sessionStorage.getItem('jwttoken');
 
        const response = await fetch("api/task/editarTarea", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
            body: JSON.stringify(task)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarTareas(0);
        } else if (response.status == 401) {
            setMostrarModal(!mostrarModal);
            toast.error('¡No esta autorizado!, Se requiere iniciar sesión', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else if (response.status == 500) {
            setMostrarModal(!mostrarModal);
            toast.error('¡Error en la conexión con el servidor!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else {
            setMostrarModal(!mostrarModal);
            toast.error('¡Posible campos vacios!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }

    const removeTask = async (id) => {
        let jwttoken = sessionStorage.getItem('jwttoken');
        const responseWindow = window.confirm("¿Desea eliminar la tarea?")

        if (!responseWindow) {
            return;
        }

        const response = await fetch("api/task/eliminarTarea/" + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
        })

        if (response.ok) {
            mostrarTareas(0);
        } else if (response.status == 400) {
            toast.error('¡error con el formato!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else if (response.status == 401) {
            
            toast.error('¡No esta autorizado!, Se requiere iniciar sesión', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else {
            toast.error('¡error con el servidor!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }

    const marcarComoCompletada = async (task) => {
        let jwttoken = sessionStorage.getItem('jwttoken');
        const responseWindow = window.confirm("¿Desea marcar la tarea por terminada?")

        if (!responseWindow) {
            return;
        }

        const response = await fetch("api/task/editarTarea", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                'Authorization': jwttoken
            },
            body: JSON.stringify(task)
        })

        if (response.ok) {
            mostrarTareas(0);
        } else if (response.status == 400) {
            toast.error('¡error con el formato!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        } else {
            toast.error('¡error con el servidor!', {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                theme: "dark",
            });
        }
    }

    return (
        <Container>
            {/* Espacio entre sección */}
            <div style={{ height: '70px' }}></div>

            <Row className="mt-5">

                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de tareas</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nueva tarea</Button>
                            <div style={{ display: "flex", alignItems: "center" }}>
                                <form onSubmit={handleSubmit}>
                                    <input
                                        type="text"
                                        placeholder="Buscar por título"
                                        value={busqueda}
                                        onChange={(e) => setBusqueda(e.target.value)}
                                    />
                                    <button type="submit">Buscar</button>
                                </form>
                                <ul>
                                    {busqueda.length > 0 ? (
                                        resultados.map((dato) => (
                                            <li key={dato.id}>
                                                ID: {dato.id} - Título: {dato.titulo}
                                            </li>
                                        ))
                                    ) : (
                                        <li>No se encontraron resultados</li>
                                    )}
                                </ul>
                            </div>
                            
                            <label>
                                <input
                                    type="checkbox"
                                    checked={completada}
                                    onChange={(e) => {
                                        marcarCheck()                                        
                                    }}
                                />
                                Mostrar tareas {completada ? "no completada" : "completada"} 
                            </label>
                            <button onClick={() => mostrarEstadosTareas(completada)}>
                                Mostrar tareas {completada ? "completadas" : "no completadas"}
                            </button>
                            <hr></hr>
                            <TablaTask data={task}
                                setEdit={setEdit}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}
                                marcarComoCompletada={marcarComoCompletada}
                                removeTask={removeTask}
                            />
                        </CardBody>
                    </Card>
                </Col>

            </Row>

            <ModalTask 
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarTask={salveTask}

                edit={edit}
                setEdit={setEdit}
                editTask={editTask}
            />
        </Container>
    )
}
export default ViewTask;