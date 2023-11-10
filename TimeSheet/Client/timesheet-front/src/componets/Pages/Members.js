import { React, useState, useEffect } from "react";
import { GetUsers } from "../../services/UserService";
import UpdateUserForm from "../Forms/UpdateUserForm";
import PaginationBar from "../basic-components/PaginationBar";
import EntityBar from "../basic-components/EntityBar";
import CreateUserForm from "../Forms/CreateUserForm";
import Search from "../basic-components/Search";

const Members = ({ color, text, onClick }) => {
  const [stringQuery, setStringQuery] = useState("");
  const [numberOfPages, setNumberOfPages] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);
  const [users, setUsers] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        let query = {}
        query.PageNumber = currentPage;
        query.PageSize = 3;
        const responseUser = await GetUsers(query);
        setUsers(responseUser.items);
        setNumberOfPages(
          Math.ceil(responseUser.totalItems / responseUser.pageSize)
        );
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    }
    fetchData();
  }, [currentPage]);

  return <div>
    <Search  setQuery = {setStringQuery}createForm ={<CreateUserForm/>} title ={"Create New User"} isUser = {true}></Search>

    {users.map((item, index) => (
        <EntityBar text = {item.name}  form ={<UpdateUserForm user = {item}  />}/>
      ))}
      <PaginationBar number={numberOfPages} onClick = {setCurrentPage} />

  </div>;
};

export default Members;
