import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { AddUser } from "../../services/UserService";
import { AddProject } from "../../services/ProjectService";
import { AddCategory } from "../../services/CategoryService";

const CreateCategoryForm = ({clients,users}) => {
    
    const [name, setName] = useState("");
  

  const handleSaveClick = async () => {
    let newCategory = {
      name:name,
      
    };
    console.log(newCategory)

    await AddCategory(newCategory)
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
            onChange={(e) => setName(e.target.value)}
          />
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

export default CreateCategoryForm;
