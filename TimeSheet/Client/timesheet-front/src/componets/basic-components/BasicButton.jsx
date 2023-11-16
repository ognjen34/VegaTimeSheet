import React from "react";
import "./basic-items.css";

const BasicButton = ({ color, text, onClick }) => {
  return (
    <button
      className="basic-button"
      style={{ backgroundColor: color, borderColor: color }}
      onClick={onClick}
    >
      {text}
    </button>
  );
};

export default BasicButton;
