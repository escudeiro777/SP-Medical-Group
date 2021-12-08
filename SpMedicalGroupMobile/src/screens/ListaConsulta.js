import React, { Component, useState, useEffect } from 'react';
import {
  StyleSheet,
  Text,
  View,

  ImageBackground,
} from 'react-native';

import api from '../screens/services/api'
import AsyncStorage from '@react-native-async-storage/async-storage';
import { FlatList } from 'react-native-gesture-handler';

export default class ListaConsulta extends Component {
  constructor(props) {
    super(props)
    this.state = {
      listaConsultas: [],
    }
  }


  buscarConsultas = async () => {
    
    const token = await AsyncStorage.getItem('userToken');

    console.warn('buscar consultas')

    console.warn(token)

    const resposta = await api.get('/consultas/minhas', {
      headers: {
        Authorization: 'Bearer ' + token
      }

    })

    const dadosDaApi = resposta.data;
    this.setState({ listaConsultas: dadosDaApi });
  };

  componentDidMount() {
    this.buscarConsultas();
  };

  render() {
    return (
      <ImageBackground
        source={require('../../assets/images/fundoLista.png')}
        style={StyleSheet.absoluteFillObject}>
        
        
        <View style={styles.container}>
          <Text style={styles.nomePagina}> Suas consultas</Text>
          <View style={styles.containerFlatlist}>
            <FlatList
              contentContainerStyle={styles.mainBodyContent}
              data={this.state.listaConsultas}
              keyExtractor={item => item.idConsulta}
              renderItem={this.renderItem}
            />
          </View>
        </View>
      </ImageBackground>
    )
  }
  renderItem = ({ item }) => (

    <View style={styles.card}>
      <View style={styles.flatItems}>
        <Text style={styles.flatInfo}>{"Paciente: "+(item.idPacienteNavigation.nomePaciente)}</Text>
        <Text style={styles.flatInfo}>{"Médico: "+(item.idMedicoNavigation.nomeMedico)}</Text>
        <Text style={styles.flatInfo}>{"Descrição: "+(item.descricao)}</Text>
        <Text style={styles.flatInfo}>{"Data: "+Intl.DateTimeFormat("pt-BR", {
          year: 'numeric',
          month: 'numeric',
          day: 'numeric',
          hour: 'numeric',
          minute: 'numeric',
          hour12: false
        }).format(new Date(item.dataConsulta))})</Text>
      </View>
    </View>
  )
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center', 
},
nomePagina:{
  fontSize: 48,
  textAlign: 'center',
  marginTop:20,
  fontFamily: 'Open Sans',
  fontWeight:'800',
  color:"#fff"
},

mainBodyContent:{
  width: '100%',
},

containerFlatList: {
  flex: 1, 
  alignItems: 'center',
  justifyContent: 'center',
},


card:{
backgroundColor: '#fff',
alignItems: 'center',
width: '100%',
marginTop:20,
marginBottom: 30,
borderRadius:10
},

flatItem: {
  borderBottomWidth: 1,
  borderBottomColor: '#000',
  marginTop: 40,
  
},

flatInfo: {
  fontSize: 14,
  color: '#000',
  lineHeight: 24,
  fontFamily: 'TitilliumWeb-Regular',
}

})