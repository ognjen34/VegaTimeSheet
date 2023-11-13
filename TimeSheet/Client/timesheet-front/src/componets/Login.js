import React, { useState } from "react";
import "./css/Login.css";
import Logo from "../assets/img/logo-large.png";
import BasicButton from "./basic-components/BasicButton";
import { SignIn } from "../services/UserService";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLoginClick = async () => {
    let user = {
      email: email,
      password: password,
      rememberMe: true,
    };
    try {
      const loggerUser = await SignIn(user);
      console.log(loggerUser);
      window.location.reload();
    } catch (error) {
      console.error("Error during login:", error);
    }
  };

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  return (
    <div className="wrapper centered">
      <div className="logo-wrap">
        <a href="index.html" className="inner">
          <img src={Logo} alt="Logo" />
        </a>
      </div>
      <div className="centered-content-wrap">
        <div className="centered-block">
          <h1>Login</h1>
          <ul>
            <li>
              <input
                type="text"
                placeholder="Email"
                className="in-text large"
                value={email}
                onChange={handleEmailChange}
              />
            </li>
            <li>
              <input
                type="password"
                placeholder="Password"
                className="in-pass large"
                value={password}
                onChange={handlePasswordChange}
              />
            </li>
            <li className="last">
              <input type="checkbox" className="in-checkbox" id="remember" />
              <label className="in-label" htmlFor="remember">
                Remember me
              </label>
              <span className="right">
                <a className="link">Forgot password?</a>
                <BasicButton
                  color={"#f67d34"}
                  text={"Login"}
                  onClick={handleLoginClick}
                />
              </span>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default Login;
