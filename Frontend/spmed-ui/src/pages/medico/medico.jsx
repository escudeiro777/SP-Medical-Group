import { useState, useEffect } from "react";
import { useHistory } from "react-router-dom"
import api from '../../services/api'
import '../../assets/css/medico.css'
import logo from "../../assets/images/logo.png"

export default function Medicos() {
    const [listaMinhas, setMinhasConsultas] = useState([]);
    const [idConsulta, setIdConsultas] = useState(0)
    const [idMedico, setIdMedico] = useState(0)
    const [descricao, setDescricao] = useState('')
    const [isLoading, setIsLoading] = useState(false)
    const navigation = useHistory();

    useEffect(buscarMinhas, [])
    useEffect(alterarDescricao, [])


    function buscarMinhas() {
        api('/consultas/minhas', {
            headers: {

                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setMinhasConsultas(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }



    function alterarDescricao(evento) {
        setIsLoading(true)

        let novaDescricao = {
            idMedico: idMedico,
            descricao: descricao
        }

        api.patch('/consultas/descricao/{id}' + idConsulta, novaDescricao, {

            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Descrição Alterada')

                    buscarMinhas();
                    setIsLoading(false);
                }
            })
            .catch(erro => console.log(erro), setInterval(() => {
                setIsLoading(false);
            }, 5000));

        const logout = () => {
            localStorage.removeItem('usuario-login');
            navigation.push('/')
        }


        return (
            <main class="container">
                <section class="fundo_consulta">
                    <img class="logo" src={logo} alt="Logo Sp Medical Group"></img>
                    <div class="div_tabela">
                        <section class="container_tabela">
                            <h2>Listagem de Consultas</h2>
                            <div>
                                <button className='btn_sair' onClick={logout} >Sair</button>
                            </div>
                            <table class="tabela">
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
                                        listaMinhas.map((consulta) => {
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
                                        })
                                    }
                                </tbody>
                            </table>
                        </section>
                    </div>
                </section>
                <div class="background">
                    <div class="grid">
                        <section class="container_form">
                            <h1>Alterar Consulta</h1>
                            <form onSubmit={alterarDescricao} class="linha_form">
                                <select
                                    className="input_alterar"
                                    name="consulta"
                                    id="consulta"
                                    value={idConsulta}
                                    onChange={(campo) => setIdConsultas(campo.target.value)}
                                >
                                    <option value="0">Selecione a Consulta</option>

                                    {
                                        listaMinhas.map((consulta) => {
                                            return (
                                                <option key={consulta.idConsulta} value={consulta.idConsulta}>
                                                    {consulta.idPacienteNavigation.idUsuarioNavigation.nome} / Cpf:{consulta.idPacienteNavigation.cpf} / Data:{Intl.DateTimeFormat("pt-BR", {
                                                        year: 'numeric', month: 'numeric', day: 'numeric',
                                                        hour: 'numeric', minute: 'numeric', hour12: false
                                                    }).format(new Date(consulta.dataConsulta))}
                                                </option>
                                            )
                                        })}
                                </select>
                                <input type="text" placeholder="Nova Descrição" value={descricao} onChange={(campo) => setDescricao(campo.target.value)}></input>

                                {isLoading && (
                                    <button disabled className='btn' type='submit'>
                                        carregando...
                                    </button>
                                )}
                                {isLoading && (
                                    <button className='btn' type='submit'>
                                        alterar consulta
                                    </button>
                                )}

                            </form>
                        </section>
                    </div>
                </div>
            </main>
        )
    }
}