import React, { useEffect, useState } from "react";
import "./TimeSheet.css";
import { GetDataForTimesheet } from "../../services/WorkHoursService";

const TimeSheet = ({ color, text, onClick }) => {
  const [dates, setDates] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await GetDataForTimesheet();
        setDates(response.workDays);
      } catch (error) {
        // Handle the error
      }
    }

    fetchData();
  }, []);

  const renderWeeks = () => {
    const weeks = Math.ceil(dates.length / 7);
    const currentMonth = new Date().getMonth() + 1; // Adding 1 because getMonth() returns 0-based month
  
    return Array.from({ length: weeks }, (_, weekIndex) => (
      <tr key={weekIndex}>
        {Array.from({ length: 7 }, (_, dayIndex) => {
          const dateIndex = weekIndex * 7 + dayIndex;
          const date = dates[dateIndex];
  
          const isPreviousMonth = date && new Date(date.fullDate).getMonth() + 1 < currentMonth;
          const isNextMonth = date && new Date(date.fullDate)  > new Date();

  
          return (
            <td key={dayIndex} className={`${date.hours >0 ? 'positive' : ''} ${isPreviousMonth ? 'previous' : ''} ${isNextMonth ? 'disable' : ''}`}>
              <div className="date">
                <span>{date ? date.date + '.' : ''}</span>
              </div>
              <div className="hours">
                <a href="days.html">
                  Hours: <span>{date ? date.hours : ''}</span>
                </a>
              </div>
            </td>
          );
        })}
      </tr>
    ));
  };

  return (
    <div>
      <table className="month-table">
        <tbody>
          <tr className="head">
            <th>
              <span>monday</span>
            </th>
            <th>tuesday</th>
            <th>wednesday</th>
            <th>thursday</th>
            <th>friday</th>
            <th>saturday</th>
            <th>sunday</th>
          </tr>
          <tr className="mobile-head">
            <th>mon</th>
            <th>tue</th>
            <th>wed</th>
            <th>thu</th>
            <th>fri</th>
            <th>sat</th>
            <th>sun</th>
          </tr>
          {renderWeeks()}
        </tbody>
      </table>
    </div>
  );
};

export default TimeSheet;
