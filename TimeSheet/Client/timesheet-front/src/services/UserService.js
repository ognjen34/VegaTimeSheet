import axios from "axios";


const host = "http://localhost:5168/";

function getCookie(name) {
  const cookieValue = document.cookie.match('(^|;)\\s*' + name + '\\s*=\\s*([^;]+)');
  return cookieValue ? cookieValue.pop() : null;
  
}

export function getJWT()
{
  const jwtToken = getCookie('jwtToken');

  console.log('JWT Token:', jwtToken);
}

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

  export const GetUsers = async (queryParams) => {
    try {
      const response = await axios.get(host + 'users/', {
        withCredentials: true,
        params: queryParams, 
      });
  
      return response.data;
    } catch (error) {
      console.error("Error fetching users:", error);
      throw error; 
    }
  };
  