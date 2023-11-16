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
  export const AddProject = async (project) => {
    try {
      const response = await axios.post(host + 'projects/', project, {
        withCredentials: true, 
      });
      console.log(response);
    } catch (error) {
      console.error(error);
      throw error;
    }
  };

  export const GetClientProjects = async (id) => {
    console.log(id)
    try {
      const response = await axios.get(host + 'projects/client/'+id, {
        withCredentials: true, 
      });
      console.log(response);
      return response
    } catch (error) {
      console.error(error);
      throw error;
    }
  };