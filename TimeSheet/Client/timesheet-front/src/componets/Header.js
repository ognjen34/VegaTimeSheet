import React, { useState,useEffect } from "react";
import "./css/Header.css";
import Logo from "../assets/img/logo.png";
import { Logout } from "../services/UserService";
import { useNavigate ,Link} from "react-router-dom";

const Header = ({ username,role ,onNavClick,index}) => {
  const items = ["Change password", "Settings", "Export all data"];
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
    if (loggedOut) {
      console.log("bla")
      window.location.reload()
    }
    
  }, [loggedOut]);

  const secondListItems = role === 0 ? ["TimeSheet", "Clients", "Projects", "Categories", "Team members", "Reports"] : ["TimeSheet"];
  const Links = role === 0 ? ["timesheet", "clients", "projects", "categories", "members", "reports"] : ["timesheet"];


  const [activeIndex, setActiveIndex] = useState(index);

  const handleItemClick = (index) => {
    setActiveIndex(index);
    onNavClick(secondListItems[index])
  };

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
                    <a className='link'>{item}</a>
                  </li>
                ))}
              </ul>
            </div>
          </li>
          <li className="last">
            <a
            onClick={() => handleLogout()}
            >Logout</a>
          </li>
        </ul>
        <nav>
          <ul className="menu">
            {Links.map((item, index) => (
              <li key={index}>
                <Link to={item}>
                <a
                  className={`btn nav ${activeIndex === index ? "active" : ""}`}
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
