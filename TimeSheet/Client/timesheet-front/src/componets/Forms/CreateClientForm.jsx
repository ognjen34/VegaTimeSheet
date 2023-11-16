import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { AddUser } from "../../services/UserService";
import { AddProject } from "../../services/ProjectService";
import { AddClient } from "../../services/ClientsService";

const CreateClientForm = ({countries}) => {
    const [name, setName] = useState("");
    const [address, setAddress] = useState("");
    const [city, setCity] = useState("");
    const [zip, setZip] = useState("");
    const [countryid, setCountryId] = useState(countries[0].id);
  
    const handleNameChange = (value) => {
      setName(value);
    };
  
    const handleAddressChange = (value) => {
      setAddress(value);
    };
  
    const handleCityChange = (value) => {
      setCity(value);
    };
  
    const handleZipChange = (value) => {
      setZip(value);
    };
  
    const handleCountryChange = (value) => {
      setCountryId(value);
      console.log(value)
      
    };
  const handleSaveClick = async () => {
    let newClient = {
        name :name,
        adress :address,
        city :city,
        zip:zip,
        countryid:countryid
    };
    console.log(newClient)

    await AddClient(newClient)
    try {
    } catch (error) {
      console.error("Error during update:", error);
    }
  };

  return (
    <div className="form">
      <ul className="form">
        <li>
          <label>Client name:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleNameChange(e.target.value)}
          />
        </li>
        <li>
          <label>Address:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleAddressChange(e.target.value)}
          />
        </li>
        <li>
          <label>City:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleCityChange(e.target.value)}
          />
        </li>
        <li>
          <label>Zip/Postal code:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleZipChange(e.target.value)}
          />
        </li>
        <li>
          <label>Country:</label>
          <select
            value={countryid}
            onChange={(e) => handleCountryChange(e.target.value)}
          >
            {countries.map((item, index) => (
              <option
                key={index}
                value={item.id}
              >
                {item.name}
              </option>
            ))}
          </select>
        </li>
        

      </ul>
      <div className="buttons">
        <BasicButton
          text={"Create Client"}
          color={"#52a552"}
          onClick={handleSaveClick}
        />
      </div>
    </div>
  );
};

export default CreateClientForm;
