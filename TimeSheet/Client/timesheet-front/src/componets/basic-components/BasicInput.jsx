import React, { useState, useEffect } from "react";
import "./basic-items.css";

const BasicInput = ({ type, label, callback, value, minLength }) => {
  const [isValid, setValid] = useState(true);

  useEffect(() => {
    const validateInput = () => {
      if (minLength && value?.length < minLength) {
        setValid(false);
      } else {
        setValid(true);
      }
    };

    validateInput();
  }, [value, minLength]);

  return (
    <li>
      <label>{label}</label>
      <input
        type={type}
        className={`in-text ${isValid ? "" : "invalid"}`}
        value={value}
        onChange={callback}
      />
      {!isValid && (
        <div className="error-message">
          Minimum length is {minLength} characters
        </div>
      )}
    </li>
  );
};

export default BasicInput;
