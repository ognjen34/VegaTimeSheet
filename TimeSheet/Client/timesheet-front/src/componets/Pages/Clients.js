import {React,useEffect, useState} from 'react';
import { GetProjects } from '../../services/ProjectService';
import { GetClients } from '../../services/ClientsService';
import { GetUsers } from '../../services/UserService';
import EntityBar from '../basic-components/EntityBar';
import UpdateProjectForm from '../Forms/UpdateProjectForm';
import UpdateClientForm from '../Forms/UpdateClientForm';
import { getCountries } from '../../services/CountriesService';
import Search from '../basic-components/Search';

const Client = ({ color, text, onClick }) => {
  const [clients, setClients] = useState([]); 
  const [countries, setCountries] = useState([]); 
  const [stringQuery,setStringQuery] = useState("")



  useEffect(() => {
    async function fetchData() {
      try {
        const responseClients = await GetClients(stringQuery);
        setClients(responseClients.items);
        console.log(responseClients.items);
        const responseCountries = await getCountries();
        setCountries(responseCountries);
        console.log(responseCountries);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    }
    fetchData();
  }, [stringQuery]);

  return (
    <div>
      <Search setQuery = {setStringQuery}></Search>

      {clients.map((item, index) => (
        <EntityBar text = {item.name}  form ={<UpdateClientForm client = {item}  countries ={countries}/>}/>
      ))}
    </div>
  );
};


export default Client;