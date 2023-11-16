import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { AddUser } from "../../services/UserService";
import { AddProject } from "../../services/ProjectService";

const CreateProjectForm = ({clients,users}) => {
    const [lead, setLead] = useState(users[0].id);
    const [description, setDescription] = useState("");
    const [client, setClient] = useState(clients[0].id);
    const [name, setName] = useState("");
  
  
  
    const handleNameChange = (value) => {
      setName(value);
    };

  
    const handleLeadChange = (value) => {
      setLead(value);
    };
  
    const handleDescriptionChange = (value) => {
      setDescription(value);
    };
  
    const handleClientChange = (value) => {
      setClient(value);
    };
  const handleSaveClick = async () => {
    let newProject = {
      name:name,
      description :description,
      leadId :lead,
      clientId :client,
      status : 1
    };
    console.log(newProject)

    await AddProject(newProject)
    try {
    } catch (error) {
      console.error("Error during update:", error);
    }
  };

  return (
    <div className="form">
      <ul className="form">
        <li>
          <label>Name:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleNameChange(e.target.value)}
          />
        </li>
        <li>
          <label>description:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleDescriptionChange(e.target.value)}
          />
        </li>
        <li>
          <label>Customer:</label>
          <select
            value={client}
            onChange={(e) => handleClientChange(e.target.value)}
          >
            {clients.map((item, index) => (
              <option
                key={index}
                value={item.id}
              >
                {item.name}
              </option>
            ))}
          </select>
        </li>
        <li>
          <label>Lead:</label>
          <select
            value={lead}
            onChange={(e) => handleLeadChange(e.target.value)}
          >
            {users.map((user, index) => (
              <option key={index} value={user.id}>
                {user.name}
              </option>
            ))}
          </select>
        </li>

      </ul>
      <div className="buttons">
        <BasicButton
          text={"Create Project"}
          color={"#52a552"}
          onClick={handleSaveClick}
        />
      </div>
    </div>
  );
};

export default CreateProjectForm;
