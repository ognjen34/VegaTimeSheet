import axios from 'axios';


const host = "http://localhost:5168/";

export const GetProjects = async (queryParams) => {
  try {
    const response = await axios.get(host + 'projects', {
      withCredentials: true,
      params: queryParams, 
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching projects:", error);
    throw error; 
  }
};
export const UpdateProject = async (project) => {
    try {
      const response = await axios.put(host + 'projects/', project, {
        withCredentials: true, 
      });
      console.log(response);
    } catch (error) {
      console.error(error);
      throw error;
    }
  };