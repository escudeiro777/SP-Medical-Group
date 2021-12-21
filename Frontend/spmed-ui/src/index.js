import React from 'react';
import {  Route,  BrowserRouter as Router, Redirect, Switch} from "react-router-dom";
import ReactDOM from 'react-dom';
import './index.css';
import Pacientes from './pages/pacientes/pacientes';
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
      
      </Switch>
     
    </div>
  </Router>
)


ReactDOM.render(routing, document.getElementById('root'));
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

// ----------------------------------------------------------------------------------------------------------