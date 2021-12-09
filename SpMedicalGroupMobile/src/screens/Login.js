import React, { useState, useEffect } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';


import AsyncStorage from '@react-native-async-storage/async-storage';

import api from './services/api'
import { useNavigation } from '@react-navigation/core';


export default function Login() {

    const [email, setEmail] = useState('mariana@email.com')
    const [senha, setSenha] = useState('777')
    const navigation = new useNavigation();


    realizarLogin = async () => {
        try {
            const resposta = await api.post('/login', {
                email: email,
                senha: senha
            })



            if (resposta.status == 200) {
                const token = resposta.data.token;
                await AsyncStorage.setItem('userToken', token);
               navigation.navigate('Consultas')
            }

        } catch (error) {
        }
    }


    return (
        <ImageBackground
            source={require('../../assets/images/backLogin.png')}
            style={StyleSheet.absoluteFillObject}
        >

            <View style={styles.loginContainer}>
                <View style={styles.loginWrapper}>

                    <Image
                        source={require('../../assets/images/logo.png')}
                        style={styles.logoLogin}
                    />
                    <View style={styles.inputContainer}>
                        <TextInput
                            placeholder="email"
                            keyboardType="email-address"
                            onChangeText={(campo) => setEmail(campo)}
                            value={email}
                            placeholderTextColor='rgba(9, 9, 9, 0.5)'
                            style={styles.inputLogin}
                        >
                        </TextInput>

                        <TextInput
                            placeholder="password"
                            keyboardType="default"
                            onChangeText={(campo) => setSenha(campo)}
                            value={senha}
                            placeholderTextColor='rgba(9, 9, 9, 0.5)'
                            style={styles.inputLogin}
                            secureTextEntry={true}>
                        </TextInput>

                        <TouchableOpacity
                            style={styles.btnLogin}
                            onPress={realizarLogin}
                        >
                            <Text style={styles.btnLoginText}>
                                Login
                            </Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </View>


        </ImageBackground>
    )
}
const styles = StyleSheet.create({
    loginContainer: {
        ...StyleSheet.absoluteFillObject,
        justifyContent: 'center'
    },

    loginWrapper: {
        width: '100%',
        height: 450,
        justifyContent: 'space-between',
        alignItems: 'center',
        marginTop:30

    },

    logo: {

        height: 80,
        width: 80,
    },

    inputContainer: {
        height: 160,
        justifyContent: 'space-between',
        marginBottom:40
    },

    inputLogin: {
        width: 229,
        height: 42,

        backgroundColor: 'rgba(255, 255, 255, 0.85)',
        borderRadius: 5,
    },

    btnLogin: {
        width: 229,
        height: 42,
        backgroundColor: '#64d19b',
        borderRadius: 5,
        alignItems: 'center',
        justifyContent: 'center',
        marginTop: 10
    },

    btnLoginText: {
        color: '#fff'
    }
})