import React, { Component ,useState, useEffect } from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import api from '../screens/services/api'
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class ListaConsulta extends Component {
  constructor(props) {
    super(props)
    this.state = {
      listaConsultas: [],
    }
  }


  buscarConsultas = async () => {
    const token = await AsyncStorage.getItem('userToken');
    if (token != null) {
      const resposta = await api.get('/consultas,', {
        headers: {
          Authorizations: 'Bearer' + token,
        }

      })

      const dadosDaApi = resposta.data;
      this.setState({ listaProjetos: dadosDaApi });

    }
  };

  componentDidMount() {
    this.buscarProjetos();
  };

  render() {
    return (
      <ImageBackground
      source ={require('../../assets/images/fundoLista.png')}
      style={StyleSheet.absoluteFillObject}
      />
    )
  }
}
