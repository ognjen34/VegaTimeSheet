import { React, useEffect, useState } from "react";
import { GetProjects } from "../../services/ProjectService";
import { GetClients } from "../../services/ClientsService";
import { GetUsers } from "../../services/UserService";
import EntityBar from "../basic-components/EntityBar";
import UpdateProjectForm from "../Forms/UpdateProjectForm";
import UpdateClientForm from "../Forms/UpdateClientForm";
import { getCountries } from "../../services/CountriesService";
import Search from "../basic-components/Search";
import PaginationBar from "../basic-components/PaginationBar";
import CreateClientForm from "../Forms/CreateClientForm";

const Client = ({ color, text, onClick }) => {
  const [clients, setClients] = useState([]);
  const [countries, setCountries] = useState([]);
  const [stringQuery, setStringQuery] = useState("");
  const [numberOfPages, setNumberOfPages] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    async function fetchData() {
      try {
        stringQuery.PageNumber = currentPage;
        stringQuery.PageSize = 3;
        const responseClients = await GetClients(stringQuery);
        setClients(responseClients.items);
        setNumberOfPages(
          Math.ceil(responseClients.totalItems / responseClients.pageSize)
        );

        console.log(responseClients.items);
        const responseCountries = await getCountries();
        setCountries(responseCountries);
        console.log(responseCountries);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    }
    fetchData();
  }, [stringQuery, currentPage]);

  return (
    <div>
      <Search
        setQuery={setStringQuery}
        title={"Create Client"}
        createForm={<CreateClientForm countries={countries} />}
      ></Search>

      {clients.map((item, index) => (
        <EntityBar
          text={item.name}
          form={<UpdateClientForm client={item} countries={countries} />}
        />
      ))}
      <PaginationBar number={numberOfPages} onClick={setCurrentPage} />
    </div>
  );
};

export default Client;
