import React from 'react';
import BasicButton from './componets/basic-components/BasicButton';
import LetterButton from './componets/basic-components/LetterButton';

function App() {
  const handleButtonClick = () => {
    alert('Button Clicked!');
  };

  return (
    <div className="App">
      <header className="App-header">
        <BasicButton color="#52a552" text ="Search" onClick={handleButtonClick} />
        <BasicButton color="#f67d34" text ="Reset" onClick={handleButtonClick} />
        <LetterButton color="#f67d34" text ="A" onClick={handleButtonClick} />
        <LetterButton color="#f67d34" text ="B" onClick={handleButtonClick} />
        <input type="search" name="search-clients" class="in-search"></input>




      </header>
    </div>
  );
}

export default App;
