import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/autenticacao';
import '../../assets/css/style.css'
import logo from '../../assets/images/logo.png'


export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      mensagemDeErro: '',
      carregando: false,
    };
  }
  fazerLogin = (evento) => {
    evento.preventDefault();
    console.log(evento)

    this.setState({ mensagemDeErro: '', carregando: true })

    axios
      .post('http://localhost:5000/api/login', {
        email: this.state.email,
        senha: this.state.senha,
      })

      .then((resposta) => {
        if (resposta.status === 200) {
          localStorage.setItem('usuario-login', resposta.data.token);
          this.setState({ carregando: false });
          let base64 = localStorage.getItem('usuario-login').split[1];
          console.log(base64)
          console.log(this.props);

          console.log(parseJwt().role)
          if (parseJwt().role === '1') {
            this.props.history.push('/adm')
          }
          else if (parseJwt().role === '2') {
            this.props.history.push('/med')
          }
          else if (parseJwt().role === '3') {
            this.props.history.push('/pac')
          }
        }
      })

      .catch(() => {
        this.setState({
          mensagemDeErro: "Dados inválidos",
          carregando: false,
        });
      });
  };
  atualizarCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value });
  }
  render() {
    return (
      <main>
        <div className="div_de_tudo">
          <img className="logo" src={logo} alt="Logo Sp Medical Group"/>
          <div className="grupo_login_txt">
            <h1 className>Acesse agora a sua conta!</h1>
            <div className="grupo_login">
              <h1 className="txt_login">login</h1>
              <form onSubmit={this.fazerLogin} className="Form_Login">
                <input value={this.state.email }onChange={this.atualizarCampo} name='email' placeholder="email" type="email" />
                <input value={this.state.senha} onChange={this.atualizarCampo} name='senha' placeholder="senha" type="password" />
               
              <a className="esqueceu_senha" href="">Esqueceu sua senha?</a>
              <p style={{color:'red'}}>{this.state.mensagemDeErro}</p>{
                  this.state.carregando === true && (<button className="btn" 
                  type="submit"
                  disabled
                  id = "btn_login"
                  >carregando...</button>
                  )
                }
                {
                  this.state.carregando === false &&(
                    <button
                    type="submit"
                    disabled={
                      this.state.email === '' || this.state.senha === ''
                      ? 'none'
                      : ''
                    }
                    id = "btn_login"
                    
                    >
                      entrar
                    </button>
                  )
                }
              
              <p className="grupo_texto">não tem uma conta?<a className="link_cadastro" href="#">cadastre-se</a></p>
              </form>
            </div>
          </div>
        </div>
      </main>
    );
  }
}
