import {Redirect} from "react-router-dom";

export const userAutenticated = () => localStorage.getItem('usuario-login') !==null
export const parseJwt = () =>{
    let base64 = localStorage.getItem('usuario-login').split(".")[1];

    return JSON.parse(window.atob(base64))
}

export function logout(){
    localStorage.removeItem('usuario-login')
}