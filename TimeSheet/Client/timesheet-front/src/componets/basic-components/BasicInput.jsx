import React from "react";
import "./basic-items.css";

const BasicInput = ({ type, label, callback, value }) => {
  return (
    <li>
      <label>{label}</label>
      <input
        type={type}
        className="in-text"
        value={value}
        onChange={callback}
      />
    </li>
  );
};

export default BasicInput;
