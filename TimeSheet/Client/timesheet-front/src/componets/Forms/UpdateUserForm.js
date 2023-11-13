import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { UpdateProject } from "../../services/ProjectService";
import { UpdateUser } from "../../services/UserService";
import BasicInput from "../basic-components/BasicInput";
import BasicRadioButton from "../basic-components/BasicRadioButton";

const UpdateUserForm = ({ user }) => {
  const [newUser, setNewUser] = useState(user);
  const handleChangeUser = (value, inputType) => {

    setNewUser((prevUser) => ({
      ...prevUser,
      [inputType]: value,
    }));
  };
  

  const handleSaveClick = async () => {
    let updatedUser = {
      id: newUser.id,
      name: newUser.name,
      email: newUser.email,
      status: newUser.status,
      role: newUser.role,
      workingHours: newUser.workingHours,
    };
    console.log(updatedUser);
    try {
      await UpdateUser(updatedUser);
      window.location.reload();
    } catch (error) {
      console.error("Error during update:", error);
    }
  };

  return (
    <div className="form-wrap">
      <ul className="form">
        <BasicInput
          type={"text"}
          label={"Name: "}
          callback={(e) => handleChangeUser(e.target.value,"name")}
          value={newUser.name}
        />
        <BasicInput
          type={"text"}
          label={"Hours per week: "}
          callback={(e) => handleChangeUser(e.target.value,"workingHours")}
          value={newUser.workingHours}
        />
      </ul>
      <ul className="form">
        <BasicInput
          type={"text"}
          label={"Email: "}
          callback={(e) => handleChangeUser(e.target.value,"email")}
          value={newUser.email}
        />
      </ul>
      <ul className="form last">
        <BasicRadioButton
          label={"Status: "}
          choices={["Inactive", "Active"]}
          value={newUser.status}
          identificator={newUser.id}
          callback={(status) => handleChangeUser(status,"status")}
        />
        <BasicRadioButton
          label={"Role: "}
          choices={["Admin", "Worker"]}
          value={newUser.role}
          identificator={newUser.id}
          callback={(role) => handleChangeUser(role,"role")}
        />
      </ul>
      <BasicButton color="#52a552" text="Save" onClick={handleSaveClick} />
      <BasicButton color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateUserForm;
