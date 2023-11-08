import axios from "axios";


const host = "http://localhost:5168/";

export const SignIn = async (user) => {
    try {
      const response = await axios.post(host + 'users/login', user, {
        withCredentials: true, 
      });
      console.log(response);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  };
export const Authenticate = async () => {
    try {
      const response = await axios.get(host + 'users/authenticate',{withCredentials: true});
      return response.data;

    } catch (error) {
        console.log("not logged it")
    }
  };
export const Logout = async () => {
    try {
      const response = await axios.post(host + 'users/logout',{},{withCredentials: true});
      return response.data;

    } catch (error) {
        console.log("Error logging out")
    }
  };