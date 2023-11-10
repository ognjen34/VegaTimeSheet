import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { AddUser } from "../../services/UserService";

const CreateUserForm = ({}) => {
  const [email, setEmail] = useState("");
  const [workingHours, setWorkingHours] = useState("8");
  const [password, setPassword] = useState("");

  const [status, setStatus] = useState(0);
  const [role, setRole] = useState(0);
  const [name, setName] = useState("");

  const handleNameChange = (value) => {
    setName(value);
  };

  const handleStatusChange = (value) => {
    setStatus(value);
    console.log(status)

  };

  const handleWorkingHoursChange = (value) => {
    setWorkingHours(value);
  };

  const handleEmailChange = (value) => {
    setEmail(value);
  };

  const handleRoleChange = (value) => {
    setRole(value);
    console.log(role)
  };
  const handlePasswordChange = (value) => {
    setPassword(value);
  };
  const handleSaveClick = async () => {
    let newUser = {
      name: name,
      email: email,
      status: status,
      role: role,
      password: password,
      workingHours: workingHours,
    };
    console.log(newUser)
    try {
      await AddUser(newUser);
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
          <label>Email:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleEmailChange(e.target.value)}
          />
        </li>
        <li>
          <label>Password:</label>
          <input
            type="password"
            className="in-text"
            onChange={(e) => handlePasswordChange(e.target.value)}
          />
        </li>
        <li>
          <label>Hours per week:</label>
          <input
            type="text"
            className="in-text"
            onChange={(e) => handleWorkingHoursChange(e.target.value)}
          />
        </li>

        <li className="inline">
          <label>Status:</label>
          <span className="radio">
            <label htmlFor="inactive">Inactive:</label>
            <input
              type="radio"
              value="0"
              checked = {status == 0}
              name="status"
              id="inactive"
              onChange={() => handleStatusChange(0)}
            />
          </span>
          <span className="radio">
            <label htmlFor="active">Active:</label>
            <input
              type="radio"
              checked = {status == 1}
              value="1"
              name="status"
              id="active"
              onChange={() => handleStatusChange(1)}
            />
          </span>
        </li>
        <li className="inline">
          <label>Role:</label>
          <span className="radio">
            <label htmlFor="admin">Admin:</label>
            <input
              type="radio"
              value="0"
              name="role"
              checked = {role == 0}

              id="admin"
              onChange={() => handleRoleChange(0)}
            />
          </span>
          <span className="radio">
            <label htmlFor="worker">Worker:</label>
            <input
              type="radio"
              checked = {role == 1}
              value="1"
              name="role"
              id="worker"
              onChange={() => handleRoleChange(1)}
            />
          </span>
        </li>
      </ul>
      <div className="buttons">
        <BasicButton
          text={"Create team Member"}
          color={"#52a552"}
          onClick={handleSaveClick}
        />
      </div>
    </div>
  );
};

export default CreateUserForm;
