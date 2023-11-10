import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { UpdateProject } from "../../services/ProjectService";
import { UpdateUser } from "../../services/UserService";

const UpdateUserForm = ({ user }) => {
  const [email, setEmail] = useState(user.email);
  const [workingHours, setWorkingHours] = useState(user.workingHours);
  const [status, setStatus] = useState(user.status);
  const [role, setRole] = useState(user.role);
  const [name, setName] = useState(user.name);



  const handleNameChange = (value) => {
    setName(value);
  };

  const handleStatusChange = (value) => {
    setStatus(value);
  };

  const handleWorkingHoursChange = (value) => {
    setWorkingHours(value);
  };

  const handleEmailChange = (value) => {
    setEmail(value);
  };

  const handleRoleChange = (value) => {
    setRole(value);
  };
  const handleSaveClick = async () => {
    let updatedUser = 
    {
        id : user.id,
        name:name,
        email:email,
        status:status,
        role:role,
        workingHours:workingHours,
     
      
    }
    try {
      await UpdateUser(updatedUser)
      window.location.reload()

    } catch (error) {
      console.error("Error during update:", error);
    }

    
  };

  return (
    <div className="form-wrap">
      <ul className="form">
        <li>
          <label>Name:</label>
          <input type="text" className="in-text" value={name}
          onChange={(e) => handleNameChange(e.target.value)}
           />
        </li>
        <li>
          <label>Hours per week:</label>
          <input type="text" className="in-text" value={workingHours}
          onChange={(e) => handleWorkingHoursChange(e.target.value)}
           />
        </li>
      </ul>
      <ul className="form">
        <li>
          <label>Email:</label>
          <input
            type="text"
            className="in-text"
            value={email}
            onChange={(e) => handleEmailChange(e.target.value)}
          />
        </li>
      </ul>
      <ul className="form last">
      <li className="inline">
          <label>Status:</label>
          <span className="radio">
            <label htmlFor={"inactive" + user.id}>Inactive:</label>
            <input
              type="radio"
              value="0"
              name={"status-" + user.id}
              id={"inactive" + user.id}
              checked={status == 0}
              onChange={() => handleStatusChange(0)}
            />
          </span>
          <span className="radio">
            <label htmlFor={"active" + user.id}>Active:</label>
            <input
              type="radio"
              value="1"
              name={"status-" + user.id}
              id={"active" + user.id}
              checked={status == 1}
              onChange={() => handleStatusChange(1)}
            />
          </span>
          
        </li>
        <li className="inline">
          <label>Status:</label>
          <span className="radio">
            <label htmlFor={"admin" + user.id}>Admin:</label>
            <input
              type="radio"
              value="0"
              name={"role-" + user.id}
              id={"admin" + user.id}
              checked={role == 0}
              onChange={() => handleRoleChange(0)}
            />
          </span>
          <span className="radio">
            <label htmlFor={"worker" + user.id}>Worker:</label>
            <input
              type="radio"
              value="1"
              name={"role-" + user.id}
              id={"worker" + user.id}
              checked={role == 1}
              onChange={() => handleRoleChange(1)}
            />
          </span>
         
        </li>
      </ul>
      <BasicButton color="#52a552" text="Save" onClick={handleSaveClick} />
      <BasicButton color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateUserForm;
