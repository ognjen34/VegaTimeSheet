import React from "react";
import "./basic-items.css";

const BasicRadioButton = ({ label, choices,value,identificator,callback}) => {
  return (
    <li className="inline">
          <label>{label}</label>
          {choices.map((choice, index) => (
            <span className="radio">
            <label htmlFor={choice + identificator}>{choice}:</label>
            <input
              type="radio"
              value={index}
              name={label+ identificator}
              id={choice + identificator}
              checked={value == index}
              onChange={() => callback(index)}
            />
          </span>
          ))}
          
          
        </li>
  );
};

export default BasicRadioButton;
