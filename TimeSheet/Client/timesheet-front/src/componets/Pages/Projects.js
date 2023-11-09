import React, { useEffect, useState } from 'react';
import { GetProjects } from '../../services/ProjectService';
import { GetClients } from '../../services/ClientsService';
import { GetUsers } from '../../services/UserService';
import EntityBar from '../basic-components/EntityBar';
import UpdateProjectForm from '../Forms/UpdateProjectForm';
import Search from '../basic-components/Search';
import PaginationBar from '../basic-components/PaginationBar';

const Projects = ({ color, text, onClick }) => {
  const [projects, setProjects] = useState([]);
  const [users, setUsers] = useState([]);
  const [clients, setClients] = useState([]);
  const [stringQuery, setStringQuery] = useState('');
  const [numberOfPages, setNumberOfPages] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    async function fetchData() {
      try {
        stringQuery.PageNumber = currentPage;
        stringQuery.PageSize = 4;
        const response = await GetProjects(stringQuery);
        setProjects(response.items);
        setNumberOfPages(Math.ceil(response.totalItems / response.pageSize));

        const responseClients = await GetClients();
        setClients(responseClients.items);

        const responseUsers = await GetUsers();
        setUsers(responseUsers.items);
      } catch (error) {
        console.error('Error fetching projects:', error);
      }
    }

    fetchData();
  }, [stringQuery,currentPage]);

  return (
    <div>
      <Search setQuery={setStringQuery}></Search>
      {projects.map((item, index) => (
        <EntityBar
          key={index}
          text={item.name}
          text2={item.clientName}
          form={<UpdateProjectForm project={item} users={users} clients={clients} />}
        />
      ))}
      <PaginationBar number={numberOfPages} onClick = {setCurrentPage} />
    </div>
  );
};

export default Projects;
