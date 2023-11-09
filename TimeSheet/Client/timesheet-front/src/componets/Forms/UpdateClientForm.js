import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { UpdateProject } from "../../services/ProjectService";
import { UpdateClient } from "../../services/ClientsService";

const UpdateClientForm = ({ client, countries}) => {
  const [name, setName] = useState(client.name);
  const [address, setAddress] = useState(client.adress);
  const [city, setCity] = useState(client.city);
  const [zip, setZip] = useState(client.zip);
  const [countryid, setCountryId] = useState(client.country.id);

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
    let updatedClient = 
    {
        id:client.id,
        name :name,
        adress :address,
        city :city,
        zip:zip,
        countryid:countryid
    }
    console.log(updatedClient)
    
    try {
        await UpdateClient(updatedClient);
        window.location.reload();
    
      

    } catch (error) {
     
    }

    
  };

  return (
    <div className="form-wrap">
      <ul className="form">
        <li>
          <label>Client name:</label>
          <input type="text" className="in-text" value={name}
          onChange={(e) => handleNameChange(e.target.value)}
           />
        </li>
        <li>
          <label>Zip/Postal code:</label>
          <input type="text" className="in-text" value={zip}
          onChange={(e) => handleZipChange(e.target.value)}
           />
        </li>
      </ul>
      <ul className="form last">
        <li>
          <label>Address:</label>
          <input
            type="text"
            className="in-text"
            value={address}
            onChange={(e) => handleAddressChange(e.target.value)}
          />
        </li>
 
        <li>
          <label>Country:</label>
          <select value={countryid} onChange={(e) => handleCountryChange(e.target.value)}>
            {countries.map((item, index) => (
              <option key={index} value={item.id}
              selected = {item.name == client.country.name}
              >
                {item.name}
              </option>
            ))}
          </select>
        </li>
        </ul>
        <ul className="form last">
        <li>
          <label>City:</label>
          <input
            type="text"
            className="in-text"
            value={city}
            onChange={(e) => handleCityChange(e.target.value)}
          />
        </li>
        </ul>
        
      
      <BasicButton color="#52a552" text="Save" onClick={handleSaveClick} />
      <BasicButton color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateClientForm;
