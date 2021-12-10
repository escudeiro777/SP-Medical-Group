import React, { Component, useState, useEffect } from 'react';
import { FlatList, Image, ImageBackground, StyleSheet, Text, TouchableOpacity, View } from 'react-native';
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

  logout = async () => {
    await AsyncStorage.removeItem('userToken');
    this.props.navigation.navigate('Login');
  }

  render() {
    return (
      <ImageBackground
        source={require('../../assets/images/fundoLista.png')}
        style={StyleSheet.absoluteFillObject}
      >

        <View style={styles.wrapper}>
          <Text style={styles.nomePage}>Suas consultas</Text>

          <TouchableOpacity onPress={this.logout} >
            <Image source={require('../../assets/images/iconSair.png')}
              style={styles.logout}
            >
            </Image>
          </TouchableOpacity>


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
    <View style={styles.teste}>
      <View style={styles.card}>
        <View style={styles.tituloCardWrapper}>
          <Text style={styles.tituloCard}>Consulta: {item.idConsulta}</Text>
        </View>
        <View style={styles.textoWrapper}>
          <View style={styles.container_dados}>
            <Text style={styles.flatInfo}>{"Paciente: " + (item.idPacienteNavigation.nomePaciente)}</Text>
            <Text style={styles.flatInfo}>{"Médico: " + (item.idMedicoNavigation.nomeMedico)}</Text>
            <Text style={styles.flatInfo}>{"Descrição: " + (item.descricao)}</Text>
            <Text style={styles.flatInfo}>{"Data : " + Intl.DateTimeFormat("pt-BR", {
              year: 'numeric',
              month: 'numeric',
              day: 'numeric',
              hour: 'numeric',
              minute: 'numeric',
              hour12: false
            }).format(new Date(item.dataConsulta))}</Text>

          </View>
        </View>
      </View>
    </View>

  )
};

const styles = StyleSheet.create({
  wrapper: {
    alignItems: 'center'
  },

  logout: {
    padding: 5,
    paddingLeft: 8,
    marginLeft: 8
  },

  nomePage: {
    fontSize: 35,
    color: "#fff",
    marginTop: "10%",
    fontWeight: "bold"
  },

  containerFlatlist: {
    containerFlatList: {
      flex: 1,
      alignItems: 'center',
      justifyContent: 'center',
      marginTop: 20
    },
  },
  tituloCardWrapper:
  {
    backgroundColor: '#6A49E3',
    height: 50,
    width: 315,
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 30,
    
  },

  tituloCard: {
    color: "#000",
    fontSize: 20,
    
  },

  flatInfo: {
    color: "#000",
    marginTop:5,
    marginBottom:5,
    marginLeft:10
  },


  container_dados:{
    backgroundColor:"#fff",
    borderBottomStartRadius:10,
    borderBottomRightRadius:10
  }
})