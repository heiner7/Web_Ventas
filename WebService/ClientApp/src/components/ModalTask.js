
import { useEffect, useState } from "react"
import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button  } from "reactstrap"

const modeloTask = {
    id: 0,
    titulo: "",
    descripción: "",
    fechaRegistro: "",
    tareaCompleta: false,
    fechaTerminada: undefined
}

const ModalTask = ({ mostrarModal, setMostrarModal, guardarTask, edit, setEdit, editTask }) => {

    const [task, setTask] = useState(modeloTask);

    const actualizarDato = (e) => {
        setTask(
            {
                ...task,
                [e.target.name]: e.target.value
            }
        )
    }

    const enviarDatos = () => {
        if (task.id == 0) {
            guardarTask(task)
        } else {
            editTask(task)
        }
        setTask(modeloTask)
    }

    useEffect(() => {
        if (edit != null) {
            setTask(edit)
        } else {
            setTask(modeloTask)
        }
    }, [edit])

    const closeModal = () => {
        setMostrarModal(!mostrarModal)
        setEdit(null)
    }

    return (

        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {task.id == 0 ? "Nueva Tarea" : "Editar Tarea"}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Titulo</Label>
                        <Input name="titulo" onChange={(e) => actualizarDato(e)} value={task.titulo} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Descripcion</Label>
                        <Input name="descripción" onChange={(e) => actualizarDato(e)} value={task.descripción} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Fecha registro</Label>
                        <Input type="datetime-local" name="fechaRegistro" onChange={(e) => actualizarDato(e)} value={task.fechaRegistro} />
                    </FormGroup>
                    <FormGroup>
                        <label>¿Tarea completada?</label>
                        <select name="tareaCompleta" onChange={(e) => actualizarDato(e)} value={task.tareaCompleta}>
                            <option value={true}>Sí</option>
                            <option value={false}>No</option>
                        </select>
                    </FormGroup>
                    <FormGroup>
                        <Label>Fecha terminada</Label>
                        <Input type="datetime-local" name="fechaTerminada" onChange={(e) => actualizarDato(e)} value={task.fechaTerminada} />
                    </FormGroup>
                </Form>
            </ModalBody>

            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos}>Guardar</Button>
                <Button color="danger" size="sm" onClick={closeModal}>Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalTask;