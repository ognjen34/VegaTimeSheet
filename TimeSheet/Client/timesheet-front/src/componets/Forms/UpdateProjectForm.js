import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { UpdateProject } from "../../services/ProjectService";

const UpdateProjectForm = ({ project, users, clients }) => {
  const [status, setStatus] = useState(project.status);
  const [lead, setLead] = useState(project.leadId);
  const [description, setDescription] = useState(project.description);
  const [client, setClient] = useState(project.clientId);
  const [name, setName] = useState(project.name);
  const [clientName, setClientName] = useState(project.clientName);



  const handleNameChange = (value) => {
    setName(value);
  };

  const handleStatusChange = (value) => {
    setStatus(value);
  };

  const handleLeadChange = (value) => {
    setLead(value);
  };

  const handleDescriptionChange = (value) => {
    setDescription(value);
  };

  const handleClientChange = (value) => {
    setClient(value);
    setClientName(value.innerText)
    console.log(value)
  };
  const handleSaveClick = async () => {
    let updatedProject = 
    {
      id : project.id,
      name :name,
      description :description,
      clientId:client,
      leadId:lead,
      status :status
      
    }
    console.log(updatedProject)
    try {
      await UpdateProject(updatedProject);
      window.location.reload();
      

    } catch (error) {
      console.error("Error during update:", error);
    }

    
  };

  return (
    <div className="form-wrap">
      <ul className="form">
        <li>
          <label>Project name:</label>
          <input type="text" className="in-text" value={name}
          onChange={(e) => handleNameChange(e.target.value)}
           />
        </li>
        <li>
          <label>Lead:</label>
          <select value={lead} onChange={(e) => handleLeadChange(e.target.value)}>
            {users.map((user, index) => (
              <option key={index} value={user.id}>
                {user.name}
              </option>
            ))}
          </select>
        </li>
      </ul>
      <ul className="form">
        <li>
          <label>Description:</label>
          <input
            type="text"
            className="in-text"
            value={description}
            onChange={(e) => handleDescriptionChange(e.target.value)}
          />
        </li>
      </ul>
      <ul className="form last">
        <li>
          <label>Customer:</label>
          <select value={client} onChange={(e) => handleClientChange(e.target.value)}>
            {clients.map((item, index) => (
              <option key={index} value={item.id}
              selected = {item.name == clientName}
              >
                {item.name}
              </option>
            ))}
          </select>
        </li>
        <li className="inline">
          <label>Status:</label>
          <span className="radio">
            <label htmlFor={"active" + project.id}>Active:</label>
            <input
              type="radio"
              value="0"
              name={"status-" + project.id}
              id={"active" + project.id}
              checked={status == 0}
              onChange={() => handleStatusChange(0)}
            />
          </span>
          <span className="radio">
            <label htmlFor={"inactive" + project.id}>Inactive:</label>
            <input
              type="radio"
              value="1"
              name={"status-" + project.id}
              id={"inactive" + project.id}
              checked={status == 1}
              onChange={() => handleStatusChange(1)}
            />
          </span>
          <span className="radio">
            <label htmlFor={"archive" + project.id}>Archive:</label>
            <input
              type="radio"
              value="2"
              name={"status-" + project.id}
              id={"archive" + project.id}
              checked={status == 2}
              onChange={() => handleStatusChange(2)}
            />
          </span>
        </li>
      </ul>
      <BasicButton color="#52a552" text="Save" onClick={handleSaveClick} />
      <BasicButton color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateProjectForm;
