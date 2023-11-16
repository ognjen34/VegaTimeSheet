import { React, useState,useEffect } from "react";
import ReportSearch from "../basic-components/ReportSearch";
import { DownloadReports, GetReports } from "../../services/ReportService";
import "./Reports.css";
import { ConvertDate } from "../../services/WorkHoursService";
import BasicButton from "../basic-components/BasicButton";
import useFetch from "../../services/useFetch";
const Reports = ({ color, text, onClick }) => {
  
  const [reports, setReports] = useState([]);
  const [downQuery, setDownQuery] = useState("");
  const callback = async (query) => {
    const response = await GetReports(query);

    setDownQuery(query);
  };
  
  const {
    reportData,
    isLoading: dataLoading,

  } = useFetch({
    reportData: () => GetReports(downQuery),
    
  },[downQuery]);

  useEffect(() => {
    if (!dataLoading) {
      setReports(reportData);
      
    }
  }, [reportData, dataLoading]);

  return (
    <>
      <ReportSearch printQuery={callback} />
      <table class="default-table">
        <tbody>
          <tr>
            <th>Date</th>
            <th>Team member</th>
            <th>Projects</th>
            <th>Categories</th>
            <th>Description</th>
            <th class="small">Time</th>
          </tr>
          {reports.map((item, index) => (
            <tr>
              <td>{ConvertDate(new Date(item.date))}</td>
              <td>{item.teamMember}</td>
              <td>{item.projectName}</td>
              <td>{item.categoryName}</td>
              <td>{item.description}</td>
              <td class="small">{item.time}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <BasicButton color = {"#52a552"} text ={"Download"} onClick={async ()=>{await DownloadReports(downQuery)}}/>
    </>
  );
};

export default Reports;
