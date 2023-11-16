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

export const UpdateCategory = async (category) => {
  try {
    const response = await axios.put(host + 'categories/', category, {
      withCredentials: true, 
    });
    console.log(response);
  } catch (error) {
    console.error(error);
    throw error;
  }
};
export const AddCategory = async (category) => {
  try {
    const response = await axios.post(host + 'categories/', category, {
      withCredentials: true, 
    });
    console.log(response);
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const DeleteCategory = async (id) => {
  try {
    const response = await axios.delete(host + 'categories/'+id, {
      withCredentials: true,
    });

    return response.data;
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error; 
  }
};
