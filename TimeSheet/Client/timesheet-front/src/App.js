import React, { useEffect,useState } from 'react';
import {Routes, Route, Navigate, useNavigate} from 'react-router-dom';

import { Authenticate } from './services/UserService';
import Login from './componets/Login';
import HomePage from './componets/HomePage';
import TimeSheet from './componets/Pages/TimeSheet';
import Clients from './componets/Pages/Clients';
import Categories from './componets/Pages/Categories';
import Members from './componets/Pages/Members';
import Reports from './componets/Pages/Reports';
import Projects from './componets/Pages/Projects';

function App() {
  const [user, setUser] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);


  useEffect(() => {
    async function fetchData() {
      try {
        const response = await Authenticate();
        setUser(response)
        if (response)
        {
          setIsAuthenticated(true);
          await setUser(response)
        }
      } catch (error) {
        console.error("Error during login:", error);
      }
    }
    fetchData();
  }, []);

  useEffect(() => {
    console.log("Updated user:", user);


  }, [user]);
  

  return (
    <div className="App">
              <Routes>
              <Route
                path="/login"
                element={
                    isAuthenticated ? 
                      <Navigate to="/home/timesheet"/>
                      : 
                      <Login/>
                }
            />
            <Route
                path="/home"
                element={
                    isAuthenticated ? <HomePage user = {user}/> : <Navigate to="/login" />
                }>
                  <Route path="timesheet" element={<TimeSheet/>}/>
                  <Route path="clients" element={<Clients/>}/>
                  <Route path="projects" element={<Projects/>}/>
                  <Route path="categories" element={<Categories/>}/>
                  <Route path="members" element={<Members/>}/>
                  <Route path="reports" element={<Reports/>}/>
                  </Route>
                
              </Routes>
              


    </div>
  );
}

export default App;
