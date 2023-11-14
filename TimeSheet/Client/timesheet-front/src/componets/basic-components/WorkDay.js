import React, { useState, useEffect, useRef } from "react";
import "./basic-items.css";
import { GetClientProjects } from "../../services/ProjectService";
import BasicSelect from "./BasicSelect";
import useFetch from "../../services/useFetch";
import LoadingScreen from "./LetterButton";
import { ConvertDate, UpdateWorkHour } from "../../services/WorkHoursService";

const WorkDay = ({ workDay, clients, categories }) => {
  const [newWorkDay, setNewWorkDay] = useState(
    workDay ? workDay : { clientId: "" }
  );
  const [changes, setChanges] = useState(false);
  const [projects, setProjects] = useState([]);

  const timeoutIdRef = useRef(null);

  useEffect(() => {
    if (workDay) {
      setNewWorkDay(workDay);
    }
  }, [workDay]);

  const {
    projectData,
    isLoading: dataLoading,
    error: dataError,
  } = useFetch(
    {
      projectData: () => GetClientProjects(newWorkDay.clientId),
    },
    [newWorkDay.clientId]
  );

  useEffect(() => {
    if (!dataLoading) {
      console.log(projectData);
      console.log(workDay);
      if (projectData) {
        setProjects(projectData.data);
      }
    }
  }, [projectData, dataLoading]);

  useEffect(() => {
    if (!changes) return;
    clearTimeout(timeoutIdRef.current);

    timeoutIdRef.current = setTimeout(() => {
      saveWorkDay(newWorkDay);
    }, 1500);
  }, [newWorkDay]);

  const saveWorkDay = async (t) => {
    console.log(workDay);

    let saveWorkDay = {
      id : t.id,
      projectId: t.projectId,
      categoryId: t.categoryId,
      description: t.description,
      date: t.date,
      time: t.time,
      overtime: t.overtime,
      userId: t.userId,
    };
    await UpdateWorkHour(saveWorkDay);
    console.log(saveWorkDay);
  };

  const handleDataChange = (value, inputType) => {
    setChanges(true);
    setNewWorkDay({
      ...newWorkDay,
      [inputType]: value,
    });
  };

  if (dataLoading) {
    return <LoadingScreen />;
  }

  return (
    <div className="work-day">
      <tr>
        <td>
          <BasicSelect
            def={"Select Customer"}
            collection={clients}
            value={newWorkDay.clientId}
            selected={newWorkDay.clientName}
            callback={(e) => handleDataChange(e.target.value, "clientId")}
          />
        </td>
        <td>
          <BasicSelect
            def={"Select Project"}
            collection={projects}
            value={newWorkDay.projectId}
            selected={newWorkDay.projectName}
            callback={(e) => handleDataChange(e.target.value, "projectId")}
          />
        </td>
        <td>
          <BasicSelect
            def={"Select Category"}
            collection={categories}
            value={newWorkDay.categoryId}
            selected={newWorkDay.categoryName}
            callback={(e) =>
              handleDataChange(e.target.value + "1", "categoryId")
            }
          />
        </td>
        <td>
          <input
            type="text"
            className="in-text medium"
            value={newWorkDay.description}
            onChange={(e) => handleDataChange(e.target.value, "description")}
          />
        </td>
        <td class="small">
          <input
            type="text"
            className="in-text xsmall"
            value={newWorkDay.time}
            onChange={(e) => handleDataChange(e.target.value, "time")}
          />
        </td>
        <td class="small">
          <input
            type="text"
            className="in-text xsmall"
            value={newWorkDay.overtime}
            onChange={(e) => handleDataChange(e.target.value, "overtime")}
          />
        </td>
      </tr>
    </div>
  );
};

export default WorkDay;
