import React, { useState } from "react";
import './css/HomePage.css'
import Header from './Header';
import Footer from "./Footer";
import { Outlet } from "react-router-dom";

const HomePage = ({user}) => {
  const [currentPage, setCurrentPage] = useState("TimeSheet");


  const handleDataFromHeader = (page) => {
  setCurrentPage(page)  
};

    return (
  <div>
    <Header username = {user.name} role = {user.role} onNavClick = {handleDataFromHeader} index = {0}></Header>
    <div className="wrapper">
    <section className="content">
				<h2><i className="ico timesheet"></i>{currentPage}</h2>
        <Outlet />
        </section>
    </div>
    <Footer></Footer>
  </div>
    );
  };
  
  export default HomePage;