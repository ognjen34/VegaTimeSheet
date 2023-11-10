import axios from 'axios';


const host = "http://localhost:5168/";

export const GetClients = async (queryParams) => {
  try {
    const response = await axios.get(host + 'clients/', {
      withCredentials: true,
      params: queryParams, 
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching clients:", error);
    throw error; 
  }
};

export const UpdateClient = async (client) => {
    try {
      const response = await axios.put(host + 'clients/', client, {
        withCredentials: true, 
      });
      console.log(response);
    } catch (error) {
      console.error(error);
      throw error;
    }
  };

  export const AddClient = async (client) => {
    try {
      const response = await axios.post(host + 'clients/', client, {
        withCredentials: true, 
      });
      console.log(response);
    } catch (error) {
      console.error(error);
      throw error;
    }
  };
