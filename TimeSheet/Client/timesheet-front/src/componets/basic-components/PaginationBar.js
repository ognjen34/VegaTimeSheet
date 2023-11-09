import React from 'react';

const PaginationBar = ({ number, onClick }) => {
  const renderPageNumbers = () => {
    const pageNumbers = [];
    for (let i = 1; i <= number; i++) {
      pageNumbers.push(
        <li key={i}>
          <a className='link' href={`#page-${i}`} onClick={() => onClick(i)}>
            {i}
          </a>
        </li>
      );
    }
    return pageNumbers;
  };

  return (
    <div className="pagination">
      <ul>
        {renderPageNumbers()}
        <li className="last">
          <a className='link'>Next</a>
        </li>
      </ul>
    </div>
  );
};

export default PaginationBar;
