import {React,useState} from "react";

import CreateUserForm from "./Forms/CreateUserForm";
import CreateProjectForm from "./Forms/CreateProjectForm";
import WorkDay from "./basic-components/WorkDay";
import ReportSearch from "./basic-components/ReportSearch";
import { GetReports } from "../services/ReportService";

const callback = async (query) =>
{
  await GetReports(query)
}
const Test = ({ color, text, onClick }) => {
  return (
    <div>
      <ReportSearch printQuery ={callback} />
      
    </div>
  );
};

export default Test;
