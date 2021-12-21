import { useState, useEffect } from "react";
<<<<<<< HEAD
import { useHistory } from "react-router-dom"
=======
import { Link, useHistory } from "react-router-dom"
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
import api from '../../services/api'
import '../../assets/css/paciente.css'
import logo from "../../assets/images/logo.png"

export default function Pacientes() {
    const [listarMinhas, setMinhasConsultas] = useState([]);
    const navigation = useHistory();

    function buscarMinhas() {
        api('/consultas/minhas', {
            headers: {
<<<<<<< HEAD
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
=======

                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
<<<<<<< HEAD
                    setMinhasConsultas(resposta.data)
=======
                    setMinhasConsultas(resposta.data.listarMinhas)
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                }
            })

            .catch(erro => console.log(erro))

    }
    useEffect(buscarMinhas, [])

    const logout = () => {
        localStorage.removeItem('usuario-login');
        navigation.push('/')
    }

    return (
        <main>

            <section className="fundo_consulta ">
                <img src={logo} alt="" />
                <div className="div_tabela ">
                    <section className="container_tabela ">
                        <h2>Suas Consultas</h2>
                        <div>
                            <button className='btn_sair' onClick={logout} >Sair</button>
                        </div>
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
                                {
                                    listarMinhas.map((consultas) => {
                                        return (
<<<<<<< HEAD
                                            <tr key={consultas.idConsulta}>
                                            <td>{"Paciente: " + (consultas.idPacienteNavigation.nomePaciente)}</td>
                                            <td>{"Médico: " + (consultas.idMedicoNavigation.nomeMedico)}</td>
                                            <td>{"Descrição: " + (consultas.descricao)}</td>
=======
                                            <tr key={consulta.idConsulta}>
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
                                            }).format(new Date(consultas.dataConsulta))}</td>
=======
                                            }).format(new Date(item.dataConsulta))}</td>
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                                        </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                </div>
            </section>
        </main>
    )
}