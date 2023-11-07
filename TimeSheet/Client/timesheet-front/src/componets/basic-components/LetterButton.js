import React from 'react';
import './basic-items.css';

const LetterButton = ({text,onClick}) => {
    
  
    return (
  <button className="letter-button"  onClick={onClick}>
      {text}
      </button>
    );
  };
  
  export default LetterButton;