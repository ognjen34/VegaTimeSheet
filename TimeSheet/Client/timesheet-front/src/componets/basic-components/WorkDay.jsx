import React, { useState, useEffect, useRef } from "react";
import "./basic-items.css";
import { GetClientProjects } from "../../services/ProjectService";
import BasicSelect from "./BasicSelect";
import useFetch from "../../services/useFetch";
import LoadingScreen from "./LetterButton";
import BasicInput from "./BasicInput";
import {
  AddWorkHour,
  ConvertDate,
  UpdateWorkHour,
} from "../../services/WorkHoursService";

const WorkDay = ({ workDay, clients, categories, paramDate }) => {
  const [newWorkDay, setNewWorkDay] = useState(
    workDay ? workDay : { clientId: "", time: 0, overtime: 0 ,description :"" }
  );
  const [changes, setChanges] = useState(false);
  const [projects, setProjects] = useState([]);

  const [isProjectValid, setProjectValid] = useState(false);
  const [isClientValid, setClientValid] = useState(false);
  const [isCategoryValid, setCategoryValid] = useState(false);

  

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
    }, 3000);
  }, [newWorkDay,isProjectValid , isCategoryValid , isClientValid]);

  const saveWorkDay = async (t) => {
    console.log(isProjectValid , isCategoryValid , isClientValid)
    if (isProjectValid && isCategoryValid && isClientValid) {
      console.log(workDay);

      let saveWorkDay = {
        projectId: t.projectId,
        categoryId: t.categoryId,
        description: t.description,
        date: t.date,
        time: t.time,
        overtime: t.overtime,
      };
      if (t.id == undefined) {
        console.log(saveWorkDay);
        saveWorkDay.date = paramDate;

        await AddWorkHour(saveWorkDay);
      } else {
        saveWorkDay.id = t.id;
        await UpdateWorkHour(saveWorkDay);
      }
      console.log(saveWorkDay);
    }
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
            validation={setClientValid}
            def={"Select Customer"}
            collection={clients}
            value={newWorkDay.clientId}
            selected={newWorkDay.clientName}
            callback={(e) => handleDataChange(e.target.value, "clientId")}
          />
        </td>
        <td>
          <BasicSelect
            validation={setProjectValid}
            def={"Select Project"}
            collection={projects}
            value={newWorkDay.projectId}
            selected={newWorkDay.projectName}
            callback={(e) => handleDataChange(e.target.value, "projectId")}
          />
        </td>
        <td>
          <BasicSelect
            validation={setCategoryValid}
            def={"Select Category"}
            collection={categories}
            value={newWorkDay.categoryId}
            selected={newWorkDay.categoryName}
            callback={(e) => handleDataChange(e.target.value, "categoryId")}
          />
        </td>
        <td>
          <BasicInput
            type={"text"}
            callback={(e) => handleDataChange(e.target.value, "description")}
            value={newWorkDay.description}
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
