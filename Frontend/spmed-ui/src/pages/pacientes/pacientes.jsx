import { useState, useEffect } from "react";
import { Link, useHistory } from "react-router-dom"
import api from '../../services/api'
import '../../assets/css/paciente.css'
import logo from "../../assets/images/logo.png"

export default function Pacientes() {
    const [listarMinhas, setMinhasConsultas] = useState([]);
    const navigation = useHistory();

    function buscarMinhas() {
        api('/consultas/minhas', {
            headers: {

                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setMinhasConsultas(resposta.data.listarMinhas)
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
                                            <tr key={consulta.idConsulta}>
                                            <td>{"Paciente: " + (item.idPacienteNavigation.nomePaciente)}</td>
                                            <td>{"Médico: " + (item.idMedicoNavigation.nomeMedico)}</td>
                                            <td>{"Descrição: " + (item.descricao)}</td>
                                            <td>{"Data : " + Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric',
                                                month: 'numeric',
                                                day: 'numeric',
                                                hour: 'numeric',
                                                minute: 'numeric',
                                                hour12: false
                                            }).format(new Date(item.dataConsulta))}</td>
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