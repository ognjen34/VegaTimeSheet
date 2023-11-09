import React, { useState, useEffect } from "react";
import "./basic-items.css";
import LetterButton from "./LetterButton";

const capitalLetters = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];

const Search = ({ setQuery }) => {
  const [letter, setLetter] = useState(null);
  const [searchBar, setSearchBar] = useState(null);
  const [clickedIndex, setClickedIndex] = useState(null);

  useEffect(() => {
    if (searchBar == "")
    {
      setSearchBar(null)
    }
    let query = 
    {
      StringQuery :searchBar,
      FirstLetter : letter,
    }
    setQuery(query);
  }, [letter,searchBar]);

  const handleSearchChange = (e) => {
    setSearchBar(e.target.value);
  };

  return (
    <div className="search">
      <div className="grey-box-wrap reports">
        <a href="#new-member" className="link new-member-popup">
          Create new client
        </a>
        <div className="search-page">
          <input type="search" name="search-clients" className="in-search" value={searchBar} onChange={handleSearchChange} />
        </div>
      </div>
      <div className="alpha">
        <ul>
          {capitalLetters.map((item, index) => (
            <li>
              <LetterButton className="letters" text={item} clickedIndex = {clickedIndex === index && letter ==item ? true : false}  onClick={() => {if(letter == item)
                {setLetter(null);
                }
                else{
                setLetter(item);
               } setClickedIndex(index)}} />
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Search;
