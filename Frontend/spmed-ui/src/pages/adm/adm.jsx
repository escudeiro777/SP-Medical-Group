import React from "react";
import { useState, useEffect } from "react";
import { Link, useHistory } from "react-router-dom"
// import api from '../../services/api'
import '../../assets/css/adm_cadastro.css'
// import logo from "../../assets/images/logo.png"
import axios from "axios";

export default function Adm() {
    const [listaConsulta, setListaConsulta] = useState([]);
    const [listaMedico, setListaMedico] = useState([]);
    const [listaPaciente, setListaPaciente] = useState([]);
    const [idMedico, setIdMedico] = useState([]);
    const [idPaciente, setIdPaciente] = useState([]);
    const [dataConsulta, setDataConsulta] = useState([]);
    const navigation = useHistory();
    const [isLoading, setisLoading] = useState(false);

    useEffect(ListarConsultas, []);
    useEffect(ListarMedicos, []);
    useEffect(ListarPacientes, []);

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

    function ListarConsultas() {
        axios('http://http://192.168.0.112:5000/api/consultas', {
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

    function ListarMedicos() {
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



    return (
        <main className=" container ">
            <div className="background ">
                <div className="grid ">
                    <img className="logo " src="./assets/logo.png " alt="Logo Sp Medical Group "></img>
                    <section className="container_form ">
                        <h1>Cadastro de consulta</h1>
                        <div>
                            <button className='btn_sair' onClick={logout} >Sair</button>
                        </div>
                        <form onSubmit={cadastrarConsulta} className="linha_form ">

                            <div>
                                <select
                                    className="input"
                                    name="idPaciente"
                                    value={idPaciente}
                                    onChange={(campo) => setIdPaciente(campo.target.value)}
                                >
                                    <option value="0">Selecione o paciente a ser consultado</option>

                                    {listaPaciente.map((consultas) => {
                                        return (
                                            <option key={consultas.idPaciente} value={consultas.idPaciente}>
                                                {consultas.idPacienteNavigation.nomePaciente}
                                            </option>
                                        )
                                    })}
                                </select>
                                
                            </div>

                            <div>
                                <select

                                    className="input"
                                    name="idMedico"
                                    value={idMedico}
                                    onChange={(campo) => setIdMedico(campo.target.value)}
                                >
                                    <option value="0">Selecione o médico a consultar</option>

                                    {listaMedico.map((consultas) => {
                                        return (
                                            <option key={consultas.idMedico} value={consultas.idMedico}>
                                                {(consultas.idMedicoNavigation.nomeMedico)}
                                            </option>
                                        )
                                    })}
                                </select>
                            </div>

                            <div>
                                <label>Selecione a data da Consulta</label>
                                <input
                                    type="datetime-local"
                                    name="data"
                                    value={dataConsulta}
                                    onChange={(campo) => setDataConsulta(campo.target.value)}
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
                                            <td>{"Paciente: " + (consulta.idPacienteNavigation.nomePaciente)}</td>
                                            <td>{"Médico: " + (consulta.idMedicoNavigation.nomeMedico)}</td>
                                            <td>{"Descrição: " + (consulta.descricao)}</td>
                                            <td>{"Data : " + Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric',
                                                month: 'numeric',
                                                day: 'numeric',
                                                hour: 'numeric',
                                                minute: 'numeric',
                                                hour12: false
                                            }).format(new Date(consulta.dataConsulta))}</td>
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