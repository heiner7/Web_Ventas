
import { Table, Button } from "reactstrap"
import { useState } from 'react';

const TablaTask = ({ data, setEdit, mostrarModal, setMostrarModal, removeTask, marcarComoCompletada }) => {

    const sendData = (task) => {
        setEdit(task)
        setMostrarModal(!mostrarModal)
    }

    

    return (

        <Table striped responsive>            
            <thead>
                <tr>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Fecha Registro</th>
                    <th>Tarea Completa</th>
                    <th>Fecha Terminada</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                {data.length < 1 ? (
                    <tr>
                        <td colSpan="6">Sin registros</td>
                    </tr>
                ) : (
                    data.map((item) => (
                        <tr key={item.id}>
                            <td>{item.titulo}</td>
                            <td>{item.descripcion}</td>
                            <td>{item.fechaRegistro}</td>
                            <td>{item.tareaCompleta ? 'Sí' : 'No'}</td>
                            <td>{item.fechaTerminada}</td>
                            <td>
                                <Button
                                    color="primary"
                                    size="sm"
                                    className="me-2"
                                    onClick={() => sendData(item)}
                                >
                                    Editar
                                </Button>
                                <Button
                                    color="danger"
                                    size="sm"
                                    onClick={() => removeTask(item.id)}
                                >
                                    Eliminar
                                </Button>
                                {!item.tareaCompleta && (
                                    <label>
                                        <input
                                            type="checkbox"
                                            checked={item.tareaCompleta}
                                            onChange={() => {
                                                item.tareaCompleta = true;
                                                marcarComoCompletada(item);
                                            }}
                                        />
                                        Marcar como completada
                                    </label>
                                )}
                                {item.tareaCompleta && (
                                    <label>
                                        <input
                                            type="checkbox"
                                            checked={item.tareaCompleta}
                                            
                                        />
                                        Tarea completada
                                    </label>
                                )}
                            </td>
                        </tr>
                    ))
                )}
            </tbody>

        </Table>

    )
}

export default TablaTask ;