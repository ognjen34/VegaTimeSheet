import React from "react";
import Modal from "react-modal";
import "./css/Dialog.css";
import BasicButton from "./basic-components/BasicButton";
import CloseIcon from "../assets/img/close-icon.png" 
Modal.setAppElement("#root");

const CreateModeDialog = ({ isOpen, onClose, title, form }) => {
  const handleCreateUser = () => {
    onClose();
  };

  return (
    <Modal className="modal" isOpen={isOpen} onRequestClose={onClose}>
      <button className="close-button" onClick={onClose}>
            <img src={CloseIcon} alt="Close" />
          </button>
      <div className="dialog-content">
        <div id="new-member" className="new-member-inner">
          <h2>{title}</h2>  
        </div>
        {form}
      </div>
    </Modal>
  );
};

export default CreateModeDialog;
