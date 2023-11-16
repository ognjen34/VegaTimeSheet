import React, { useState, useEffect, useMemo } from "react";
import "./css/Header.css";
import Logo from "../assets/img/logo.png";
import { Logout } from "../services/UserService";
import { useNavigate, Link } from "react-router-dom";
import { useCallback } from "react";

const items = ["Change password", "Settings", "Export all data"];

const Header = ({ username, role, onNavClick, index }) => {
  const [isUserMenuVisible, setUserMenuVisible] = useState(false);
  const navigate = useNavigate();

  const [loggedOut, setLoggedOut] = useState(false);

  const handleUserHover = () => {
    setUserMenuVisible(true);
  };

  const handleUserLeave = () => {
    setUserMenuVisible(false);
  };

  const handleLogout = async () => {
    try {
      await Logout();
      setLoggedOut(true);
    } catch (error) {
      console.error("Error during login:", error);
    }
  };

  useEffect(() => {
    if (!loggedOut) return;

    window.location.reload();
  }, [loggedOut]);

  const secondListItems = useMemo(
    () =>
      role === 0
        ? [
            "TimeSheet",
            "Clients",
            "Projects",
            "Categories",
            "Team members",
            "Reports",
          ]
        : ["TimeSheet"],
    [role]
  );

  const Links =
    role === 0
      ? ["timesheet", "clients", "projects", "categories", "members", "reports"]
      : ["timesheet"];

  const [activeIndex, setActiveIndex] = useState(index);

  const handleItemClick = useCallback(
    (index) => {
      setActiveIndex(index);
      onNavClick(secondListItems[index]);
    },
    [secondListItems, onNavClick]
  );

  return (
    <header className="header">
      <div className="top-bar"></div>
      <div className="wrapper">
        <a className="logo">
          <img src={Logo} alt="VegaITSourcing Timesheet" />
        </a>
        <ul className="user right">
          <li onMouseEnter={handleUserHover}>
            <a className="user-name">{username}</a>
            <div className="invisible" style={{ display: "none" }}></div>
            <div
              className="user-menu"
              onMouseLeave={handleUserLeave}
              style={{ display: isUserMenuVisible ? "block" : "none" }}
            >
              <ul>
                {items.map((item, index) => (
                  <li key={index}>
                    <a className="link">{item}</a>
                  </li>
                ))}
              </ul>
            </div>
          </li>
          <li className="last">
            <a onClick={() => handleLogout()}>Logout</a>
          </li>
        </ul>
        <nav>
          <ul className="menu">
            {Links.map((item, index) => (
              <li key={index}>
                <Link to={item}>
                  <a
                    className={`btn nav ${
                      activeIndex === index ? "active" : ""
                    }`}
                    onClick={() => handleItemClick(index)}
                  >
                    {secondListItems[index]}
                  </a>
                </Link>
              </li>
            ))}
          </ul>
          <span className="line"></span>
        </nav>
      </div>
    </header>
  );
};

export default Header;
