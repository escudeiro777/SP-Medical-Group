import { Link } from "react-router-dom";
import axios from 'axios';
import { useState, useEffect } from 'react';

import '../../assets/css/paciente.css'

import logo from '../../assets/images/logo.png'

export default function Pacientes() {
    const [listarMinhasConsultas, setMinhasConsultas] = useState([]);

    function BuscarMinhasConsultas() {
        axios('http://localhost:5000/api/Consultas/minhas', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setMinhasConsultas(resposta.data.listarConsultas)
                }
            })
            .catch(erro => console.log("erro ao buscar as consultas"))

    }
    useEffect(buscarMinhasConsultas, [])

    return (
    
)
}