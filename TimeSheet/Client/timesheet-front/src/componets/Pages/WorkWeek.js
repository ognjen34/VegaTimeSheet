import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetWorkDays } from "../../services/WorkHoursService";
import WorkDay from "../basic-components/WorkDay";
import { GetCategories } from "../../services/CategoryService";
import { GetClients } from "../../services/ClientsService";
import "./TimeSheet.css";

const i = [1,2,3,4,5,6,7]

const WorkWeek = () => {
  const paramDate = useParams().date;
  const [workDays, setWorkDays] = useState([]);
  const [categories, setCategories] = useState([]);
  const [clients, setClients] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await GetWorkDays(paramDate);
        setWorkDays(response);
        const categoriesResponse = await GetCategories();
        setCategories(categoriesResponse.items);
        const clientsResponse = await GetClients();
        setClients(clientsResponse.items);
      } catch (error) {}
    }

    fetchData();
  }, []);

  return (
    <div>
      <table className="default-table">
        <tbody>
        {i.map((item, index) => (
          <WorkDay
          workDay={workDays[item]}
          categories={categories}
          clients={clients}
        />
          
        ))}
        </tbody>
      </table>
    </div>
  );
};

export default WorkWeek;
