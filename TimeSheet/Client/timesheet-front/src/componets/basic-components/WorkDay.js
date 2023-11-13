import { React, useState, useEffect } from "react";
import "./basic-items.css";
import { GetClientProjects } from "../../services/ProjectService";
import BasicSelect from "./BasicSelect";
const WorkDay = ({ workDay, clients, categories }) => {
  const [client, setClient] = useState(workDay ? workDay.clientId : "");
  const [project, setProject] = useState(workDay ? workDay.projectId : "");
  const [category, setCategory] = useState(workDay ? workDay.clientId : "");
  const [description, setDescription] = useState(
    workDay ? workDay.description : ""
  );
  const [time, setTime] = useState(workDay ? workDay.time : 0);
  const [overtime, setOvertime] = useState(workDay ? workDay.overtime : 0);
  const [projects, setProjects] = useState([]);
  console.log(workDay);

  useEffect(() => {
    if (workDay) {
      setClient(workDay.clientId)
      setProject(workDay.projectId);
      setCategory(workDay.categoryId);
      setDescription(workDay.description);
      setTime(workDay.time);
      setOvertime(workDay.overtime);
    }
  }, [workDay]);



  useEffect(() => {
    async function fetchData() {
      try {
        if (client == "") return;

        const response = await GetClientProjects(client);

        setProjects(response.data);
      } catch (error) {}
    }

    fetchData();
  }, [client]);

  const handleClientChange = (value) => {
    setClient(value);
  };
  const handleProjectChange = (value) => {
    setProject(value);
  };
  const handleCategoryChange = (value) => {
    setCategory(value);
  };
  const handleDescriptionChange = (value) => {
    setDescription(value);
  };
  const handleTimeChange = (value) => {
    setTime(value);
  };
  const handleOvertimeChange = (value) => {
    setOvertime(value);
  };
  return (
    <div className="work-day">
      <tr>
        <td>
        <BasicSelect
          def = {"Select Customer"}
          collection={clients}
          value={client}
          selected={client.name}
          callback={(e) => setClient(e.target.value)}
        />
        </td>
        <td>
        <BasicSelect
          def = {"Select Project"}
          collection={projects}
          value={project}
          selected={project.name}
          callback={(e) => setProject(e.target.value)}
        />
        </td>
        <td>
        <BasicSelect
          def = {"Select Category"}
          collection={categories}
          value={category}
          selected={category.name}
          callback={(e) => setCategory(e.target.value)}
        />
        </td>
        <td>
          <input
            type="text"
            className="in-text medium"
            value={description}
            onChange={(e) => handleDescriptionChange(e.target.value)}
          />
        </td>
        <td class="small">
          <input
            type="text"
            className="in-text xsmall"
            value={time}
            onChange={(e) => handleTimeChange(e.target.value)}
          />
        </td>
        <td class="small">
          <input
            type="text"
            className="in-text xsmall"
            value={overtime}
            onChange={(e) => handleOvertimeChange(e.target.value)}
          />
        </td>
      </tr>
    </div>
  );
};

export default WorkDay;
