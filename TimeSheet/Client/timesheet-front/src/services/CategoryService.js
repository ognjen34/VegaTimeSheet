import axios from 'axios';


const host = "http://localhost:5168/";

export const GetCategories = async () => {
  try {
    const response = await axios.get(host + 'categories/', {
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error; 
  }
};
