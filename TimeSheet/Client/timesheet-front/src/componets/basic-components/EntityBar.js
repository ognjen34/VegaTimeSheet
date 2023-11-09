import React, { useState } from "react";
import "./basic-items.css";

const EntityBar = ({ text,text2, form}) => {
  const [detailsVisible, setDetailsVisible] = useState(false);

  const toggleDetails = () => {
    setDetailsVisible(!detailsVisible);
  };

  return (
    <div className="item">
      <div className="heading" onClick={toggleDetails}>
        <span>{text}</span>{" "}
        <span>
          <em>{text2}</em>
        </span>
      </div>
      <div className={`details ${detailsVisible ? 'slide-down' : 'slide-up'}`}>
        {form}
      </div>
    </div>
  );
};

export default EntityBar;
