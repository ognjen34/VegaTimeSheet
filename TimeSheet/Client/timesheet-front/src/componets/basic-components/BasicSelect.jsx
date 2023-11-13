import React from "react";
import "./basic-items.css";

const BasicSelect = ({ label, callback, value,collection,selected,def }) => {
  return (
    <li>
      {label?<label>{label}:</label>:""}
      <select
        value={value}
        onChange={callback}
      >
        <option value="none">{def}</option>
        {collection.map((item, index) => (
          <option
            key={index}
            value={item.id}
            selected={item.name == selected}
          >
            {item.name}
          </option>
        ))}
      </select>
    </li>
  );
};

export default BasicSelect;
