import React, { useEffect, useState } from "react";
import "./TimeSheet.css";
import { GetDataForTimesheet } from "../../services/WorkHoursService";
import { Link } from "react-router-dom";

const TimeSheet = ({}) => {
  const [dates, setDates] = useState([]);
  const [currentDate, setCurrentDate] = useState(new Date());
  const [totalHours, setTotalHours] = useState(0);
  const handleDateChange = (value) => {
    setCurrentDate(
      new Date(currentDate.setMonth(currentDate.getMonth() + value))
    );
    console.log(currentDate);
  };

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await GetDataForTimesheet(currentDate);
        setTotalHours(response.totalHours);
        setDates(response.workDays);
      } catch (error) {}
    }

    fetchData();
  }, [currentDate]);

  const renderWeeks = () => {
    const weeks = Math.ceil(dates.length / 7);
    const nextMonth = new Date().getMonth() + 1;

    return Array.from({ length: weeks }, (_, weekIndex) => (
      <tr key={weekIndex}>
        {Array.from({ length: 7 }, (_, dayIndex) => {
          const dateIndex = weekIndex * 7 + dayIndex;
          const date = dates[dateIndex];

          const isPreviousMonth =
            date && new Date(date.fullDate).getMonth() + 1 < nextMonth;
          const isNextMonth = date && new Date(date.fullDate) > new Date();
          const isSuccessful = date.flag ? "positive" : "negative";
          const result = date.hours > 0 ? isSuccessful : "";

          return (
            <td
              key={dayIndex}
              className={`${result} ${isPreviousMonth ? "previous" : ""} ${
                isNextMonth ? "disable" : ""
              }`}
            >
              <div className="date">
                <span>{date ? date.date + "." : ""}</span>
              </div>
              <div className="hours">
                <a>
                  <Link to={"work-week/" + date.fullDate}>
                    Hours: <span>{date ? date.hours : ""}</span>
                  </Link>
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
      <div className="grey-box-wrap-timesheet">
        <div className="top">
          <a className="prev" onClick={() => handleDateChange(-1)}>
            <i className="zmdi zmdi-chevron-left"></i>previous month
          </a>
          <span className="center">
            {currentDate.toLocaleString("en-US", { month: "long" })},{" "}
            {currentDate.getFullYear()}
          </span>
          <a className="next" onClick={() => handleDateChange(1)}>
            next month<i class="zmdi zmdi-chevron-right"></i>
          </a>
        </div>
        <div className="bottom"></div>
      </div>
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
      <div class="total">
        <span>
          Total hours: <em>{totalHours}</em>
        </span>
      </div>
    </div>
  );
};

export default TimeSheet;
