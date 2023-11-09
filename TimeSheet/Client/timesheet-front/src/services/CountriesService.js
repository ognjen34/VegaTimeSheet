import axios from 'axios';


const host = "http://localhost:5168/";

export const getCountries = async () => {
  try {
    const response = await axios.get(host + 'countries/', {
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching countries:", error);
    throw error; 
  }
};
