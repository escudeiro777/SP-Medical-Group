import { Component } from 'react';
import api from "../../services/api";
import { parseJwt } from "../../services/auth";
import '../../assets/css/style.css'
import logo from "../../assets/images/logo.png"

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      erroMensagem: '',
      isLoading: false,
    };
  }
  login = (evento) => {
<<<<<<< HEAD
    // console.log('teste')
=======
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
    evento.preventDefault();
    this.setState({ erroMensagem: "", isLoading: true })
    api.post('/login', {
      email: this.state.email,
      senha: this.state.senha,
    })

<<<<<<< HEAD
      // .then(resposta => console.log(resposta))
      .then((resposta) => {
        if (resposta.status === 200) {

          localStorage.setItem('usuario-login', resposta.data.token);
          this.setState({ isLoading: false });
          // console.log(parseJwt().role)

          if (parseJwt().role === '1') {
            this.props.history.push('/adm')
          }

          else if (parseJwt().role === '2') {
            this.props.history.push('/medico')
          }

          else if (parseJwt().role == 3) {
            this.props.history.push('/paciente')
          }
        }
=======
      .then((resposta) => {
        if (resposta.status === 200) {
          localStorage.setItem('usuario-login', resposta.data.token);
          this.setState({ isLoading: false });
          if (parseJwt().role === 1) {
            this.props.history.push('/adm')
          }
          else if (parseJwt().role === 2)
            this.props.history.push('/medico')
        }
        else if (parseJwt().role === 3)
          this.props.history.push('/paciente')
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
      })
      .catch(() => {
        this.setState({
          erroMensagem: "Dados inválidos",
          isLoading: false
        });
      });
  };
  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value });
  }

  render() {
    return (
      <main>
        <div className="div_de_tudo">
          <img className="logo" src={logo} alt="Logo Sp Medical Group" />
          <div className="grupo_login_txt">
            <h1 >Acesse agora a sua conta!</h1>
            <div className="grupo_login">
              <h1 className="txt_login">login</h1>
              <form onSubmit={this.login} className="Form_Login">
                <input value={this.state.email} onChange={this.atualizaStateCampo} name='email' placeholder="email" type="email" />
                <input value={this.state.senha} onChange={this.atualizaStateCampo} name='senha' placeholder="senha" type="password" />

<<<<<<< HEAD
                <p className="erroMensagem" style={{ color: 'red' }}>{this.state.erroMensagem}</p>
=======
                <p className ="erroMensagem" style={{ color: 'red' }}>{this.state.erroMensagem}</p>
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                {
                  this.state.isLoading === true && (<button className="btn"
                    type="submit"
                    disabled
                    id="btn_login"
                  >carregando...</button>)}
                {
                  this.state.isLoading === false && (
                    <button
<<<<<<< HEAD
                      className='btn'
=======
                    className='btn'
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
                      type="submit"
                      disabled={
                        this.state.email === '' || this.state.senha === ''
                          ? 'none'
                          : ''
                      }
                      id="btn_login"

                    >
                      entrar
                    </button>
                  )
                }
              </form>
            </div>
          </div>
        </div>
      </main>
    );
  }
}

