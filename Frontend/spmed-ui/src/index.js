import React from 'react';
import {  Route,  BrowserRouter as Router, Redirect, Switch} from "react-router-dom";
import ReactDOM from 'react-dom';
import './index.css';
import Pacientes from './pages/pacientes/pacientes';
<<<<<<< HEAD
import Medicos from './pages/medico/medico';
import Adm from './pages/adm/adm';
import Login from './pages/login/login';
import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>

      <Switch>
      <Route exact path="/" component={Login} />
      <Route  path="/paciente" component={ Pacientes } />
      <Route  path="/medicos" component={ Medicos } />
      <Route  path="/adm" component={ Adm } />
      
=======
import Login from './pages/login/login';
import reportWebVitals from './reportWebVitals';

const routing=(
  <Router>
    <div>
      <Switch>
      <Route  path="/login" component={ Login } />
      <Route  path="/paciente" component={ Pacientes } />
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
      </Switch>
     
    </div>
  </Router>
)

<<<<<<< HEAD

ReactDOM.render(routing, document.getElementById('root'));
=======
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
<<<<<<< HEAD

// ----------------------------------------------------------------------------------------------------------
=======
// ----------------------------------------------------------------------------------------------------------
// import React from 'react';
// import ReactDOM from 'react-dom';
// import {  Route,  BrowserRouter as Router, Redirect, Switch} from 'react-router-dom';

// import './index.css';

// import Home from './pages/Home/App';
// import adm from './pages/consultasAdm/ConsultasAdm';
// import Login from './pages/Home/App';
// import Pacientes from './pages/pacientes/pacientes';
// import Medicos from './pages/medicos/medicos';
// import mapa from './pages/mapa/map';
// import cadastrarMapa from './pages/mapa/cadastroMapa';


// import reportWebVitals from './reportWebVitals';

// const routing=(
//   <Router>
//     <div>
//       <Switch>
//       <Route exact path="/" component={ Home } />
//       <Route  path="/consultasAdm" component={ adm } />
//       <Route  path="/login" component={ Login } />
//       <Route  path="/paciente" component={ Pacientes } />
//       <Route  path="/medicos" component={ Medicos } />
//       <Route  path="/cadastrarMapa" component={ cadastrarMapa } />
//       <Route  path="/notfound" component={ NotFound } />      
//       <Route  path="/mapa" component={ mapa } />      
//       <Redirect to="/notfound" />
//       </Switch>
     
//     </div>
//   </Router>
// )

// ReactDOM.render(  routing,  document.getElementById('root'));

// // If you want to start measuring performance in your app, pass a function
// // to log results (for example: reportWebVitals(console.log))
// // or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
// reportWebVitals();
>>>>>>> 2b697bc9163b4a0c7c9d759f99d196dcfbdac895
