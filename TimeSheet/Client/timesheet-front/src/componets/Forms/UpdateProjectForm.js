import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { UpdateProject } from "../../services/ProjectService";
import BasicSelect from "../basic-components/BasicSelect";
import BasicInput from "../basic-components/BasicInput";
import BasicRadioButton from "../basic-components/BasicRadioButton";


const UpdateProjectForm = ({ project, users, clients }) => {
  const [newProject, setNewProject] = useState(project);

  const handleProjectChange = (value, inputType) => {
    setNewProject((prevProject) => ({
      ...prevProject,
      [inputType]: value,
    }));
  };

  const handleSaveClick = async () => {
    let updatedProject = {
      id: project.id,
      name: newProject.name,
      description: newProject.description,
      clientId: newProject.clientId,
      leadId: newProject.leadId,
      status: newProject.status,
    };
    console.log(updatedProject);
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
        <BasicInput
          type={"text"}
          label={"Project Name: "}
          callback={(e) => handleProjectChange(e.target.value, "name")}
          value={newProject.name}
        />
        <BasicSelect
          label={"Lead"}
          collection={users}
          value={newProject.leadId}
          selected={newProject.leadName}
          callback={(e) => handleProjectChange(e.target.value, "leadId")}
        />
      </ul>
      <ul className="form">
        <BasicInput
          type={"text"}
          label={"Description: "}
          callback={(e) => handleProjectChange(e.target.value, "description")}
          value={newProject.description}
        />
      </ul>
      <ul className="form last">
        <BasicSelect
          label={"Customer"}
          collection={clients}
          value={newProject.client}
          selected={newProject.clientName}
          callback={(e) => handleProjectChange(e.target.value, "clientId")}
        />
        <BasicRadioButton
          label={"Status: "}
          choices={["Inactive", "Active", "Archive"]}
          value={newProject.status}
          identificator={newProject.id}
          callback={(status) => handleProjectChange(status, "status")}
        />
      </ul>
      <BasicButton color="#52a552" text="Save" onClick={handleSaveClick} />
      <BasicButton color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateProjectForm;
