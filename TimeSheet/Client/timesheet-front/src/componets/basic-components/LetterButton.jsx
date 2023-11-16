import React from 'react';
import './basic-items.css';

const LetterButton = ({text,onClick,clickedIndex}) => {
    
  const buttonClass = clickedIndex? `letter-button letter-button-clicked` : 'letter-button';

    return (
  <button className={buttonClass}  onClick={onClick}>
      {text}
      </button>
    );
  };
  
  export default LetterButton;