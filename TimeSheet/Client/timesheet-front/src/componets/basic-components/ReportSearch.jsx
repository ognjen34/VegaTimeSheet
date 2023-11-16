import React, { useState, useEffect } from "react";
import "./basic-items.css";
import LetterButton from "./LetterButton";
import CreateModeDialog from "../CreateModelDialog";
import useFetch from "../../services/useFetch";
import { GetCategories } from "../../services/CategoryService";
import { GetProjects } from "../../services/ProjectService";
import { GetClients } from "../../services/ClientsService";
import { GetUsers } from "../../services/UserService";
import LoadingScreen from "./LetterButton";
import BasicSelect from "./BasicSelect";
import BasicInput from "./BasicInput";
import BasicButton from "./BasicButton";
import Search from "./Search";

let emptyQuery = {UserId: "",
ClientId: "",
ProjectId: "",
CategoryId: "",
StartDate: "",
EndDate: "",
}
const ReportSearch = ({ printQuery }) => {

  const [clients, setClients] = useState([]);
  const [projects, setProjects] = useState([]);
  const [users, setUsers] = useState([]);
  const [categories, setCategories] = useState([]);
  const [query, setQuery] = useState(emptyQuery);

  const {
    projectsData,
    categoriesData,
    clientsData,
    usersData,
    isLoading: dataLoading,
    error: dataError,
  } = useFetch({
    projectsData: () => GetProjects({ PageSize: 100 }),
    categoriesData: GetCategories,
    clientsData: GetClients,
    usersData: GetUsers,
  });
  const handleQueryChange = (value, inputType) => {
    setQuery((prevQuery) => ({
      ...prevQuery,
      [inputType]: value,
    }));
  };

  useEffect(() => {
    if (!dataLoading) {
      setCategories(categoriesData.items);
      setProjects(projectsData.items);
      setClients(clientsData.items);
      setUsers(usersData.items);
    }
  }, [projectsData, categoriesData, clientsData, usersData, dataLoading]);

  if (dataLoading) {
    return <LoadingScreen />;
  }

  const handleSearchChange = (e) => {};

  return (
    <div className="grey-box-wrap reports">
      <ul className="form">
        <BasicSelect
          label={"User: "}
          collection={users}
          value={query.UserId}
          def = {"All"}
          callback={(e) => handleQueryChange(e.target.value, "UserId")}
        />
        <BasicSelect
          label={"Category: "}
          collection={categories}
          value={query.CategoryId}
          def = {"All"}
          callback={(e) => handleQueryChange(e.target.value, "CategoryId")}
        />
      </ul>
      <ul className="form">
        <BasicSelect
          label={"Client: "}
          collection={clients}
          value={query.ClientId}
          def = {"All"}
          callback={(e) => handleQueryChange(e.target.value, "ClientId")}
        />
        <BasicInput
          type={"text"}
          label={"Start Date: "}
          callback={(e) => handleQueryChange(e.target.value, "StartDate")}
          value={query.StartDate}
        />
      </ul>
      <ul className="form last">
        <BasicSelect
          label={"Project: "}
          collection={projects}
          value={query.ProjectId}
          def = {"All"}
          callback={(e) => handleQueryChange(e.target.value, "ProjectId")}
        />
        <BasicInput
          type={"text"}
          label={"End Date: "}
          callback={(e) => handleQueryChange(e.target.value, "EndDate")}
          value={query.EndDate}
        />
        <li>
          <BasicButton color = {"#52a552"} text ={"Search"} onClick={()=>printQuery(query)}/>
          <BasicButton color = {"#f1592a"}text ={"Reset"} onClick = {()=>{setQuery(emptyQuery); console.log(query)}}/>

        </li>
      </ul>
    </div>
  );
};

export default ReportSearch;
