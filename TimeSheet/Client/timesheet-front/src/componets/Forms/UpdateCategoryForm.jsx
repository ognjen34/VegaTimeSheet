import React, { useState } from "react";
import "./Forms.css";
import BasicButton from "../basic-components/BasicButton";
import { DeleteCategory } from "../../services/CategoryService";



const UpdateCategoryForm = ({ category, collection,setCollection }) => {

    
const handleDelete= async () =>
{
    setCollection(collection.filter(item => item !== category));
    await DeleteCategory(category.id);

}


  return (
    <div className="form-wrap">
      <BasicButton onClick={handleDelete} color="#be3730" text="Delete" />
    </div>
  );
};

export default UpdateCategoryForm;
