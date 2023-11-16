import axios from 'axios';
import { saveAs } from 'file-saver';


const host = "http://localhost:5168/";


export const GetReports = async (queryParams) => {
    try {
      const response = await axios.get(host + 'reports', {
        withCredentials: true,
        params: queryParams, 
      });
      return response.data.reportInstance;
    } catch (error) {
      console.error("Error fetching projects:", error);
      throw error; 
    }
  };

  export const DownloadReports = async (queryParams) => {
    try {
      const response = await axios.get(host + 'reports/download', {
        withCredentials: true,
        params: queryParams,
        responseType: 'blob',
      });
  
      const contentDisposition = response.headers['content-disposition'];
  
      saveAs(new Blob([response.data], { type: 'application/pdf' }), "reports");
    } catch (error) {
      console.error("Error fetching projects:", error);
      throw error;
    }
  };