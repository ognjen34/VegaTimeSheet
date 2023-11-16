import React, { useEffect, useState } from 'react';
import { GetProjects } from '../../services/ProjectService';
import { GetClients } from '../../services/ClientsService';
import { GetUsers } from '../../services/UserService';
import EntityBar from '../basic-components/EntityBar';
import UpdateProjectForm from '../Forms/UpdateProjectForm';
import Search from '../basic-components/Search';
import PaginationBar from '../basic-components/PaginationBar';
import CreateProjectForm from '../Forms/CreateProjectForm';
import { GetCategories } from '../../services/CategoryService';
import CreateCategoryForm from '../Forms/CreateCategoryForm';
import UpdateCategoryForm from '../Forms/UpdateCategoryForm';

const Categories = ({  }) => {
  const [categories, setCategories] = useState([]);
  const [stringQuery, setStringQuery] = useState('');
  const [numberOfPages, setNumberOfPages] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    async function fetchData() {
      try {
        stringQuery.PageNumber = currentPage;
        stringQuery.PageSize = 3;
        const response = await GetCategories(stringQuery);
        setCategories(response.items);
        setNumberOfPages(Math.ceil(response.totalItems / response.pageSize));

      } catch (error) {
        console.error('Error fetching projects:', error);
      }
    }

    fetchData();
  }, [stringQuery,currentPage,categories]);

  return (
    <div>
      <Search setQuery={setStringQuery} title = {"Create Category"} createForm ={<CreateCategoryForm />} ></Search>
      {categories.map((item, index) => (
        <EntityBar
          key={index}
          text={item.name}
          text2={item.clientName}
          form={<UpdateCategoryForm category={item} collection = {categories} setCollection = {setCategories} />}
        />
      ))}
      <PaginationBar number={numberOfPages} onClick = {setCurrentPage} />
    </div>
  );
};

export default Categories;
