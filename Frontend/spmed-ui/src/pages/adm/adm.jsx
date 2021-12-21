<<<<<<< HEAD
import React from "react";
import { useState, useEffect } from "react";
import { Link, useHistory } from "react-router-dom"
// import api from '../../services/api'
import '../../assets/css/adm_cadastro.css'
// import logo from "../../assets/images/logo.png"
=======
import { useState, useEffect } from "react";
import { Link, useHistory } from "react-router-dom"
import api from '../../services/api'
import '../../assets/css/adm_cadastro.css'
import logo from "../../assets/images/logo.png"
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
import axios from "axios";

export default function Adm() {
    const [listaConsulta, setListaConsulta] = useState([]);
    const [listaMedico, setListaMedico] = useState([]);
    const [listaPaciente, setListaPaciente] = useState([]);
    const [idMedico, setIdMedico] = useState([]);
    const [idPaciente, setIdPaciente] = useState([]);
    const [dataConsulta, setDataConsulta] = useState([]);
<<<<<<< HEAD
    const navigation = useHistory();
    const [isLoading, setisLoading] = useState(false);

    useEffect(ListarConsultas, []);
    useEffect(ListarMedicos, []);
    useEffect(ListarPacientes, []);

=======
    const [isLoading, setisLoading] = useState(false);

>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
    function cadastrarConsulta(evento) {
        setisLoading(true);

        evento.preventDefault()

        axios.post('http://http://192.168.0.112:5000/api/consultas', {
            idMedico: idMedico,
            idPaciente: idPaciente,
            dataConsulta: dataConsulta
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })

            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada');
                    setIdMedico('');
                    setIdPaciente('');
                    setDataConsulta('');
                    listaConsulta();
                    setisLoading(false);
                }
            })

            .catch(erro => console.log(erro), setIdMedico(''), setIdPaciente(''), setDataConsulta(''), setInterval(() => {
                setisLoading(false)
            }, 5000));
    }

<<<<<<< HEAD
    function ListarConsultas() {
        axios('http://http://192.168.0.112:5000/api/consultas', {
=======
    function listarConsultas() {
        axios.post('http://http://192.168.0.112:5000/api/consultas', {
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsulta(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    };

<<<<<<< HEAD
    function ListarMedicos() {
=======
    useEffect(listaConsulta, []);

    function listarMedicos() {
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
        axios('http://http://192.168.0.112:5000/api/medicos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMedico(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
<<<<<<< HEAD
    }


    function ListarPacientes() {
        axios('http://http://192.168.0.112:5000/api/pacientes', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setListaPaciente(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }

    const logout = () => {
        localStorage.removeItem('usuario-login');
        navigation.push('/')
    }


=======

        useEffect(listarMedicos, []);

        function listarPacientes() {
            axios('http://http://192.168.0.112:5000/api/pacientes', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })

                .then(resposta => {
                    if (resposta.status === 200) {
                        setListaPaciente(resposta.data)
                    }
                })

                .catch(erro => console.log(erro))

            useEffect(listarPacientes, []);

        }
    }
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895

    return (
        <main className=" container ">
            <div className="background ">
                <div className="grid ">
                    <img className="logo " src="./assets/logo.png " alt="Logo Sp Medical Group "></img>
                    <section className="container_form ">
                        <h1>Cadastro de consulta</h1>
<<<<<<< HEAD
                        <div>
                            <button className='btn_sair' onClick={logout} >Sair</button>
                        </div>
=======
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                        <form onSubmit={cadastrarConsulta} className="linha_form ">

                            <div>
                                <select
<<<<<<< HEAD
=======

>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                    className="input"
                                    name="idPaciente"
                                    value={idPaciente}
                                    onChange={(campo) => setIdPaciente(campo.target.value)}
                                >
<<<<<<< HEAD
                                    <option value="0">Selecione o paciente a ser consultado</option>

                                    {listaPaciente.map((consultas) => {
                                        return (
                                            <option key={consultas.idPaciente} value={consultas.idPaciente}>
                                                {consultas.idPacienteNavigation.nomePaciente}
=======
                                    <option value='0'>Selecione o paciente a ser consultadp</option>

                                    {listaPaciente.map((paciente) => {
                                        return (
                                            <option key={paciente.idPaciente} value={paciente.idPaciente}>
                                                {paciente.idPacienteNavigation.nomeMedico}
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                            </option>
                                        )
                                    })}
                                </select>
<<<<<<< HEAD
                                
=======
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                            </div>

                            <div>
                                <select

                                    className="input"
                                    name="idMedico"
                                    value={idMedico}
                                    onChange={(campo) => setIdMedico(campo.target.value)}
                                >
<<<<<<< HEAD
                                    <option value="0">Selecione o médico a consultar</option>

                                    {listaMedico.map((consultas) => {
                                        return (
                                            <option key={consultas.idMedico} value={consultas.idMedico}>
                                                {(consultas.idMedicoNavigation.nomeMedico)}
=======
                                    <option value='0'>Selecione o médico a consultar</option>

                                    {listaMedico.map((medico) => {
                                        return (
                                            <option key={medico.idMedico} value={medico.idMedico}>
                                                {medico.idMedicoNavigation.nomeMedico}
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                            </option>
                                        )
                                    })}
                                </select>
                            </div>

                            <div>
<<<<<<< HEAD
                                <label>Selecione a data da Consulta</label>
                                <input
                                    type="datetime-local"
                                    name="data"
                                    value={dataConsulta}
                                    onChange={(campo) => setDataConsulta(campo.target.value)}
=======
                                <label htmlFor="data">Data da Consulta</label>
                                <input
                                    type="datetime-local"
                                    name="data"
                                    value={dataConsul}
                                    onChange={(campo) => setDataConsul(campo.target.value)}
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                />
                            </div>

                            {isLoading && (
                                <button disabled className='btn' type='submit'>
                                    carregando...
                                </button>
                            )}
                            {!isLoading && (
                                <button className='btn' type='submit'>
                                    cadastrar consulta
                                </button>
                            )}
                        </form>
                    </section>
                </div>
            </div>

            <section className="fundo_consulta ">
                <div className="div_tabela ">
                    <section className="container_tabela ">
                        <h2>Consultas Agendadas</h2>
                        <table className="tabela ">
                            <thead>
                                <tr>
                                    <th>Médico</th>
                                    <th>Paciente</th>
                                    <th>Descrição</th>
                                    <th>Data</th>
                                </tr>
                            </thead>
                            <tbody>
                                {listaConsulta.map((consulta) => {
                                    return (
                                        <tr key={consulta.idConsulta}>
<<<<<<< HEAD
                                            <td>{"Paciente: " + (consulta.idPacienteNavigation.nomePaciente)}</td>
                                            <td>{"Médico: " + (consulta.idMedicoNavigation.nomeMedico)}</td>
                                            <td>{"Descrição: " + (consulta.descricao)}</td>
=======
                                            <td>{"Paciente: " + (item.idPacienteNavigation.nomePaciente)}</td>
                                            <td>{"Médico: " + (item.idMedicoNavigation.nomeMedico)}</td>
                                            <td>{"Descrição: " + (item.descricao)}</td>
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                            <td>{"Data : " + Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric',
                                                month: 'numeric',
                                                day: 'numeric',
                                                hour: 'numeric',
                                                minute: 'numeric',
                                                hour12: false
<<<<<<< HEAD
                                            }).format(new Date(consulta.dataConsulta))}</td>
=======
                                            }).format(new Date(item.dataConsulta))}</td>
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                        </tr>
                                    )
                                })}
                            </tbody>
                        </table>
                    </section>
                </div>
            </section>
        </main>
    )
}