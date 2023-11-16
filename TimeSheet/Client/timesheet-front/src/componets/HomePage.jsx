import React, { useState } from "react";
import { Outlet } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";
import "./css/HomePage.css";

const HomePage = ({ user }) => {
  const [currentPage, setCurrentPage] = useState("TimeSheet");

  const handleDataFromHeader = (page) => {
    setCurrentPage(page);
  };

  return (
    <>
      <Header
        username={user.name}
        role={user.role}
        onNavClick={handleDataFromHeader}
        index={0}
      />
      <div className="wrapper">
        <section className="content">
          <h2>
            <i className="ico timesheet"></i>
            {currentPage}
          </h2>
          <Outlet />
        </section>
      </div>
      <Footer />
    </>
  );
};

export default HomePage;
