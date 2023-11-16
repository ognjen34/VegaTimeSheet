import {React,useEffect,useState} from "react";
import "./basic-items.css";

const BasicSelect = ({ label, callback, value,collection,selected,def,validation}) => {

  const [isValid, setValid] = useState(true);

  useEffect(() => {
    if (validation) {
    if (!value)
    {
      value = ""
    }
    const validateInput = () => {
      if (value == "") {
        setValid(false);
        validation(false)
        console.log(false)


      } else {
        setValid(true);
        validation(true)
        console.log(true)

      }
    };

    validateInput();
}}, [value]);

  return (
    <li>
      {label?<label>{label}:</label>:""}
      <select
        value={value}
        onChange={callback}
      >
        <option value="">{def}</option>
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
      {!isValid && (
        <div className="error-message">
          Please select a value
        </div>
      )}
    </li>
  );
};

export default BasicSelect;
