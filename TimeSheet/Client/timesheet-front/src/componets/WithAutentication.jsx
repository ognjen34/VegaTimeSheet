import React from 'react';
import './basic-items.css';

const WithAutentication = (Component) => {
  if (IsAuthenticated) {
    return navigator.navigate('/Login')
  }

  return (
    <Component />
  );
};

export default BasicButton;