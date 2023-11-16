import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetWorkDays } from "../../services/WorkHoursService";
import WorkDay from "../basic-components/WorkDay";
import { GetCategories } from "../../services/CategoryService";
import { GetClients } from "../../services/ClientsService";
import "./TimeSheet.css";
import LoadingScreen from "../basic-components/LetterButton";
import useFetch from "../../services/useFetch";

const i = [0, 1, 2, 3, 4, 5, 6];

const WorkWeek = () => {
  const paramDate = useParams().date;
  const [workDays, setWorkDays] = useState([]);
  const [categories, setCategories] = useState([]);
  const [clients, setClients] = useState([]);

  const {
    workDaysData,
    categoriesData,
    clientsData,
    isLoading: dataLoading,
    error: dataError,
  } = useFetch({
    workDaysData: () => GetWorkDays(paramDate),
    categoriesData: GetCategories,
    clientsData: GetClients,
  });


  useEffect(() => {
    if (!dataLoading) {
      setWorkDays(workDaysData);
      setCategories(categoriesData.items);
      setClients(clientsData.items);
    }
  }, [workDaysData, categoriesData, clientsData, dataLoading]);

  if (dataLoading){return <LoadingScreen/>}

  return (
    <div>
        <table className="default-table">
          <tbody>
            {i.map((item, index) => (
              
              <WorkDay workDay={workDays[item]} paramDate = {paramDate} categories={categories} clients={clients} key={index} />
            ))}
          </tbody>
        </table>
      
    </div>
  );
};

export default WorkWeek;
