import axios from "axios";

const host = "http://localhost:5168/";

export function ConvertDate(currentDate) {
  const year = currentDate.getFullYear();
  const month = String(currentDate.getMonth() + 1).padStart(2, "0");
  const day = String(currentDate.getDate()).padStart(2, "0");

  const formattedDate = `${year}-${month}-${day}`;
  console.log(formattedDate);
  return formattedDate;
}

export function GetLastMonday(currentDate) {
  currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

  const dayOfWeek = currentDate.getDay();
  const daysUntilLastMonday = (dayOfWeek + 6) % 7;

  const lastMonday = new Date(currentDate);
  lastMonday.setDate(currentDate.getDate() - daysUntilLastMonday);
  console.log(lastMonday);
  return lastMonday;
}

function AddDays(date, days) {
  const result = new Date(date);
  result.setDate(date.getDate() + days);
  return result;
}
function GetDatesForTimeSheet(currentDate) {
  const monday = GetLastMonday(currentDate);
  const start = ConvertDate(monday);
  const end = ConvertDate(AddDays(monday, 34));
  let range = {
    startDate: start,
    endDate: end,
  };
  return range;
}
export const GetDataForTimesheet = async (currentDate) => {
  const range = GetDatesForTimeSheet(currentDate);
  try {
    const response = await axios.post(host + "monthlyhours/", range, {
      withCredentials: true,
    });
    console.log(response);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};
export const GetWorkDays = async (currentDate) => {
  try {
    const response = await axios.get(
      host + "workhours/workday/" + currentDate,
      {
        withCredentials: true,
      }
    );
    console.log(response);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
    
  }
  
};
export const UpdateWorkHour = async (wh) => {
  try {
    const response = await axios.put(host + 'workhours', wh, {
      withCredentials: true, 
    });
    console.log(response);
    return response;
  } catch (error) {
    console.error(error);
    throw error;
  }
};
export const AddWorkHour = async (wh) => {
  try {
    const response = await axios.post(host + 'workhours', wh, {
      withCredentials: true, 
    });
    console.log(response);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};
